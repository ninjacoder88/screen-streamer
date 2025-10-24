using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;
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
            //ResizeBegin += MainForm_ResizeBegin;
            //ResizeEnd += MainForm_ResizeEnd;

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += Worker_DoWork;
        }

        private void MainForm_ResizeEnd(object? sender, EventArgs e)
        {
            _worker.RunWorkerAsync();
        }

        private void MainForm_ResizeBegin(object? sender, EventArgs e)
        {
            _worker.CancelAsync();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool ShowPreview { get; set; }

        private bool Streaming { get; set; }

        private void MainForm_Load(object? sender, EventArgs e) => _worker.RunWorkerAsync();

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e) => _worker.CancelAsync();

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int x1 = tbxX1.GetIntValue();
            int y1 = tbxY1.GetIntValue();
            int x2 = tbxX2.GetIntValue();
            int y2 = tbxY2.GetIntValue();

            int streamHeight = y2 - y1;
            int streamWidth = x2 - x1;

            Color[][] current = new Color[streamHeight][];
            for(short x = 0; x < streamHeight; x++)
            {
                current[x] = new Color[streamWidth];
                for(short y = 0; y < streamWidth; y++)
                {
                    current[x][y] = Color.Black;
                }
            }

            while (true)
            {
                if (_worker.CancellationPending)
                    return;

                if (!ShowPreview && !Streaming)
                    continue;

                try
                {
                    

                    using (Bitmap bitmap = new Bitmap(streamWidth, streamHeight))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(Point.Empty, Point.Empty, new Size(streamWidth, streamHeight));
                        }

                        if (ShowPreview)
                        {
                            pictureBox1.Invoke(() =>
                            {
                                pictureBox1.Image = bitmap;
                                pictureBox1.Update();
                            });
                        }

                        if (Streaming)
                        {
                            //build and send packets
                            byte[] rawPacket = new byte[(streamHeight * streamWidth * 5) + (streamHeight * 4)];

                            short currentByte = 0;
                            rawPacket[currentByte++] = 0;//version
                            rawPacket[currentByte+=2] = 0;//size
                            

                            //byte[] rows = new byte[(streamWidth * 5) + (streamHeight * 4)];
                            for(short y = 0; y < streamHeight; y++)
                            {
                                //byte[] pixels = new byte[streamWidth * 5];
                                //short updatedPixelCount = 0;

                                int rowStart = currentByte;
                                BitConverter.GetBytes(y).CopyTo(rawPacket, currentByte += 2);
                                //rawPacket[currentByte+=2] = ;//Y
                                rawPacket[currentByte+=2] = 0;//Pixel Count

                                short updatedPixelCount = 0;
                                for(short x = 0; x < streamWidth; x++)
                                {
                                    Color c = bitmap.GetPixel(x, y);
                                    if (current[x][y] == c)
                                        continue;

                                    //rawPacket[currentByte += 2];
                                    BitConverter.GetBytes(x).CopyTo(rawPacket, currentByte += 2);
                                    rawPacket[currentByte++] = c.R;
                                    rawPacket[currentByte++] = c.G;
                                    rawPacket[currentByte++] = c.B;
                                    updatedPixelCount++;

                                    //byte[] pixel = new byte[5];
                                    //byte[] xBytes = ;
                                    //pixel[0] = xBytes[0];
                                    //pixel[1] = xBytes[1];
                                    //pixel[2] = c.R;
                                    //pixel[3] = c.G;
                                    //pixel[4] = c.B;

                                    //pixel.CopyTo(rawPacket, updatedPixelCount * 5);
                                    //updatedPixelCount++;
                                }

                                if(updatedPixelCount == 0)
                                {
                                    currentByte -= 4;//subtract Y and PixelCount
                                }
                                else
                                {
                                    BitConverter.GetBytes(updatedPixelCount).CopyTo(rawPacket, rowStart + 2);
                                }


                                //byte[] yBytes = BitConverter.GetBytes(y);
                                //byte[] pcBytes = BitConverter.GetBytes(updatedPixelCount);

                                //byte[] row = new byte[4 + (updatedPixelCount * 5)];
                                //row[0] = yBytes[0];
                                //row[1] = yBytes[1];
                                //row[2] = pcBytes[0];
                                //row[3] = pcBytes[1];
                                //Buffer.BlockCopy(row, 4, pixels, 0, (updatedPixelCount * 5));

                                //row.CopyTo(rows, y);
                            }

                            BitConverter.GetBytes(currentByte).CopyTo(rawPacket, 1);

                            byte[] packet = new byte[currentByte];
                            Buffer.BlockCopy(rawPacket, 0, packet, 0, packet.Length);
                        }
                    }
                }
                catch(Exception ex)
                {

                }

                

                Thread.Sleep(250);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Streaming = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Streaming = false;
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            ShowPreview = true;
        }

        private void btnHidePreview_Click(object sender, EventArgs e)
        {
            ShowPreview = false;
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BackgroundWorker _worker;
    }
}
