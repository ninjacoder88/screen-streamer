using System.IO.Compression;

namespace ScreenStreamer.Server
{
    internal static class Compressor
    {
        public static byte[] Compress(byte[] source)
        {
            using (MemoryStream sourceStream = new MemoryStream(source))
            {
                using (MemoryStream compressedStream = new MemoryStream())
                {
                    using (GZipStream compressionStream = new GZipStream(compressedStream, CompressionLevel.Fastest))
                    {
                        sourceStream.CopyTo(compressionStream);
                        return compressedStream.ToArray();
                    }
                }
            }
        }

        public static byte[] Decompress(byte[] source)
        {
            using(MemoryStream sourceStream = new MemoryStream(source))
            {
                using(MemoryStream decompressedStream = new MemoryStream())
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressedStream.CopyTo(decompressedStream);
                        return decompressedStream.ToArray();
                    }
                }
            }
        }
    }
}
