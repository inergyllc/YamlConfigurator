using Microsoft.Extensions.Configuration;
using YamlConfigurator.Docx.Models;

namespace YamlConfigurator.Docx;

/// <summary>
/// Extension methods for the IConfiguration interface to handle DOCX configurations.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Loads the DOCX configuration from a YAML file.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <returns>The DOCX configuration.</returns>
    public static DocxConfiguration 
        GetDocxConfiguration(this IConfiguration configuration)
    {
        return configuration
            .GetSection("docx")
            .Get<DocxConfiguration>() 
            ?? new();
    }

    /// <summary>
    /// Returns the DOCX configuration.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <returns>The DOCX configuration.</returns>
    public static DocxConfiguration Docx(this IConfiguration configuration) 
        => configuration
            .GetDocxConfiguration();

    /// <summary>
    /// Returns the list of DOCX document configurations.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <returns>The list of DOCX document configurations.</returns>
    public static DocConfiguration[] Docs(this IConfiguration configuration) => configuration.Docx().Docs.ToArray();

    /// <summary>
    /// Returns the document configuration by its name.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <param name="name">The name of the document.</param>
    /// <returns>The document configuration with the specified name.</returns>
    public static DocConfiguration GetDocByName(
            this IConfiguration configuration, string 
            name) 
        => configuration
            .Docx()
            .GetDocByName(name);

    /// <summary>
    /// Returns the part configuration by document name and part name.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <param name="docName">The name of the document.</param>
    /// <param name="partName">The name of the part.</param>
    /// <returns>The part configuration with the specified document and part names.</returns>
    public static PartConfiguration GetPart(
            this IConfiguration configuration, 
            string docName, string partName) 
        => configuration
            .GetDocByName(docName)?
            .GetPartByName(partName) 
            ?? new();

    /// <summary>
    /// Returns the title page configuration by document name.
    /// </summary>
    /// <param name="configuration">The IConfiguration instance.</param>
    /// <param name="docName">The name of the document.</param>
    /// <returns>The title page configuration with the specified document name.</returns>
    public static TitlePageConfiguration GetTitlePage(
            this IConfiguration configuration, 
            string docName) 
        => configuration
            .GetDocByName(docName)?
            .TitlePage 
            ?? new();
}
