namespace wpf_advance.Core
{
    public interface ILogger
    {
        void Log(string message, LogFactoryLevel level);
    }
}
