using IntegerCompressor.Codex;
using IntegerCompressor.Interfaces;
using IntegerCompressor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegerCompressor {
    public class Program {
        public static void Main(string[] args) {
            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetRequiredService<App>();
            app.Run(args);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) => {
                    services.AddSingleton<IIntegerProcessor, IntegerProcessor>();
                    services.AddSingleton<IFileHandler, FileHandler>();
                    services.AddSingleton<Base62>();
                    services.AddSingleton<App>();
                });
    }
}