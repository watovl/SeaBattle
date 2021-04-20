using System;
using System.Collections.Generic;

namespace SeaBattle {
    // Направление корабля
    enum DirectionShip {
        Vertically, Horizontally
    }

    class PlacementOfShips {
        private bool[,] CellsArray;
        private List<int> FreeCellsList;
        private readonly int Height;
        private readonly int Width;
        private readonly int Length;

        private delegate bool FuncOfAdd(int position, int numberOfDeck);

        public PlacementOfShips(int height, int width) {
            Height = height;
            Width = width;
            CellsArray = new bool[Height, Width];
            FreeCellsList = new List<int>(Height * Width);
            Length = Height * Width;
            for (int i = 0; i < Length; ++i) {
                FreeCellsList.Add(i);
            }
        }

        /// <summary>
        /// Вставка корабля вертикально
        /// </summary>
        /// <param name="position">Позиция левого края корабля</param>
        /// <param name="numberOfDeck">Количество палуб на корабле</param>
        /// <returns>Если вставить удалось, вернёт true, иначе - false</returns>
        private bool AddVerticallyShip(int position, int numberOfDeck) {
            if (position < Length - (numberOfDeck - 1) * Width) {
                // Проверка позиции
                bool isOccupiedCell = false;
                for (int i = 0; i < numberOfDeck + 2; ++i) {
                    for (int j = 0; j < 3; ++j) {
                        int indexHeight = position / Width - 1 + i;
                        int indexWidth = position % Width - 1 + j;
                        // Проверка границ массива
                        if (indexHeight >= 0 & indexHeight < Height & indexWidth >= 0 & indexWidth < Width) {
                            isOccupiedCell |= CellsArray[indexHeight, indexWidth];
                        }
                    }
                    if (isOccupiedCell) {
                        break;
                    }
                }
                // Место не занято
                if (!isOccupiedCell) {
                    // Добавление корабля
                    for (int i = 0; i < numberOfDeck; ++i) {
                        CellsArray[position / Width + i, position % Width] = true;
                    }
                    // Удаление занятых ячеек из списка пустых ячеек
                    for (int i = -1; i < numberOfDeck + 1; ++i) {
                        for (int j = 0; j < 3; ++j) {
                            FreeCellsList.Remove(position - 1 + j + i * Width);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Вставка корабля горизонтально
        /// </summary>
        /// <param name="position">Позиция левого края корабля</param>
        /// <param name="numberOfDeck">Количество палуб на корабле</param>
        /// <returns>Если вставить удалось, вернёт true, иначе - false</returns>
        private bool AddHorizontallyShip(int position, int numberOfDeck) {
            if (position % Width <= Width - numberOfDeck) {
                // Проверка позиции
                bool isOccupiedCell = false;
                for (int i = 0; i < numberOfDeck + 2; ++i) {
                    for (int j = 0; j < 3; ++j) {
                        int indexHeight = position / Width - 1 + j;
                        int indexWidth = position % Width - 1 + i;
                        // Проверка границ массива
                        if (indexHeight >= 0 & indexHeight < Height & indexWidth >= 0 & indexWidth < Width) {
                            isOccupiedCell |= CellsArray[indexHeight, indexWidth];
                        }
                    }
                    if (isOccupiedCell) {
                        break;
                    }
                }
                // Место не занято
                if (!isOccupiedCell) {
                    // Добавление корабля
                    for (int i = 0; i < numberOfDeck; ++i) {
                        CellsArray[position / Width, position % Width + i] = true;
                    }
                    // Удаление занятых ячеек из списка пустых ячеек
                    for (int i = 0; i < numberOfDeck + 2; ++i) {
                        for (int j = -1; j < 2; ++j) {
                            FreeCellsList.Remove(position - 1 + i + j * Width);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Добавление корабля на поле
        /// </summary>
        /// <param name="numberOfDeck">Количество палуб на корабле</param>
        public bool AddShip(int numberOfDeck) {
            Random rand = new Random();
            List<int> availableCell = new List<int>(FreeCellsList);
            FuncOfAdd[] funcsOfAdd = new FuncOfAdd[] { AddVerticallyShip, AddHorizontallyShip };
            bool isAddedShip = false;
            while (!isAddedShip) {
                // Проверка на пустоту доступных ячеек
                if (availableCell.Count == 0) {
                    break;
                }
                int position = availableCell[rand.Next(availableCell.Count)];
                DirectionShip direction = (DirectionShip)rand.Next(2);

                isAddedShip = funcsOfAdd[(int)direction](position, numberOfDeck);
                if (!isAddedShip) {
                    // Изменение направления корабля
                    direction ^= DirectionShip.Vertically ^ DirectionShip.Horizontally;
                    isAddedShip = funcsOfAdd[(int)direction](position, numberOfDeck);
                    if (!isAddedShip) {
                        // Удаление позиции из списка доступных позиций
                        availableCell.Remove(position);
                    }
                }
            }
            return isAddedShip;
        }

        public void ShowCellArray() {
            for (int i = 0; i < Height; i++) {
                for (int j = 0; j < Width; j++) {
                    Console.Write(CellsArray[i, j] ? "1 " : "0 ");
                }
                Console.WriteLine();
            }
        }
    }
}
