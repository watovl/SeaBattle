using System.Collections.Generic;

namespace SeaBattle
{
    public static class FillingBattleFieldWithShips
    {
        private const string _errorMessage = "На заданном поле не удалось разместить все корабли";

        public static void FillBattleField(BattleField battleField)
        {
            foreach (int numberOfDeck in DecksShip.GetDecks())
            {
                AddShipToBattleField(battleField, numberOfDeck);
            }
        }

        /// <param name="numberOfDeck">Количество палуб на корабле</param>
        private static void AddShipToBattleField(BattleField battleField, int numberOfDeck)
        {
            List<int> availableCells = new List<int>(battleField.FreeCellsIndeces);
            while (availableCells.Count != 0)
            {
                Ship ship = CreatorShip.CreateRandomShip(availableCells, numberOfDeck);
                if (TryToPlaceShip(battleField, ship))
                {
                    return;
                }
                ship.Direction = RedirectShip(ship);
                if (TryToPlaceShip(battleField, ship))
                {
                    return;
                }
                availableCells.Remove(ship.IndexPosition);
            }
            throw new PlacementException(_errorMessage);
        }

        private static bool TryToPlaceShip(BattleField battleField, Ship ship)
        {
            if (ValidationShip.CanPlaceShipOnBattleField(ship, battleField))
            {
                battleField.PlaceShip(ship);
                return true;
            }
            return false;
        }

        private static DirectionShip RedirectShip(Ship ship)
        {
            return ship.Direction ^ DirectionShip.Vertically ^ DirectionShip.Horizontally;
        }
    }
}
