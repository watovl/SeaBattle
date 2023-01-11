using System;
using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    public static class CreatorShip
    {
        public static Ship CreateRandomShip(IEnumerable<int> freeCells, int numberOfDeck)
        {
            Random rand = new Random();
            int position = GetRandomAvailablePosition(rand, freeCells);
            DirectionShip direction = GetRandomDirectionShip(rand);
            return new Ship(position, numberOfDeck, direction);
        }

        private static DirectionShip GetRandomDirectionShip(Random rand)
        {
            return (DirectionShip)rand.Next(2);
        }

        private static int GetRandomAvailablePosition(Random rand, IEnumerable<int> freeCells)
        {
            int index = rand.Next(freeCells.Count());
            return freeCells.ElementAt(index);
        }
    }
}
