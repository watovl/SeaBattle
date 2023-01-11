using System;

namespace SeaBattle
{
    public class ProviderParameters : IProviderParams
    {
        private const string _errorMessage = "Значения введены не корректно";

        public SizeBattleField GetParams()
        {
            bool isTryParse = true;
            Console.WriteLine("Введите размер поля боя");
            Console.Write("Количество строк: ");
            isTryParse &= int.TryParse(Console.ReadLine(), out int height);
            Console.Write("Количество столбцов: ");
            isTryParse &= int.TryParse(Console.ReadLine(), out int width);
            if (!isTryParse)
            {
                throw new FormatException(_errorMessage);
            }
            return new SizeBattleField(height, width);
        }
    }
}
