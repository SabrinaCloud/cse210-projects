using System.Security;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    //Constructor
    public ReflectingActivity(string name, string description) : base (name, description)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    //Method to get a random promp from the list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    //Method to get a random question from the list
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    //Method to display reflective questions with paues in between
    public void DisplayQuestions()
    {
        int duration = GetDuration();
        int timePerQuestion = 5;  //Allocate 5 seconds per question fro simplicity
    

        //Loop through the time allocsted for the reflection activity
        while (duration>0)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner();
            duration -=timePerQuestion;
        }
    }
    //Main method to run the activity
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.WriteLine(GetRandomPrompt());
        ShowSpinner();

        DisplayQuestions();
        DisplayEndingMessage();
    }
}