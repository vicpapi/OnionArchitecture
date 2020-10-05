namespace Onion.Core.Interfaces.Repository
{
    public interface ILoggingRepository
    {
        void LogInfo(string message);

        void LogDebug(string message);

        void LogWarn(string message);

        void LogError(string message);

        void LogFatal(string message);  
    }
}
