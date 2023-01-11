namespace SeaBattle
{
    public class Ship
    {
        public int IndexPosition { get; }
        public int NumberOfDecks { get; }
        public DirectionShip Direction { get; set; }

        public Ship(int indexPosition, int numberOfDecks, DirectionShip direction)
        {
            IndexPosition = indexPosition;
            NumberOfDecks = numberOfDecks;
            Direction = direction;
        }
    }

    // Направление корабля
    public enum DirectionShip
    {
        Vertically, Horizontally
    }
}
