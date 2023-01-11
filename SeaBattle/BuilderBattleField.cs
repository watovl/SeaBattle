using System;

namespace SeaBattle
{
    public static class BuilderBattleField
    {
        private const string _errorMessage = "Слишком маленькие значения размеров поля";
        private const string _errorParamName = "Размер поля боя";
        private static readonly IProviderParams _providerParams = new ProviderParameters();
        private static BattleField _battleField;

        public static void Build()
        {
            try
            {
                _battleField = MakeFillingBattleField();
                Console.WriteLine(_battleField.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Ошибка при выполнении: {exception.Message}");
            }
        }

        private static BattleField MakeFillingBattleField()
        {
            SizeBattleField sizeBattleField = _providerParams.GetParams();
            ValidateParams(sizeBattleField);
            BattleField battleField = new BattleField(sizeBattleField);
            FillingBattleFieldWithShips.FillBattleField(battleField);
            return battleField;
        }

        private static void ValidateParams(SizeBattleField sizeBattleField)
        {
            if (sizeBattleField.Height < 4 || sizeBattleField.Width < 4)
            {
                throw new ArgumentOutOfRangeException(_errorParamName, _errorMessage);
            }
        }
    }
}
