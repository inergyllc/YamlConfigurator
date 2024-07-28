using System;
using System.Collections.Generic;
using System.Linq;
using YamlConfigurator.Files;

namespace YamlConfigurator.Files;

/// <summary>
/// Represents the configuration for the file manager.
/// </summary>
public class FilesManagerConfiguration
{
    /// <summary>
    /// Gets or sets the default folder for files.
    /// </summary>
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether to add a timestamp to the file name by default.
    /// Default = false
    /// </summary>
    public bool? Timestamp { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to force overwrite files by default.
    /// Default = true
    /// </summary>
    public bool? Force { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to append to files by default.
    /// Default = false
    /// </summary>
    public bool? Append { get; set; } = false;

    /// <summary>
    /// Gets or sets the list of file configurations.
    /// </summary>
    public List<FileConfiguration> Files { get; set; } = [];

    /// <summary>
    /// Gets the file configuration by name.
    /// </summary>
    /// <param name="name">The name of the file configuration.</param>
    /// <returns>The file configuration with the specified name.</returns>
    public FileConfiguration GetFileByName(string name)
    {
        var fileConfig = Files.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (fileConfig != null)
        {
            return fileConfig;
        }
        else
        {
            throw new KeyNotFoundException($"File configuration with name '{name}' not found.");
        }
    }

    /// <summary>
    /// Gets the file configuration by index.
    /// </summary>
    /// <param name="index">The index of the file configuration.</param>
    /// <returns>The file configuration at the specified index.</returns>
    public FileConfiguration GetFileByIndex(int index)
    {
        if (index < 0 || index >= Files.Count)
        {
            throw new IndexOutOfRangeException($"Index '{index}' is out of range.");
        }
        return Files[index];
    }

    /// <summary>
    /// Indexer to get file configuration by name.
    /// </summary>
    /// <param name="name">The name of the file configuration.</param>
    /// <returns>The file configuration with the specified name.</returns>
    public FileConfiguration this[string name] => GetFileByName(name);

    /// <summary>
    /// Indexer to get file configuration by index.
    /// </summary>
    /// <param name="index">The index of the file configuration.</param>
    /// <returns>The file configuration at the specified index.</returns>
    public FileConfiguration this[int index] => GetFileByIndex(index);
}
