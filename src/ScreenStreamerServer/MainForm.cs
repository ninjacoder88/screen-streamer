using ScreenStreamerServer.DTO;
using System.ComponentModel;
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
            SendPixels(GetPixels());
        }

        private readonly System.Timers.Timer _timer;
        private UdpClient _client;
        private readonly BackgroundWorker _backgroundWorker;

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            tbxFilePath.Enabled = false;
            LogVerbose("Starting");

            string ipAddressStr = tbxIpAddress.Text;
            if (string.IsNullOrEmpty(ipAddressStr))
            {
                LogError("IP Address is not set");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                return;
            }

            if(!IPAddress.TryParse(ipAddressStr, out IPAddress? ipAddress))
            {
                LogError("Invalid IP Address");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                return;
            }

            string intervalStr = tbxInterval.Text;
            if (string.IsNullOrEmpty(intervalStr))
            {
                LogError("Invalid interval");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                return;
            }

            if(!int.TryParse(intervalStr, out int interval))
            {
                LogError("Invalid interval");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
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
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                return;
            }
            
            string filePath = tbxFilePath.Text;
            if(string.IsNullOrEmpty(filePath))
            {
                LogError("File Path was not set");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                _client.Close();
                _client.Dispose();
                return;
            }

            if(!File.Exists(filePath))
            {
                LogError($"{filePath} does not exist");
                btnStart.Enabled = true;
                tbxFilePath.Enabled = true;
                _client.Close();
                _client.Dispose();
                return;
            }

            _timer.Start();
            LogVerbose("Started");
            
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            LogVerbose("Stopping");
            _timer.Stop();
            _client.Close();
            _client.Dispose();
            LogVerbose("Stopped");
            btnStart.Enabled = true;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbLog.Text = "";
        }

        private List<PixelV1> GetPixels()
        {
            string filePath = tbxFilePath.Text;

            LogVerbose($"Getting pixels");
            List<PixelV1> pixels = new List<PixelV1>();
            using (Image image = Image.FromFile(filePath))
            {
                using (Bitmap bitmap = new Bitmap(image))
                {
                    for (short h = 0; h < image.Height; h++)
                    {
                        for (short w = 0; w < image.Width; w++)
                        {
                            Color c = bitmap.GetPixel(w, h);
                            pixels.Add(new PixelV1(w, h, c.R, c.G, c.B));
                        }
                    }
                }
            }
            LogVerbose("Pixles obtained");
            return pixels;
        }

        private void SendPixels(List<PixelV1> pixels)
        {
            LogVerbose("Sending pixels");
            int packetCount = 0;
            foreach(var groupOfPixels in pixels.Chunk(6000))
            {
                try
                {
                    byte[] array = groupOfPixels.Serialize();
                    int bytesSent = _client.Send(array, array.Length);
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
    }
}
