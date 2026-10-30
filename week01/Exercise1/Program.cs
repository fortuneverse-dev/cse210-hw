using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lastname = Console.ReadLine();
        Console.WriteLine("");
        

        Console.WriteLine($"Your name is {lastname}, {firstname} {lastname}.");


    }
}