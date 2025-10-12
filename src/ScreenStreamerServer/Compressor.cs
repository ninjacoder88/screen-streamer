using System.IO.Compression;

namespace ScreenStreamerServer
{
    internal static class Compressor
    {
        public static byte[] Compress(byte[] source)
        {
            using (MemoryStream sourceStream = new MemoryStream(source))
            {
                using (MemoryStream compressed = new MemoryStream())
                {
                    using (GZipStream stream = new GZipStream(compressed, CompressionLevel.Fastest))
                    {
                        sourceStream.CopyTo(stream);
                        return compressed.ToArray();
                    }
                }
            }
        }
    }
}
