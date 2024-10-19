using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1.Breathing Activity");
            Console.WriteLine("2.Reflecting Activity");
            Console.WriteLine("3.Listing Activity");
            Console.WriteLine("4.Quit");
            Console.Write("Select a choice from the menu:");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.");
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflection = new ReflectingActivity("Reflecting Activity", "This activity will help you reflec on times when you show strength and resilience.");
                reflection.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity("Listing Activity", "This activity will help you reflec on the positive aspects of your life.");
                listing.Run();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }  
    }
}