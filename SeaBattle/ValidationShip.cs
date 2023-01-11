using System;

namespace SeaBattle
{
    public static class ValidationShip
    {
        private const string _errorMessage = "Некорректное значение направления корабля";

        public static bool CanPlaceShipOnBattleField(Ship ship, BattleField battleField)
        {
            return IsShipFitsWithinBoundaries(ship, battleField.SizeField)
                && IsCellsAreFree(ship, battleField);
        }

        private static bool IsShipFitsWithinBoundaries(Ship ship, SizeBattleField sizeFields)
        {
            return ship.Direction switch
            {
                DirectionShip.Vertically => ship.IndexPosition + (ship.NumberOfDecks - 1) * sizeFields.Width
                    < sizeFields.CountCells,
                DirectionShip.Horizontally => ship.IndexPosition % sizeFields.Width
                    <= sizeFields.Width - ship.NumberOfDecks,
                _ => throw new ArgumentException(_errorMessage),
            };
        }

        private static bool IsCellsAreFree(Ship ship, BattleField battleField)
        {
            var bordersShip = LocatorBorderShip.GetBordersShip(ship);
            int horizontallyBorderShip = bordersShip.Horizontally;
            int verticallyBorderShip = bordersShip.Vertically;
            int indexShipHeight = CalculatorIndexShip.GetIndexHeight(ship.IndexPosition, battleField.SizeField.Width);
            int indexShipWidth = CalculatorIndexShip.GetIndexWidth(ship.IndexPosition, battleField.SizeField.Width);
            for (int horizontalShift = -1; horizontalShift < horizontallyBorderShip - 1; ++horizontalShift)
            {
                for (int verticalShift = -1; verticalShift < verticallyBorderShip - 1; ++verticalShift)
                {
                    int indexCheckCellHeight = indexShipHeight + verticalShift;
                    int indexCheckCellWidthCell = indexShipWidth + horizontalShift;
                    if (IsIndexWithinBoundar(indexCheckCellHeight, battleField.SizeField.Height)
                        && IsIndexWithinBoundar(indexCheckCellWidthCell, battleField.SizeField.Width))
                    {
                        bool isOccupiedCell = battleField.Field[indexCheckCellHeight][indexCheckCellWidthCell];
                        if (isOccupiedCell)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool IsIndexWithinBoundar(int index, int boundar)
        {
            return index >= 0 & index < boundar;
        }
    }
}
