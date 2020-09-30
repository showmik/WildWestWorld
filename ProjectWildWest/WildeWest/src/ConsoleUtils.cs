using System;

namespace WildeWest
{
    internal struct ConsoleUtils
    {
        public enum ColorConfigs
        {
            Telegram,
            Bob,
            Elsa
        }

        public static void SetTextColor(ColorConfigs colorConfigs)
        {
            switch (colorConfigs)
            {
                case ColorConfigs.Telegram:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;

                case ColorConfigs.Bob:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                case ColorConfigs.Elsa:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                default:
                    break;
            }
        }
    }
}