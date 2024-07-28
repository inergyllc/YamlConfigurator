namespace YamlConfigurator.Files;

/// <summary>
/// Represents the configuration for a file.
/// </summary>
public class FileConfiguration
{
    private string _name = string.Empty;
    private string _type = string.Empty;
    private string _root = string.Empty;
    private string _extension = string.Empty;
    private string _folder = ".\\";

    /// <summary>
    /// Gets or sets the name of the file configuration.
    /// </summary>
    public string Name
    {
        get => _name;
        set => _name = value?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Gets or sets the type of the file.
    /// </summary>
    public string Type
    {
        get => _type;
        set => _type = value?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Gets or sets the root name of the file.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when root is null or whitespace.</exception>
    public string Root
    {
        get => _root;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Root cannot be null or whitespace.");
            }
            _root = value.Trim();
        }
    }

    /// <summary>
    /// Gets or sets the file extension.
    /// </summary>
    public string Extension
    {
        get => string.IsNullOrWhiteSpace(_extension) ? string.Empty : (_extension[0] == '.' ? _extension : "." + _extension);
        set => _extension = value?.Trim() ?? string.Empty;
    }

    /// <summary>
    /// Gets or sets the folder where the file will be saved.
    /// </summary>
    public string Folder
    {
        get => string.IsNullOrWhiteSpace(_folder) ? ".\\" : _folder;
        set => _folder = string.IsNullOrWhiteSpace(value) ? ".\\" : value.Trim();
    }

    /// <summary>
    /// Gets or sets a value indicating whether to add a timestamp to the file name.
    /// </summary>
    public bool? Timestamp { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to force overwrite the file if it exists.
    /// </summary>
    public bool? Force { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to append to the file if it exists.
    /// </summary>
    public bool? Append { get; set; }

    /// <summary>
    /// Gets the full file path based on the configuration properties.
    /// </summary>
    public string Path
    {
        get
        {
            // Combine folder, root, and extension to form the full path
            string fileName = Root;
            if (Timestamp.HasValue && Timestamp.Value)
            {
                fileName += $"_{DateTime.Now:yyyyMMddHHmmss}";
            }

            return System.IO.Path.Combine(Folder, fileName) + Extension;
        }
    }

    /// <summary>
    /// Ensures the file conditions such as force delete and folder creation are met.
    /// </summary>
    public void Condition()
    {
        // Ensure the folder exists
        if (!Directory.Exists(Folder))
        {
            Directory.CreateDirectory(Folder);
        }

        // Check if Force is false and file exists, throw an exception
        if (Force.HasValue && !Force.Value && File.Exists(Path))
        {
            throw new InvalidOperationException($"File {Path} already exists and Force not specified as true");
        }

        // Check if Force is true and delete the file if it exists
        if (Force.HasValue && Force.Value && File.Exists(Path))
        {
            File.Delete(Path);
        }
    }

    /// <summary>
    /// Returns the full file path when the object is used as a string.
    /// </summary>
    /// <returns>The full file path.</returns>
    public override string ToString()
    {
        return Path;
    }
}
