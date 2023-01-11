using System;

namespace SeaBattle
{
    public static class LocatorBorderShip
    {
        private const string _errorMessage = "Некорректное значение направления корабля";

        public static (int Vertically, int Horizontally) GetBordersShip(Ship ship)
        {
            int lengthAlongShip = ship.NumberOfDecks + 2;
            int lengthAcrossShip = 3;
            return ship.Direction switch
            {
                DirectionShip.Vertically => (Vertically: lengthAlongShip, Horizontally: lengthAcrossShip),
                DirectionShip.Horizontally => (Vertically: lengthAcrossShip, Horizontally: lengthAlongShip),
                _ => throw new ArgumentException(_errorMessage)
            };
        }
    }
}