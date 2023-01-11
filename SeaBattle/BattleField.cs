using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattle
{
    public class BattleField
    {
        public IReadOnlyList<IReadOnlyList<bool>> Field => _field;
        public IReadOnlyList<int> FreeCellsIndeces => _freeCellsIndeces;
        public SizeBattleField SizeField { get; }
        
        private const string _errorMessage = "Некорректное значение направления корабля";
        private readonly bool[][] _field;
        private readonly List<int> _freeCellsIndeces;

        private delegate int GetShift(int deckNumber);

        public BattleField(SizeBattleField sizeBattleField)
        {
            SizeField = sizeBattleField;
            _field = new bool[SizeField.Height][];
            for (int i = 0; i < SizeField.Height; ++i)
            {
                _field[i] = new bool[SizeField.Width];
            }
            _freeCellsIndeces = new List<int>(SizeField.CountCells);
            FillFreeCellsIndeces();
        }

        public BattleField(int heightField, int widthField)
        {
            SizeField = new SizeBattleField(heightField, widthField);
            _field = new bool[SizeField.Height][];
            for (int i = 0; i < SizeField.Height; ++i)
            {
                _field[i] = new bool[SizeField.Width];
            }
            _freeCellsIndeces = new List<int>(SizeField.CountCells);
            FillFreeCellsIndeces();
        }

        private void FillFreeCellsIndeces()
        {
            for (int i = 0; i < SizeField.CountCells; ++i)
            {
                _freeCellsIndeces.Add(i);
            }
        }

        public void PlaceShip(Ship ship)
        {
            InsertShip(ship);
            RemoveFreeCellsShip(ship);
        }

        private void InsertShip(Ship ship)
        {
            var getShift = GetShiftFuncs(ship);
            for (int deckNumber = 0; deckNumber < ship.NumberOfDecks; ++deckNumber)
            {
                int indexShipHeight = CalculatorIndexShip.GetIndexHeight(ship.IndexPosition, SizeField.Width)
                    + getShift.Height(deckNumber);
                int indexShipWidth = CalculatorIndexShip.GetIndexWidth(ship.IndexPosition, SizeField.Width)
                    + getShift.Width(deckNumber);
                _field[indexShipHeight][indexShipWidth] = true;
            }
        }

        private static (GetShift Height, GetShift Width) GetShiftFuncs(Ship ship)
        {
            static int shiftByDeckNumber(int deckNumber) => deckNumber;
            static int shiftByZero(int deckNumber) => 0;
            return ship.Direction switch
            {
                DirectionShip.Vertically => (Height: shiftByDeckNumber, Width: shiftByZero),
                DirectionShip.Horizontally => (Height: shiftByZero, Width: shiftByDeckNumber),
                _ => throw new ArgumentException(_errorMessage)
            };
        }

        private void RemoveFreeCellsShip(Ship ship)
        {
            var bordersShip = LocatorBorderShip.GetBordersShip(ship);
            int horizontallyBorderShip = bordersShip.Horizontally;
            int verticallyBorderShip = bordersShip.Vertically;
            for (int horizontalShift = -1; horizontalShift < horizontallyBorderShip - 1; ++horizontalShift)
            {
                for (int verticalShift = -1; verticalShift < verticallyBorderShip - 1; ++verticalShift)
                {
                    int indexofRemoving = verticalShift * SizeField.Width
                        + ship.IndexPosition + horizontalShift;
                    _freeCellsIndeces.Remove(indexofRemoving);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder field = new StringBuilder();
            for (int i = 0; i < SizeField.Height; i++)
            {
                for (int j = 0; j < SizeField.Width; j++)
                {
                    field.Append(Field[i][j] ? "1 " : "0 ");
                }
                field.AppendLine();
            }
            return field.ToString();
        }
    }
}
