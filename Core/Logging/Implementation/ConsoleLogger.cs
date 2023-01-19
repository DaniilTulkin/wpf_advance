using System;

namespace wpf_advance.Core
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message, LogFactoryLevel level)
        {
            var consoleOldColor = Console.ForegroundColor;
            var consoleColor = ConsoleColor.White;

            switch (level)
            {
                case LogFactoryLevel.Debag:
                    consoleColor = ConsoleColor.Blue;
                    break;
                case LogFactoryLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;
                case LogFactoryLevel.Informative:
                    consoleColor = ConsoleColor.White;
                    break;
                case LogFactoryLevel.Warning:
                    break;
                case LogFactoryLevel.Critical:
                    consoleColor = ConsoleColor.Red;
                    break;
                case LogFactoryLevel.Nothing:
                    break;
                default:
                    break;
            }
            Console.ForegroundColor = consoleColor; ;

            Console.WriteLine(message);

            Console.ForegroundColor = consoleOldColor;
        }
    }
}
