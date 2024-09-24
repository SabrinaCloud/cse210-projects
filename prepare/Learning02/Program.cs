using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1= new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2009;
        job1._endYear =2018;

        Job job2= new Job();
        job2._jobTitle = "Sales Manager";
        job2._company = "Apple";
        job2._startYear = 2011;
        job2._endYear =2020;

        //Create Resume object and set up name and work experience
        Resume myResume = new Resume();
        myResume._name="Sabrina";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        //Console.WriteLine($"First job title: {myResume._jobs[0]._jobTitle}");
        myResume.Diaplay();
    }
}