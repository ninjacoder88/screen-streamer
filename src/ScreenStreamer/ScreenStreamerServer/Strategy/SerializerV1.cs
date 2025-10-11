using ScreenStreamerServer.DTO;
using System.Drawing;
using System.Runtime.Versioning;

namespace ScreenStreamerServer.Strategy
{
    internal class SerializerV1
    {
        [SupportedOSPlatform("windows")]
        public void Serialize(string filePath)
        {
            PixelV1[] array;
            using (Bitmap bitmap = new Bitmap(filePath))
            {
                short height = (short)bitmap.Height;
                short width = (short)bitmap.Width;

                array = new PixelV1[height * width];
                int p = 0;
                for (short y = 0; y < height; y++)
                {
                    for (short x = 0; x < height; x++)
                    {
                        Color c = bitmap.GetPixel(x, y);
                        array[p++] = new PixelV1(x, y, c.R, c.G, c.B);
                    }
                }
            }
        }
    }
}
