using HomeWork.Models;
using HomeWork.Providers.Abstractions;
using HomeWork.Services.Abstractions;
using Newtonsoft.Json;

namespace HomeWork.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private const string ConfigPath = "config.json";
        private readonly IFileService _fileService;

        public ConfigProvider(IFileService fileService)
        {
            _fileService = fileService;
            Config = LoadFromFile();
        }

        private Config Config { get; init; }

        public Config GetConfig()
        {
            return Config;
        }

        private Config LoadFromFile()
        {
            var configFile = _fileService.Read(ConfigPath);

            return JsonConvert.DeserializeObject<Config>(configFile);
        }
    }
}