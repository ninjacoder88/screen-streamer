using ScreenStreamerServer.DTO;
using System.Net;
using System.Net.Sockets;

namespace ScreenStreamerServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnStop.Enabled = false;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            LogVerbose("Timer Elapsed");

            SendData();
        }

        private void SendData()
        {
            if (rbV1.Checked)
                SendPixelsV1(GetPixelsV1());
            else
                SendPixelsV2(GetPixelsV2());
        }

        private void UpdateState(ApplicationState newState)
        {
            switch(newState)
            {
                case ApplicationState.Stopped:
                    LogVerbose("Stopped");
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    tbxFilePath.Enabled = true;
                    chkCompression.Enabled = true;
                    rbV1.Enabled = true;
                    rbV2.Enabled = true;
                    break;
                case ApplicationState.Starting:
                    LogVerbose("Starting");
                    btnStart.Enabled = false;
                    tbxFilePath.Enabled = false;
                    chkCompression.Enabled = false;
                    rbV1.Enabled = false;
                    rbV2.Enabled = false;
                    break;
                case ApplicationState.Running:
                    LogVerbose("Running");
                    btnStop.Enabled = true;
                    break;
                case ApplicationState.Stopping:
                    LogVerbose("Stopping");
                    _timer.Stop();
                    _client?.Close();
                    _client?.Dispose();
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            UpdateState(ApplicationState.Starting);

            string ipAddressStr = tbxIpAddress.Text;
            if (string.IsNullOrEmpty(ipAddressStr))
            {
                LogError("IP Address is not set");
                UpdateState(ApplicationState.Stopped);
                return;
            }

            if(!IPAddress.TryParse(ipAddressStr, out IPAddress? ipAddress))
            {
                LogError("Invalid IP Address");
                UpdateState(ApplicationState.Stopped);
                return;
            }

            string intervalStr = tbxInterval.Text;
            if (string.IsNullOrEmpty(intervalStr))
            {
                LogError("Invalid interval");
                UpdateState(ApplicationState.Stopped);
                return;
            }

            if(!int.TryParse(intervalStr, out int interval))
            {
                LogError("Invalid interval");
                UpdateState(ApplicationState.Stopped);
                return;
            }

            _timer.Interval = interval;

            _client = new UdpClient();

            try
            {
                _client.Connect(ipAddress, 42069);
            }
            catch(Exception ex)
            {
                LogError(ex.Message);
                UpdateState(ApplicationState.Stopped);
                return;
            }
            
            string filePath = tbxFilePath.Text;
            if(string.IsNullOrEmpty(filePath))
            {
                LogError("File Path was not set");
                UpdateState(ApplicationState.Stopping);
                UpdateState(ApplicationState.Stopped);
                return;
            }

            if(!File.Exists(filePath))
            {
                LogError($"{filePath} does not exist");
                UpdateState(ApplicationState.Stopping);
                UpdateState(ApplicationState.Stopped);
                return;
            }

            _timer.Start();
            UpdateState(ApplicationState.Running);
            SendData();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            UpdateState(ApplicationState.Stopping);
            UpdateState(ApplicationState.Stopped);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }


        private T GetPixelsFromImage<T>(Func<Image, Bitmap, T> func)
        {
            string filePath = tbxFilePath.Text;

            LogVerbose($"Getting pixels");

            using (Image image = Image.FromFile(filePath))
            {
                using (Bitmap bitmap = new Bitmap(image))
                {
                    return func(image, bitmap);
                }
            }
        }

        private List<PixelV1> GetPixelsV1()
        {
            return GetPixelsFromImage<List<PixelV1>>((image, bitmap) =>
            {
                List<PixelV1> pixels = new List<PixelV1>();
                for (short h = 0; h < image.Height; h++)
                {
                    for (short w = 0; w < image.Width; w++)
                    {
                        Color c = bitmap.GetPixel(w, h);
                        pixels.Add(new PixelV1(w, h, c.R, c.G, c.B));
                    }
                }
                return pixels;
            });
        }

        private List<byte[]> GetPixelsV2()
        {
            return GetPixelsFromImage<List<byte[]>>((image, bitmap) =>
            {
                List<byte[]> lines = new List<byte[]>();
                for (short y = 0; y < image.Height; y++)
                {
                    byte[] line = new byte[2 + (image.Width * 5)];
                    Buffer.BlockCopy(BitConverter.GetBytes(y), 0, line, 0, 2);

                    for (short x = 0; x < image.Width; x++)
                    {
                        Color c = bitmap.GetPixel(x, y);
                        byte[] pixel = new PixelV2(y, c.R, c.G, c.B).Serialize();
                        pixel.CopyTo(line, 2 + (x * 5));
                    }

                    lines.Add(line);
                }
                return lines;
            });
        }


        private void SendPixelsV1(List<PixelV1> pixels)
        {
            LogVerbose("Sending pixels");
            int packetCount = 0;

            IEnumerable<PixelV1[]> pixelGroup = chkCompression.Checked ? pixels.Chunk(10000) : pixels.Chunk(6000);

            foreach(var groupOfPixels in pixelGroup)
            {
                try
                {
                    byte[] array = groupOfPixels.Serialize();
                    if(chkCompression.Checked)
                    {
                        byte[] compressedBytes = Compressor.Compress(array);
                        int bytesSent = _client?.Send(compressedBytes, compressedBytes.Length) ?? 0;
                    }
                    else
                    {
                        int bytesSent = _client?.Send(array, array.Length) ?? 0;
                    }
                    packetCount++;
                }
                catch(Exception e)
                {
                    LogError($"Error sending packet {e.Message}");
                }
            }
            LogVerbose($"Sending complete: {packetCount}");
        }

        private void SendPixelsV2(List<byte[]> lines)
        {
            LogVerbose("Sending pixels");
            int packetCount = 0;

            for(int i = 0; i < lines.Count; i++)
            {
                try
                {
                    byte[] line = lines[i];
                    int lineBytes = line.Length;

                    if (chkCompression.Checked)
                    {
                        byte[] compressedBytes = Compressor.Compress(line);
                        int bytesSent = _client?.Send(compressedBytes, compressedBytes.Length) ?? 0;
                    }
                    else
                    {
                        int bytesSent = _client?.Send(line, line.Length) ?? 0;
                    }
                    
                    packetCount++;
                }
                catch(Exception e)
                {
                    LogError($"Error sending packet {e.Message}");
                }
            }

            LogVerbose($"Sending complete: {packetCount}");
        }

        private void LogVerbose(string message) => Log("VERBOSE", message);
        private void LogError(string message) => Log("Error", message);

        private void Log(string severity, string message)
        {
            rtbLog.Invoke(() =>
            {
                rtbLog.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {severity} | {message}\r\n{rtbLog.Text}";
            });
        }

        private readonly System.Timers.Timer _timer;
        private UdpClient? _client;
    }
}
