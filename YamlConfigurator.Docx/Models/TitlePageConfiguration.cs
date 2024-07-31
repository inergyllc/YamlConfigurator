namespace YamlConfigurator.Docx.Models;

/// <summary>
/// Represents the title page configuration for a DOCX document.
/// </summary>
public class TitlePageConfiguration
{
    /// <summary>
    /// Gets or sets the title text and style for the title page.
    /// </summary>
    public StyledTextConfiguraton Title { get; set; } = new();
}
