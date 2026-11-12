using System;
using System.IO;
/*
 * EXCEEDING REQUIREMENTS
 * Beyond the core requirements, this program also:
 *  1. Loads scriptures from an external file (scriptures.txt). Each line uses the
 *     format "Reference|Text" and supports single verses and ranges. If the file is
 *     missing or empty, a built-in scripture is used so the program never crashes.
 *  2. Picks a random scripture from the file, and avoids repeating the same one twice in a row.
 *  3. Only hides words that are not already hidden (the stretch challenge), so every
 *     Enter press makes progress.
 *  4. Lets the user choose a difficulty (2, 3, or 5 words hidden per round).
 *  5. Shows the percentage of words hidden after each round.
 *  6. Adds extra commands: "reset" shows all words again, and "new" loads another scripture.
 *  7. Uses a separate ScriptureLibrary class to keep file loading and parsing out of
 *     Program, following the principles of encapsulation.
 */

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        
        string filePath = Path.Combine(AppContext.BaseDirectory, "scriptures.txt");
        ScriptureLibrary library = new ScriptureLibrary(filePath);

        int wordsPerRound = AskWordsPerRound();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"Hidden: {scripture.GetPercentHidden()}%");

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press enter to continue, or type 'quit', 'reset', or 'new': ");
            string input = (Console.ReadLine() ?? "").Trim().ToLower();

            if (input == "quit")
            {
                break;
            }
            else if (input == "reset")
            {
                scripture.Reset();
            }
            else if (input == "new")
            {
                scripture = library.GetRandomScripture();
            }
            else
            {
                scripture.HideRandomWords(wordsPerRound);
            }
        }
    }

    static int AskWordsPerRound()
    {
        Console.Clear();
        Console.WriteLine("Choose a difficulty:");
        Console.WriteLine("1. Easy   (hide 2 words per round)");
        Console.WriteLine("2. Medium (hide 3 words per round)");
        Console.WriteLine("3. Hard   (hide 5 words per round)");

        while (true)
        {
            Console.Write("Your choice (1-3): ");
            string choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "1") return 2;
            if (choice == "2") return 3;
            if (choice == "3") return 5;

            Console.WriteLine("Please enter 1, 2, or 3.");
        }
    }
}
    
    







