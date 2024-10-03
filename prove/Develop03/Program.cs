using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son");
        while(true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            if(scripture.IsCompletelyHidden())
            {
                break;
            }
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower()== "quit")
            {
                break;
            }
            scripture.HideRandomWords(3);
        }
    }
}