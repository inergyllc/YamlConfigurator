namespace YamlConfigurator.Docx.Models;

/// <summary>
/// Represents a single part of a DOCX document.
/// </summary>
public class PartConfiguration
{
    /// <summary>
    /// Gets or sets the name of the part.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title text and style for the part.
    /// </summary>
    public StyledTextConfiguration Title { get; set; } = new();

    /// <summary>
    /// Gets or sets the text content and style for the part.
    /// </summary>
    public StyledTextConfiguration Text { get; set; } = new();
}