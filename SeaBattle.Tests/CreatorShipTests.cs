using System.Collections.Generic;
using Xunit;

namespace SeaBattle.Tests
{
    public class CreatorShipTests
    {
        [Fact]
        public void CorrectCreatedShip()
        {
            const int position = 0;
            List<int> freeCells = new List<int>() { position };
            const int numberOfDeck = 1;

            Ship ship = CreatorShip.CreateRandomShip(freeCells, numberOfDeck);

            Assert.Equal(position, ship.IndexPosition);
            Assert.Equal(numberOfDeck, ship.NumberOfDecks);
        }
    }
}
