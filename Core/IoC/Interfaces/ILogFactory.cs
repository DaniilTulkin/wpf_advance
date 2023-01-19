using System;
using System.Runtime.CompilerServices;

namespace wpf_advance.Core
{
    public interface ILogFactory
    {
        event Action<(string Message, LogFactoryLevel Level)> NewLog;
        LogFactoryLevel LogFactoryLevel { get; set; }
        bool IncludeLogOriginDetails { get; set; }
        void AddLogger(ILogger logger);
        void RemoveLogger(ILogger logger);
        void Log(string message,
                 LogFactoryLevel level = LogFactoryLevel.Informative,
                 [CallerMemberName] string origin = "",
                 [CallerFilePath] string filePath = "",
                 [CallerLineNumber] int lineNumber = 0);
    }
}
