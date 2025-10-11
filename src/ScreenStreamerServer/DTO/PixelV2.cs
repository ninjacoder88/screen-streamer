namespace ScreenStreamerServer.DTO
{
    internal readonly struct PixelV2
    {
        public PixelV2(short x, byte r, byte g, byte b)
        {
            X = x;
            R = r;
            G = g;
            B = b;
        }

        public short X { get; }
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public byte[] Serialize()
        {
            const int PixelSize = 5;
            byte[] array = new byte[PixelSize];
            Buffer.BlockCopy(BitConverter.GetBytes(X), 0, array, 0, 2);
            array[2] = R;
            array[3] = G;
            array[4] = B;
            return array;
        }
    }
}
