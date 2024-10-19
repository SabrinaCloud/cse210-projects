public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {

    }
    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();

        int duration = GetDuration();
        int inhaleTime = 5; // Time max breath in
        int exhaleTime = 5; // Time max breath out

        //adjust duration
        if (duration < 12)
        {
            inhaleTime = duration / 2;
            exhaleTime = duration / 2;
        }

        int cycles = duration / (inhaleTime + exhaleTime); // number of cicles (calculate)

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(inhaleTime); // breath in time calculated

            Console.Write("Now Breathe out... ");
            ShowCountDown(exhaleTime); //  breath out time calculated
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }




}
