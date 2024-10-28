using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 10,28), 10, 1.4),
            new Cycling(new DateTime(2024, 10, 18), 10, 5),
            new Swimming(new DateTime(2024, 10,05), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

    }
}