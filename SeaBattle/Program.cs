using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    class Program {
       static void Main(string[] args) {
            int height;
            int width;
            bool isTryParse = true;
            Console.Write("Строк: ");
            isTryParse &= int.TryParse(Console.ReadLine(), out height);
            Console.Write("Столбцов: ");
            isTryParse &= int.TryParse(Console.ReadLine(), out width);

            if (!isTryParse) {
                Console.WriteLine("Значения введены не корректно");
                return;
            }
            if (height < 4 & width < 4) {
                Console.WriteLine("Слишком маленькие значения");
                return;
            }

            PlacementOfShips ships = new PlacementOfShips(height, width);
            for (int i = 4; i > 0; --i) {
                for (int j = i; j < 5; ++j) {
                     if (!ships.AddShip(i)) {
                        Console.WriteLine("Не удалось разместить все корабли.");
                        return;
                    }
                }
            }
            ships.ShowCellArray();
        }
    }
}
