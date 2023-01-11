using Xunit;

namespace SeaBattle.Tests
{
    public class SizeBattleFieldTests
    {
        [Fact]
        public void CorrectCountCells()
        {
            const int height = 5;
            const int width = 7;
            int expectedCountCells = height * width;

            SizeBattleField sizeBattleField = new SizeBattleField(height, width);

            Assert.Equal(expectedCountCells, sizeBattleField.CountCells);
        }
    }
}
