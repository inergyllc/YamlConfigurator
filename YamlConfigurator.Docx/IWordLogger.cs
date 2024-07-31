namespace YamlComparison.Docx;

/// <summary>
/// Interface for the Word Logger interface
/// </summary>
public interface IWordLogger
{
    /// <summary>
    /// This document is a singleton. This starts it up.
    /// </summary>
    /// <param name="title">Title in the document</param>
    void InitializeDocument(string title);

    /// <summary>
    /// Append log message - Future - Grow this for each content type
    /// </summary>
    /// <param name="logMessage">Message to push to the word document</param>
    void AppendLog(string logMessage);

    /// <summary>
    /// Adds a summary table to the document.
    /// </summary>
    /// <param name="questionsCount">The count of questions</param>
    void AddSummaryTable(int questionsCount);

    /// <summary>
    /// Adds a table of questions to the document.
    /// </summary>
    /// <param name="questions">List of questions to add</param>
    void AddQuestionsTable(List<(string Category, string Subcategory, string Prompt)> questions);

    /// <summary>
    /// Writes a section to the document based on the section name.
    /// </summary>
    /// <param name="sectionName">Name of the section to write</param>
    void WriteSection(string sectionName);

    /// <summary>
    /// Adds a dynamic table to the document based on a list of tuples.
    /// </summary>
    /// <param name="data">The list of tuples containing the table data</param>
    void AddDynamicTable(List<Tuple<string, List<object>>> data);
}
