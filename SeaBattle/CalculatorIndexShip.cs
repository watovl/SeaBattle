namespace SeaBattle
{
    public static class CalculatorIndexShip
    {
        public static int GetIndexHeight(int indexPosition, int width)
        {
            return indexPosition / width;
        }

        public static int GetIndexWidth(int indexPosition, int width)
        {
            return indexPosition % width;
        }
    }
}