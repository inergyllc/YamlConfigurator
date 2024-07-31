namespace YamlConfigurator.Docx.Models;

/// <summary>
/// Represents a styled text with a value and a style.
/// </summary>
public class StyledText
{
    /// <summary>
    /// Gets or sets the value of the text.
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the style used for the text.
    /// </summary>
    public string Style { get; set; } = "Normal";
}
