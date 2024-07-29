using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Yaml;

namespace YamlConfigurator.Files;
public static class ConfigurationHelper
{

    /// <summary>
    /// If no file specified.
    /// </summary>
    public const string DEFAULT_APPSETTINGS_FILENAME = "appsettings.yaml";

    private static string? _basePath;
    /// <summary>
    /// Base path to configuration files
    /// </summary>
    public static string BasePath
    {
        get => _basePath ??= Directory.GetCurrentDirectory();
        set => _basePath = value;
    }

    /// <summary>
    /// BUild the YAML configuration
    /// </summary>
    /// <param name="basePath">Configuration file folder (default: Current Directory)</param>
    /// <param name="yamlFileName">Name of configuration file (default: appsettings.yaml)</param>
    /// <returns></returns>
    public static IConfiguration BuildConfiguration(
        string? basePath = null, 
        string yamlFileName = DEFAULT_APPSETTINGS_FILENAME)
    {
        var configurationBuilder = new ConfigurationBuilder();

        if (!string.IsNullOrEmpty(basePath))
        {
            configurationBuilder.SetBasePath(basePath);
        }
        else
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        }

        configurationBuilder.AddYamlFile(yamlFileName, optional: false, reloadOnChange: true);

        return configurationBuilder.Build();
    }
}
