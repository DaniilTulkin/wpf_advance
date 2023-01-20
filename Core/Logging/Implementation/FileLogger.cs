using Core;
using System;

namespace wpf_advance.Core
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; }
        public bool LogTime { get; set; } = true;

        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        public void Log(string message, LogFactoryLevel level)
        {
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");
            var timeLogString = LogTime ? $"[{currentTime}] " : "";
            IoC.File.WriteAllTextToFileAsync($"{timeLogString}{message}\n", FilePath, true);
        }
    }
}
