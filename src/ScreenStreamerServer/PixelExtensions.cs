using ScreenStreamerServer.DTO;

namespace ScreenStreamerServer
{
    internal static class PixelExtensions
    {
        public static byte[] Serialize(this PixelV1[] source)
        {
            byte[] array = new byte[source.Length * 10];//10 is the current size of PixelV1
            for(int i = 0; i < source.Length; i++)
            {
                byte[] serializedPixel = source[i].Serialize();
                Buffer.BlockCopy(serializedPixel, 0, array, i * 10, 10);
            }
            return array;
        }
    }
}
