using System.Runtime;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }
    public override void RecordEvent()
    {
        _amountCompleted++;
        int earnedPoints = _points;
        if(_amountCompleted==_target)
        {
            earnedPoints +=_bonus;
            Console.WriteLine($"Bonus!  You earned an additional {_bonus} points!");
        }
        Console.WriteLine($"Congratulations!  You have earned {earnedPoints} points!");
    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()
    {
        return $"[] (_shortName) ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal: {_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus})";
    }
}