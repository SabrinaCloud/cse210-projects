using System;
using System.Collections.Generic;
using System.IO;

namespace YourNamespace
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        // Display player information
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.\n");
        }

        // Start the menu loop
        public void Start()
        {
            while (true)
            {
                DisplayPlayerInfo();

                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalDetails();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        // List each goal's name
        public void ListGoalNames()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
            }
        }

        // Display details for each goal
        public void ListGoalDetails()
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        // Create a new goal based on user input
        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");

            string typeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is the short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        // Record an event for a specified goal
        public void RecordEvent()
        {
            ListGoalNames();

            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                _goals[goalIndex].RecordEvent();
                _score += _goals[goalIndex].Points;
                Console.WriteLine($"You now have {_score} points.");
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        // Save the goals to a file
        public void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }

        // Load goals from a file
        public void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                _goals.Clear();
                foreach (string line in File.ReadLines(filename))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length < 4) continue;

                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    if (!int.TryParse(parts[3], out int points)) continue;

                    if (type == "SimpleGoal" && parts.Length >= 5 && bool.TryParse(parts[4], out bool isComplete))
                    {
                        var simpleGoal = new SimpleGoal(name, description, points);
                        if (isComplete) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                    }
                    else if (type == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "ChecklistGoal" && parts.Length >= 7 && int.TryParse(parts[4], out int amountCompleted)
                             && int.TryParse(parts[5], out int target) && int.TryParse(parts[6], out int bonus))
                    {
                        var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int i = 0; i < amountCompleted; i++) checklistGoal.RecordEvent();
                        _goals.Add(checklistGoal);
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}