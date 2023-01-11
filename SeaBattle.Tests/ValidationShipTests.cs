using System;
using Xunit;

namespace SeaBattle.Tests
{
    public class ValidationShipTests
    {
        private const int MinSizeField = 4;
        private const int InvalidSizeField = 3;
        private const int InitialPositionShip = 0;

        [Fact]
        public void ShipFitsWithinBoundaries()
        {
            const int MinNumberOfDecks = 1;
            const int MaxNumberOfDecks = 4;
            bool result = true;
            BattleField battleField = new BattleField(MinSizeField, MinSizeField);
            for (int numberOfDeck = MinNumberOfDecks; numberOfDeck <= MaxNumberOfDecks; ++numberOfDeck)
            {
                Ship shipVertical = new Ship(InitialPositionShip, numberOfDeck, DirectionShip.Vertically);
                Ship shipHorizontal = new Ship(InitialPositionShip, numberOfDeck, DirectionShip.Horizontally);

                result &= ValidationShip.CanPlaceShipOnBattleField(shipVertical, battleField);
                result &= ValidationShip.CanPlaceShipOnBattleField(shipHorizontal, battleField);
            }

            Assert.True(result);
        }

        [Theory]
        [InlineData(MinSizeField, InvalidSizeField)]
        [InlineData(InvalidSizeField, MinSizeField)]
        [InlineData(InvalidSizeField, InvalidSizeField)]
        public void ShipNotFitsWithinBoundaries(int height, int width)
        {
            const int MaxNumberOfDecks = 4;
            bool result;
            BattleField battleField = new BattleField(height, width);
            Ship shipVertical = new Ship(InitialPositionShip, MaxNumberOfDecks, DirectionShip.Vertically);
            Ship shipHorizontal = new Ship(InitialPositionShip, MaxNumberOfDecks, DirectionShip.Horizontally);

            result = ValidationShip.CanPlaceShipOnBattleField(shipVertical, battleField) 
                && ValidationShip.CanPlaceShipOnBattleField(shipHorizontal, battleField);

            Assert.False(result);
        }

        [Fact]
        public void ThrowArgumentException()
        {
            const int NumberOfDecks = 1;
            BattleField battleField = new BattleField(MinSizeField, MinSizeField);
            Ship ship = new Ship(InitialPositionShip, NumberOfDecks, (DirectionShip)InvalidSizeField);

            Action testCode = () => ValidationShip.CanPlaceShipOnBattleField(ship, battleField);

            Assert.Throws<ArgumentException>(testCode);
        }
    }
}
