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

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.\n");
        }

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

        public void ListGoalNames()  
        {
            for (int i = 0; i< _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].ShortName}");
            }
        }

        public void ListGoalDetails()
        {
            for (int i = 0; i< _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("Which type of goal would you like to create? ");

            string typeChoice = Console.ReadLine();
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1": // SimpleGoal
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2": // EternalGoal
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3": // ChecklistGoal
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
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(parts[4]);
                            var simpleGoal = new SimpleGoal(name, description, points);
                            if (isComplete) simpleGoal.RecordEvent();
                            _goals.Add(simpleGoal);
                            break;

                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;

                        case "ChecklistGoal":
                            int amountCompleted = int.Parse(parts[4]);
                            int target = int.Parse(parts[5]);
                            int bonus = int.Parse(parts[6]);
                            var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                            for (int i = 0; i < amountCompleted; i++) checklistGoal.RecordEvent();
                            _goals.Add(checklistGoal);
                            break;
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