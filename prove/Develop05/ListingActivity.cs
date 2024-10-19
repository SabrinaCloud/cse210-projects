using System.Reflection.Metadata.Ecma335;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;
    
    public ListingActivity(string name, string description):base (name, description)
    {
        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    //Method to get a list of responses from the user
    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        Console.WriteLine($"Start listing items.  Type'done' when you are finished.");
        
        while(true)
        {
            string response = Console.ReadLine();
            if (response.ToLower()=="done")
            {
                break;
            }
            userList.Add(response);  //Add the response to the list
        }
        return userList;
    }

    //main method to run the activity
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();

        //Display a random prompt and ask the user to list items.
        Console.WriteLine(GetRandomPrompt());
        ShowCountDown(3);  //Countdown before starting the listing

        List<string> userResponses = GetListFromUser();
        _count = userResponses.Count;  //Store the number of items listed by user

        //Display how many items the user listed
        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
    }
}