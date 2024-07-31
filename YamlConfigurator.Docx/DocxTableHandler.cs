using System;
using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace YamlConfigurator.Docx;

public static class DocxTableHandler
{
    /// <summary>
    /// Creates a table based on the given list of tuples.
    /// </summary>
    /// <param name="document">The DocX document where the table will be added.</param>
    /// <param name="data">The list of tuples containing the table data.</param>
    /// <returns>The created table.</returns>
    public static Table CreateTable(DocX document, List<Tuple<string, object>> data)
    {
        if (data == null || data.Count == 0)
            throw new ArgumentException("Data cannot be null or empty", nameof(data));

        // Determine the number of columns
        int columns = data[0].Item2 is IList<object> list
            ? list.Count
            : throw new ArgumentException("Each tuple's second item must be a list of objects");

        // Create a table with the determined number of columns and rows
        var table = document.AddTable(data.Count + 1, columns);

        // Set widths for the columns (example fixed width for simplicity)
        float[] widths = new float[columns];
        for (int i = 0; i < columns; i++)
        {
            widths[i] = 200f; // Adjust width as needed
        }
        table.SetWidths(widths);

        // Fill in the header
        for (int i = 0; i < columns; i++)
        {
            // First tuple contains headers
            table.Rows[0].Cells[i].Paragraphs[0].Append(data[0].Item1).Bold();
        }

        // Fill in the data
        for (int i = 0; i < data.Count; i++)
        {
            var rowData = (IList<object>)data[i].Item2;
            for (int j = 0; j < columns; j++)
            {
                table.Rows[i + 1].Cells[j].Paragraphs[0].Append(rowData[j].ToString());
            }
        }

        return table;
    }
}
