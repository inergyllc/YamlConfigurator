namespace YamlConfigurator.Docx.Models;

/// <summary>
/// Represents the root configuration for DOCX documents.
/// </summary>
public class DocxConfiguration
{
    /// <summary>
    /// Gets or sets the list of DOCX document configurations.
    /// </summary>
    public List<DocConfiguration> Docs { get; set; } = [];

    /// <summary>
    /// Returns the DOCX document configuration by its name.
    /// </summary>
    /// <param name="name">The name of the document.</param>
    /// <returns>The DOCX document configuration with the specified name.</returns>
    public DocConfiguration GetDocByName(string name) => 
        Docs.FirstOrDefault(doc => doc.Name == name)
        ?? new();

    /// <summary>
    /// Returns the DOCX document configuration by its index.
    /// </summary>
    /// <param name="index">The index of the document.</param>
    /// <returns>The DOCX document configuration at the specified index.</returns>
    public DocConfiguration this[int index] => Docs[index];

    /// <summary>
    /// Returns the DOCX document configuration by its name.
    /// </summary>
    /// <param name="name">The name of the document.</param>
    /// <returns>The DOCX document configuration with the specified name.</returns>
    public DocConfiguration this[string name] => GetDocByName(name);
}