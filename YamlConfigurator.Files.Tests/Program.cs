using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Yaml;
using YamlConfigurator.Files;

namespace YamlConfigurator.Files.Tests
{
    class Program
    {
        static void Main()
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("appsettings.yaml", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddSingleton<IConfiguration>(configuration)
                .BuildServiceProvider();

            // Get a logger instance
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Get a specific file configuration (example: "results")
            var filesManagerConfig = configuration.GetFilesManagerConfiguration();
            var excelFileConfig = filesManagerConfig.GetFileByName("results");
            var journalFileConfig = filesManagerConfig.GetFileByName("journal");

            // Display the file configuration - INFORMATION LOGGER
            logger.LogInformation("INFO: File Configuration:");
            logger.LogInformation("INFO: Name: {value}", excelFileConfig.Name);
            logger.LogInformation("INFO: Type: {value}", excelFileConfig.Type);
            logger.LogInformation("INFO: Root: {value}", excelFileConfig.Root);
            logger.LogInformation("INFO: Extension: {value}", excelFileConfig.Extension);
            logger.LogInformation("INFO: Folder: {value}", excelFileConfig.Folder);
            logger.LogInformation("INFO: Timestamp: {value}", excelFileConfig.Timestamp);
            logger.LogInformation("INFO: Force: {value}", excelFileConfig.Force);
            logger.LogInformation("INFO: Append: {value}", excelFileConfig.Append);
            logger.LogInformation("INFO: Full Path: {value}", excelFileConfig.Path);
        }
    }
}
