namespace YamlConfigurator.Docx.Models;

// <summary>
/// Represents a single DOCX document configuration.
/// </summary>
public class DocConfiguration
{
    /// <summary>
    /// Gets or sets the name of the document.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the file identifier of the document.
    /// </summary>
    public string FileId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title page configuration for the document.
    /// </summary>
    public TitlePageConfiguration TitlePage { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of parts for the document.
    /// </summary>
    public List<PartConfiguration> Parts { get; set; } = [];

    /// <summary>
    /// Returns the part configuration by its name.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <returns>The part configuration with the specified name.</returns>
    public PartConfiguration GetPartByName(string name) => Parts.FirstOrDefault(part => part.Name == name);

    /// <summary>
    /// Returns the part configuration by its index.
    /// </summary>
    /// <param name="index">The index of the part.</param>
    /// <returns>The part configuration at the specified index.</returns>
    public PartConfiguration this[int index] => Parts[index];

    /// <summary>
    /// Returns the part configuration by its name.
    /// </summary>
    /// <param name="name">The name of the part.</param>
    /// <returns>The part configuration with the specified name.</returns>
    public PartConfiguration this[string name] => GetPartByName(name);

}