namespace ScreenStreamerServer.DTO
{
    public struct Data
    {
        public Data(byte version, short l)
        {
            Version = version;
            Length = l;
            Lines = new Line[l];
        }
        public byte Version { get; }
        public short Length { get; }
        public Line[] Lines { get; }
    }

    public struct Line
    {
        public Line(short y, short l)
        {
            Y = y;
            L = l;
            Pixels = new PixelV2[l];
        }
        public short Y { get; }
        public short L { get; }
        public PixelV2[] Pixels { get; }
    }

    public record struct PixelV2(short X, byte R, byte G, byte B);
}
