using System;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // Set up a random number generator
        Random numberGenerator = new Random();

        // Set the initial replay choice
        string playAgain = "yes";

        // Continue playing while the answer is yes
        while (playAgain == "yes")
        {
            // Generate a secret number between 1 and 100
            int secretNumber = numberGenerator.Next(1, 101);

            // Prepare the guess and attempt counter
            int playerGuess = -1;
            int guessCount = 0;

            // Continue until the player finds the secret number
            while (playerGuess != secretNumber)
            {
                Console.Write("What is your guess? ");
                playerGuess = int.Parse(Console.ReadLine());

                // Count each attempt
                guessCount++;

                // Check the player's answer
                if (playerGuess < secretNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (playerGuess > secretNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You found the magic number in {guessCount} guesses!");
                }
            }

            // Find out if the player wants another round
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().Trim().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}