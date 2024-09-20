using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain.ToLower()=="yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int attempts=0; //Tracing gusses number
            int guess = -1;
            while (guess != magicNumber)
            {   
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                 else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it!  It took you {attempts} guesses.");
                }
            }
        Console.Write("Do you want to play again? (yes or no): ");
        playAgain = Console.ReadLine();
        }
    }
}