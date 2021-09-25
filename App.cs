using System;
using System.IO;
using HomeWork.Helpers;
using HomeWork.Providers.Abstractions;
using HomeWork.Services.Abstractions;

namespace HomeWork
{
    public class App
    {
        private const int MethodsCount = 3;
        private readonly ILoggerService _loggerService;
        private readonly Actions _actions;
        private readonly IConfigProvider _configProvider;
        private readonly Random _random;

        public App(
            IConfigProvider configProvider,
            ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _configProvider = configProvider;
            _random = new Random();
            _actions = new Actions(_loggerService);

            PrepareFiles();
        }

        public void Run(int countCycles = 100)
        {
            CallRandomMethods(countCycles);
        }

        private void PrepareFiles()
        {
            var loggerConfig = _configProvider.GetConfig().Logger;
            var dirInfo = new DirectoryInfo(loggerConfig.DirectoryPath);
            var filesLimit = loggerConfig.FilesLimit;
            var dirPath = loggerConfig.DirectoryPath;
            var fileTitle = DateTime.UtcNow.ToString(loggerConfig.FileNameFormat);
            var extension = loggerConfig.FileExtension;
            var filePath = $"{dirPath}{fileTitle}{extension}";

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            else
            {
                var files = Directory.GetFiles(loggerConfig.DirectoryPath);

                while (files.Length > filesLimit)
                {
                    Array.Sort(files, new FileComparer());
                    var fileInfo = new FileInfo(files[0]);

                    fileInfo.Delete();
                    files = Directory.GetFiles(loggerConfig.DirectoryPath);
                }
            }

            _loggerService.SetOutput(filePath);
        }

        private void CallRandomMethods(int countCycles)
        {
            for (var i = 0; i < countCycles; i++)
            {
                var nextMethodIndex = _random.Next(MethodsCount);

                try
                {
                    switch (nextMethodIndex)
                    {
                        case 0:
                            _actions.MethodOne();
                            break;
                        case 1:
                            _actions.MethodTwo();
                            break;
                        case 2:
                            _actions.MethodThree();
                            break;
                    }
                }
                catch (BusinessException e)
                {
                    _loggerService.LogWarning($"Action got this custom Exception: {e.Message}");
                }
                catch (Exception e)
                {
                    _loggerService.LogError($"Action failed by reason: {e}");
                }
            }
        }
    }
}