using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            // UTF8 with BOM so Excel shows accents (é, è, ç...) correctly
            using (StreamWriter writer = new StreamWriter(file, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("Date,Prompt,Response"); // header row for Excel

                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToCsvLine());
                }
            }
            Console.WriteLine($"Journal saved to {file}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not save the file: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(file, Encoding.UTF8);
            List<Entry> loaded = new List<Entry>();

            // Start at 1 to skip the header row
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                List<string> parts = CsvHelper.ParseLine(lines[i]);
                if (parts.Count == 3)
                {
                    loaded.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }

            _entries = loaded; // replaces the current entries
            Console.WriteLine($"Journal loaded: {_entries.Count} entries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load the file: {ex.Message}");
        }
    }
}