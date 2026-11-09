using System.Collections.Generic;
using System.Text;

public static class CsvHelper
{
    // Wraps a value in quotes and doubles any quote inside it
    public static string Escape(string value)
    {
        if (value == null)
        {
            value = "";
        }

        string escaped = value.Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }

    // Splits one CSV line into its fields, respecting quotes and commas
    public static List<string> ParseLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (insideQuotes)
            {
                if (c == '"')
                {
                    // Two quotes in a row = one real quote character
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        insideQuotes = false; // closing quote
                    }
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    insideQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }

        fields.Add(current.ToString()); // last field
        return fields;
    }
}