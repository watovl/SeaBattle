using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SeaBattle.Tests
{
    public class DecksShipTests
    {
        [Fact]
        public void CorrectDecksShip()
        {
            List<int> expectedDecks = new List<int>()
            {
                4, 3, 3, 2, 2, 2, 1, 1, 1, 1
            };

            List<int> actualDecks = DecksShip.GetDecks().ToList();

            Assert.Equal(expectedDecks, actualDecks);
        }
    }
}
