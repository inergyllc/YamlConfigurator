using Microsoft.Extensions.Configuration;

namespace YamlConfigurator.Files;

public static class ConfigurationExtensions
{
    public static FilesManagerConfiguration GetFilesManagerConfiguration(this IConfiguration configuration)
    {
        var filesManagerConfig = configuration.GetSection("fileManager").Get<FilesManagerConfiguration>() 
            ?? new();
        foreach (var fileConfig in filesManagerConfig.Files)
        {
            fileConfig.Timestamp ??= filesManagerConfig.Timestamp;
            fileConfig.Force ??= filesManagerConfig.Force;
            fileConfig.Append ??= filesManagerConfig.Append;
        }
        return filesManagerConfig;
    }
}
