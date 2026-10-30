using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        
        Console.WriteLine("Enter a list of  numbers, type 0 when finished. ");
    {
        // I created a list to store the numbers entered by the user
        List<int> numbers = new List<int>();

        int userNumber = -1;

        // I keep asking the user for numbers until they enter 0
        while (userNumber != 0)
        

        {
            Console.Write("Enter a number: ");
            userNumber = int.Parse(Console.ReadLine());

            // I only add the number to my list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // I calculate the total of all the numbers in my list
        int total = 0;

        foreach (int number in numbers)
        {
            total += number;
        }

        Console.WriteLine($"The sum is: {total}");

        // I calculate the average by dividing the total by the number of items
        double average = (double)total / numbers.Count;

        Console.WriteLine($"The average is: {average}");

        // I find the largest number in my list
        int largestNumber = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largestNumber)
            {
                largestNumber = number;
            }
        }

        Console.WriteLine($"The largest number is: {largestNumber}");
    }
    }
}