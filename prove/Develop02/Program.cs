using System;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        string userInput = "";
        while (userInput !="5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose and option: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(date, prompt, response);
                    myJournal.AddEntry(newEntry);
                    break;
                case "2":
                    myJournal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the filename to save to:");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter the file to load from:");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;
                case "5":
                    Console.WriteLine("Exiting the journal.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}