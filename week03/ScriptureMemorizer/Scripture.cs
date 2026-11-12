using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Stretch challenge: choose only from words that are still visible
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        int count = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
    public void Reset()
{
    foreach (Word word in _words)
    {
        word.Show();
    }
}

public int GetPercentHidden()
{
    int hiddenCount = _words.Count(w => w.IsHidden());
    return (int)Math.Round(100.0 * hiddenCount / _words.Count);
}

}

