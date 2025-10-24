using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace ScreenStreamer.Server
{
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += Worker_DoWork;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool Streaming { get; set; }

        private bool Connected { get; set; }

        private void MainForm_Load(object? sender, EventArgs e) => _worker.RunWorkerAsync();

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e) => _worker.CancelAsync();

        private void LogError(string message) => Log("ERROR", message);

        private void LogInfo(string message) => Log("INFO", message);

        private void Log(string severity, string message) =>
            rtbLogs.Invoke(() => rtbLogs.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {severity} - {message}\r\n{rtbLogs.Text}");

        private void UpdatePicture(Bitmap bitmap)
        {
            pbPreview.Invoke(() =>
            {
                try
                {
                    pbPreview.Image = bitmap;
                    pbPreview.Update();
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
            });
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int x1;
            int y1;
            int x2;
            int y2;
            int interval = 250;
            IPAddress? ipAddress;
            const int Version = 3;

            try
            {
                x1 = tbxX1.GetIntValue();
                y1 = tbxY1.GetIntValue();
                x2 = tbxX2.GetIntValue();
                y2 = tbxY2.GetIntValue();
                interval = tbxInterval.GetIntValue();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                return;
            }

            int streamHeight = y2 - y1;
            int streamWidth = x2 - x1;

            Pixel[][] current = new Pixel[streamHeight][];
            for (short x = 0; x < streamHeight; x++)
            {
                current[x] = new Pixel[streamWidth];
                for (short y = 0; y < streamWidth; y++)
                    current[x][y] = new Pixel(x, y, 255, 255, 255);
            }

            UdpClient client = new UdpClient();

            while (true)
            {
                if (_worker.CancellationPending)
                {
                    client.Close();
                    client.Dispose();
                    return;
                }

                if (Streaming && !Connected)
                {
                    try
                    {
                        interval = tbxInterval.GetIntValue();
                        ipAddress = IPAddress.Parse(tbxIpAddress.Text);

                        client.Connect(ipAddress, 42069);
                        LogInfo($"Connected to {ipAddress}");
                        Connected = true;
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                }

                List<Pixel> updatedPixels = new List<Pixel>();
                try
                {
                    using (Bitmap bitmap = new Bitmap(streamWidth, streamHeight))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(Point.Empty, Point.Empty, new Size(streamWidth, streamHeight));
                        }

                        for (short y = 0; y < streamHeight; y++)
                        {
                            for (short x = 0; x < streamWidth; x++)
                            {
                                Color c = bitmap.GetPixel(x, y);
                                Pixel p = new Pixel(x, y, c.R, c.G, c.B);
                                if (current[x][y] == p)
                                    continue;
                                updatedPixels.Add(p);
                                current[x][y] = p;
                            }
                        }

                        if(updatedPixels.Count > 0)
                            UpdatePicture(bitmap);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }

                if (!Streaming)
                {
                    Thread.Sleep(interval);
                    continue;
                }

                if (updatedPixels.Count == 0)
                {
                    Thread.Sleep(interval);
                    continue;
                }

                //TODO: handle the case where too many pixels are updated to send in a single packet

                int currentByte = 0;
                short updatedRows = 0;
                byte[] rawPacket = new byte[5 + (7 * updatedPixels.Count)];

                try
                {
                    rawPacket[currentByte++] = Version;
                    rawPacket[currentByte += 2] = 0;//packet size
                    rawPacket[currentByte += 2] = 0;//row count

                    short currentY = -1;
                    short pixelsUpdatedInRow = 0;
                    foreach (Pixel pixel in updatedPixels)
                    {
                        if (pixel.Y != currentY)
                        {
                            BitConverter.GetBytes(currentY).CopyTo(rawPacket, currentByte += 2);
                            currentY = pixel.Y;
                            updatedRows++;
                            //LogInfo($"Update {pixelsUpdatedInRow} pixels in row {currentY}");
                            pixelsUpdatedInRow = 0;
                        }

                        BitConverter.GetBytes(pixel.X).CopyTo(rawPacket, currentByte += 2);
                        rawPacket[currentByte++] = pixel.R;
                        rawPacket[currentByte++] = pixel.G;
                        rawPacket[currentByte++] = pixel.B;
                        pixelsUpdatedInRow++;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }

                BitConverter.GetBytes(currentByte).CopyTo(rawPacket, 1);//update size of packet
                BitConverter.GetBytes(updatedRows).CopyTo(rawPacket, 3);//update rows in packet

                byte[] packet = new byte[currentByte];
                Buffer.BlockCopy(rawPacket, 0, packet, 0, packet.Length);

                try
                {
                    client.Send(packet, packet.Length);
                    LogInfo($"Sent {packet.Length} bytes | Rows Updated: {updatedRows}");
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }

                Thread.Sleep(interval);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Streaming = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Streaming = false;
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            //ShowPreview = true;
        }

        private void btnHidePreview_Click(object sender, EventArgs e)
        {
            //ShowPreview = false;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly BackgroundWorker _worker;

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            rtbLogs.Invoke(() => rtbLogs.Text = "");
        }
    }

    public record Pixel(short X, short Y, byte R, byte G, byte B);
}
