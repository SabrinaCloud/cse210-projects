using System;
public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    public void Diaplay()
    {
        Console.WriteLine($"Resume of : {_name}");
        Console.WriteLine("Jobs:");

        //show each job
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}