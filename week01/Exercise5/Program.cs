using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        // I display the welcome message
        DisplayWelcome();

        // I ask the user for their name and save the answer
        string userName = PromptUserName();

        // I ask the user for their favorite number
        int favoriteNumber = PromptUserNumber();

        // I calculate the square of the number entered by the user
        int squaredNumber = SquareNumber(favoriteNumber);

        // I display the final result
        DisplayResult(userName, squaredNumber);
    }

    // I display a welcome message to the user
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // I ask for the user's name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // I ask for the user's favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // I multiply the number by itself and return the result
    static int SquareNumber(int number)
    {
        int square = number * number;

        return square;
    }

    // I display the user's name and the squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    
    }
}