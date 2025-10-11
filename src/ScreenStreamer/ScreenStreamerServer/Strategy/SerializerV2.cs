using ScreenStreamerServer.DTO;
using System.Drawing;
using System.IO.Compression;
using System.Runtime.Versioning;

namespace ScreenStreamerServer.Strategy
{
    internal class SerializerV2
    {
        [SupportedOSPlatform("windows")]
        public void Serialize(string filePath)
        {
            Data data;
            using (Bitmap b = new Bitmap(filePath))
            {
                short height = (short)b.Height;
                short width = (short)b.Width;

                data = new Data(1, height);

                int p = 0;
                for (short y = 0; y < height; y++)
                {
                    Line l = new Line(y, width);
                    data.Lines[y] = l;
                    for (short x = 0; x < height; x++)
                    {
                        Color c = b.GetPixel(x, y);
                        l.Pixels[x++] = new PixelV2(y, c.R, c.G, c.B);
                    }
                }
            }

            //todo pass in byte[]
            using (MemoryStream ms = new MemoryStream())
            {
                using (MemoryStream cs = new MemoryStream())
                {
                    using (GZipStream s = new GZipStream(cs, CompressionLevel.Fastest, false))
                    {
                        ms.CopyTo(s);
                    }
                }
            }
        }
    }
}
