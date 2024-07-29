using Microsoft.Extensions.Configuration;
using YamlConfigurator.Files.Models;

namespace YamlConfigurator.Files;

/// <summary>
/// Extension methods for the IConfiguration interface to handle file manager configurations.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Retrieves the file manager configuration from the application's configuration.
    /// </summary>
    /// <param name="configuration">The configuration interface.</param>
    /// <returns>The populated FilesManagerConfiguration object.</returns>
    public static FilesManagerConfiguration GetFilesManagerConfiguration
        (this IConfiguration configuration)
    {
        // Retrieve the "fileManager" section from the configuration and bind it to a FilesManagerConfiguration object.
        var filesManagerConfig = configuration.GetSection("fileManager").Get<FilesManagerConfiguration>()
            ?? new FilesManagerConfiguration();

        // Iterate through each file configuration within the FilesManagerConfiguration.
        filesManagerConfig.Files = filesManagerConfig.Files
            .Select(fileConfig =>
            {
                fileConfig.Timestamp ??= filesManagerConfig.Timestamp;
                fileConfig.Force ??= filesManagerConfig.Force;
                fileConfig.Append ??= filesManagerConfig.Append;
                return fileConfig;
            }).ToList();

        // Return the fully populated FilesManagerConfiguration object.
        return filesManagerConfig;
    }
}
