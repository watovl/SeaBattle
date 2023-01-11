using System.Collections.Generic;

namespace SeaBattle
{
    public static class DecksShip
    {
        public static IEnumerable<int> GetDecks()
        {
            const int MaxNumberOfDeck = 4;
            for (int numberOfDeck = MaxNumberOfDeck; numberOfDeck > 0; --numberOfDeck)
            {
                int numberOfShips = MaxNumberOfDeck - numberOfDeck + 1;
                for (int shipCounter = 1; shipCounter <= numberOfShips; ++shipCounter)
                {
                    yield return numberOfDeck;
                }
            }
        }
    }
}
