using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();
    private int _lastIndex = -1;

    public ScriptureLibrary(string filePath)
    {
        LoadFromFile(filePath);

        // Fallback so the program still works if the file is missing or empty
        if (_scriptures.Count == 0)
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            _scriptures.Add(new Scripture(reference, text));
        }
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);

        // Avoid showing the same scripture twice in a row when possible
        while (_scriptures.Count > 1 && index == _lastIndex)
        {
            index = _random.Next(_scriptures.Count);
        }

        _lastIndex = index;
        Scripture scripture = _scriptures[index];
        scripture.Reset();
        return scripture;
    }

    private void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            Scripture scripture = ParseLine(line);
            if (scripture != null)
            {
                _scriptures.Add(scripture);
            }
        }
    }

    // Parses a line like "Proverbs 3:5-6|Trust in the Lord..."
    private Scripture ParseLine(string line)
    {
        string[] parts = line.Split('|', 2);
        if (parts.Length != 2)
        {
            return null;
        }

        string referenceText = parts[0].Trim();
        string text = parts[1].Trim();

        // Book names can contain spaces (e.g. "1 Nephi"), so split at the last space
        int lastSpace = referenceText.LastIndexOf(' ');
        if (lastSpace < 0 || text == "")
        {
            return null;
        }

        string book = referenceText.Substring(0, lastSpace);
        string[] chapterAndVerses = referenceText.Substring(lastSpace + 1).Split(':');
        if (chapterAndVerses.Length != 2 || !int.TryParse(chapterAndVerses[0], out int chapter))
        {
            return null;
        }

        string[] verses = chapterAndVerses[1].Split('-');
        if (!int.TryParse(verses[0], out int startVerse))
        {
            return null;
        }

        Reference reference;
        if (verses.Length == 1)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else if (verses.Length == 2 && int.TryParse(verses[1], out int endVerse))
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            return null;
        }

        return new Scripture(reference, text);
    }
}