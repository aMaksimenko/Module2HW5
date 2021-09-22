namespace HomeWork.Services.Abstractions
{
    public interface ILoggerService
    {
        public void LogError(string message);
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void SetOutput(string filePath);
    }
}