using System;

/*
 * EXCEEDING REQUIREMENTS
 
  1. CSV format: the journal is saved as a .csv file that opens directly in
 *    Excel, with a header row (Date, Prompt, Response).
 *
  2. Commas and quotation marks: every field is wrapped in quotes and any
 *    quote inside a response is doubled (" becomes ""), following the CSV
 *    standard. A response like: I ate rice, beans and "poulet"
 *    is saved and loaded back correctly. I wrote a separate class,
 *    CsvHelper, with an Escape method (for saving) and a ParseLine method
 *    (for loading, character by character).
 *
  3. Excel accents: the file is written in UTF-8 with a BOM so characters
 *    like é, è and ç display correctly in Excel.
 *
  4. Error handling: saving and loading use try/catch, and the current
 *    journal is only replaced when the file was read successfully.
 *
  5. The .csv extension is added automatically if the user forgets it.
 */
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();

                journal.AddEntry(new Entry(date, prompt, response));
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string file = AddCsvExtension(Console.ReadLine());
                journal.SaveToFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string file = AddCsvExtension(Console.ReadLine());
                journal.LoadFromFile(file);
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static string AddCsvExtension(string filename)
    {
        if (!filename.EndsWith(".csv"))
        {
            filename += ".csv";
        }
        return filename;
    }
}