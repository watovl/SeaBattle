using Xunit;
using SeaBattle;

namespace SeaBattle.Tests
{
    public class CalculatorIndexShipTests
    {
        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(23, 9, 2)]
        [InlineData(45, 10, 4)]
        public void GotCorrectIndexHeight(int indexPosition, int width, int expected)
        {
            int actual = CalculatorIndexShip.GetIndexHeight(indexPosition, width);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(23, 9, 5)]
        [InlineData(45, 10, 5)]
        public void GotCorrectIndexWidth(int indexPosition, int width, int expected)
        {
            int actual = CalculatorIndexShip.GetIndexWidth(indexPosition, width);

            Assert.Equal(expected, actual);
        }
    }
}
