using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Yaml;

using YamlConfigurator.Files;

namespace YamlConfigurator.Files.Tests;

class Program
{
    static void Main(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddYamlFile("appsettings.yaml", optional: false, reloadOnChange: true)
            .Build();

        // Setup dependency injection
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .BuildServiceProvider();

        // Get a specific file configuration (example: "results")
        var filesManagerConfig = configuration.GetFilesManagerConfiguration();
        var fileConfig = filesManagerConfig.GetFileByName("results");

        // Display the file configuration
        Console.WriteLine("File Configuration:");
        Console.WriteLine($"Name: {fileConfig.Name}");
        Console.WriteLine($"Type: {fileConfig.Type}");
        Console.WriteLine($"Root: {fileConfig.Root}");
        Console.WriteLine($"Extension: {fileConfig.Extension}");
        Console.WriteLine($"Folder: {fileConfig.Folder}");
        Console.WriteLine($"Timestamp: {fileConfig.Timestamp}");
        Console.WriteLine($"Force: {fileConfig.Force}");
        Console.WriteLine($"Append: {fileConfig.Append}");
        Console.WriteLine($"Full Path: {fileConfig.Path}");
    }
}
