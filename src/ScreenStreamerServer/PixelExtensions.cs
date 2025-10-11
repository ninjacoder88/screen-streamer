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

        public static byte[] Serialize(this PixelV1 source)
        {
            byte[] array = new byte[10];
            Buffer.BlockCopy(BitConverter.GetBytes(source.X), 0, array, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(source.Y), 0, array, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(source.R), 0, array, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(source.G), 0, array, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(source.B), 0, array, 8, 2);
            return array;
        }
    }
}
