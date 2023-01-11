using System;
using Xunit;

namespace SeaBattle.Tests
{
    public class LocatorBorderShipTests
    {
        private const int InitialPositionShip = 0;
        private const int NumberOfDecks = 4;

        [Fact]
        public void GotCorrectBordersForVerticallyShip()
        {
            const int expectedVertically = NumberOfDecks + 2;
            const int expectedHorizontally = 3;
            Ship ship = new Ship(InitialPositionShip, NumberOfDecks, DirectionShip.Vertically);

            (int actualVertically, int actualHorizontally) = LocatorBorderShip.GetBordersShip(ship);

            Assert.Equal(expectedVertically, actualVertically);
            Assert.Equal(expectedHorizontally, actualHorizontally);
        }

        [Fact]
        public void GotCorrectBordersForHorizontallyShip()
        {
            const int expectedVertically = 3;
            const int expectedHorizontally = NumberOfDecks + 2;
            Ship ship = new Ship(InitialPositionShip, NumberOfDecks, DirectionShip.Horizontally);

            (int actualVertically, int actualHorizontally) = LocatorBorderShip.GetBordersShip(ship);

            Assert.Equal(expectedVertically, actualVertically);
            Assert.Equal(expectedHorizontally, actualHorizontally);
        }

        [Fact]
        public void ThrowArgumentException()
        {
            const int invalidSizeField = 3;
            Ship ship = new Ship(InitialPositionShip, NumberOfDecks, (DirectionShip)invalidSizeField);

            Action testCode = () => LocatorBorderShip.GetBordersShip(ship);

            Assert.Throws<ArgumentException>(testCode);
        }
    }
}
