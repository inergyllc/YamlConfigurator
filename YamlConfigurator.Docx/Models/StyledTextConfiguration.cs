namespace YamlConfigurator.Docx.Models;

/// <summary>
/// Represents a styled text with a value and a style.
/// </summary>
public class StyledTextConfiguration
{
    /// <summary>
    /// Gets or sets the text value.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the text style.
    /// </summary>
    public string Style { get; set; } = string.Empty;
}