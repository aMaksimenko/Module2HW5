using HomeWork.Providers;
using HomeWork.Providers.Abstractions;
using HomeWork.Services;
using HomeWork.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork
{
    public class Starter
    {
        public void Run()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IConfigProvider, ConfigProvider>()
                .AddSingleton<ILoggerService, LoggerService>()
                .AddTransient<Actions>()
                .AddTransient<App>()
                .BuildServiceProvider();
            var app = serviceProvider.GetService<App>();

            app?.Run();
        }
    }
}