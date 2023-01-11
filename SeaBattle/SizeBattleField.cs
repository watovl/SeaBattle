namespace SeaBattle
{
    public class SizeBattleField
    {
        public int Height { get; }
        public int Width { get; }
        public int CountCells { get; }

        public SizeBattleField(int height, int width)
        {
            Height = height;
            Width = width;
            CountCells = Height * Width;
        }
    }
}
