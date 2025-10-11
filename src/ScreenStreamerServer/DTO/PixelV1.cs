namespace ScreenStreamerServer.DTO
{
    public record struct PixelV1(short X, short Y, short R, short G, short B)
    {
        public byte[] Serialize()
        {
            byte[] array = new byte[10];
            Buffer.BlockCopy(BitConverter.GetBytes(X), 0, array, 0, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(Y), 0, array, 2, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(R), 0, array, 4, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(G), 0, array, 6, 2);
            Buffer.BlockCopy(BitConverter.GetBytes(B), 0, array, 8, 2);
            return array;
        }
    }
}
