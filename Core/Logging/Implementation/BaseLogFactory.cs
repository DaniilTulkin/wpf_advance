using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace wpf_advance.Core
{
    public class BaseLogFactory : ILogFactory
    {
        protected List<ILogger> loggers = new List<ILogger>();
        protected object loggerLock = new object();
        public event Action<(string Message, LogFactoryLevel Level)> NewLog = (details) => { };
        public LogFactoryLevel LogFactoryLevel { get; set; }
        public bool IncludeLogOriginDetails { get; set; } = true;

        public BaseLogFactory(ILogger[] loggers = null)
        {
            AddLogger(new ConsoleLogger());

            if (loggers != null)
                foreach (var logger in loggers)
                    AddLogger(logger);
        }

        public void AddLogger(ILogger logger)
        {
            lock (loggerLock)
            {
                if (!loggers.Contains(logger))
                    loggers.Add(logger);
            }
        }
        public void Log(string message, 
                        LogFactoryLevel level = LogFactoryLevel.Informative,
                        [CallerMemberName] string origin = "",
                        [CallerFilePath] string filePath = "", 
                        [CallerLineNumber] int lineNumber = 0)
        {
            if (IncludeLogOriginDetails)
                message = $"{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}\n{message}";

            loggers.ForEach(logger => logger.Log(message, level));
            NewLog.Invoke((message, level));
        }
        public void RemoveLogger(ILogger logger)
        {
            lock (loggerLock)
            {
                if (loggers.Contains(logger))
                    loggers.Remove(logger);
            }
        }
    }
}
