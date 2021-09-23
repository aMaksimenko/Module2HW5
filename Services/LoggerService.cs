using System;
using System.IO;
using HomeWork.Models;
using HomeWork.Models.Enums;
using HomeWork.Providers.Abstractions;
using HomeWork.Services.Abstractions;

namespace HomeWork.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private readonly LoggerConfig _loggerConfig;

        public LoggerService(
            IFileService fileService,
            IConfigProvider configProvider)
        {
            _fileService = fileService;
            _loggerConfig = configProvider.GetConfig().Logger;
        }

        ~LoggerService()
        {
            _fileService.Close(StreamWriter);
        }

        private StreamWriter StreamWriter { get; set; }

        public void LogError(string message)
        {
            Log(message, LogType.Error);
        }

        public void LogInfo(string message)
        {
            Log(message, LogType.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogType.Warning);
        }

        public void SetOutput(string filePath)
        {
            _fileService.Create(filePath);
            StreamWriter = new StreamWriter(filePath, true, System.Text.Encoding.Default);
        }

        private void Log(string message, LogType logType)
        {
            var logItem = $"{DateTime.UtcNow.ToString(_loggerConfig.TimeFormat)}: {logType.ToString()}: {message}";

            Console.WriteLine(logItem);
            Write(logItem);
        }

        private void Write(string logItem)
        {
            _fileService.Write(StreamWriter, logItem);
        }
    }
}