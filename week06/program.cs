using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    protected Goal(string name)
    {
        Name = name;
        Points = 0;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract void DisplayStatus();
}

[Serializable]
public class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name) { }

    public override void RecordEvent()
    {
        IsComplete = true;
        Points += 1000;
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{(IsComplete ? "[X]" : "[ ]")} {Name}: {Points} points");
    }
}

[Serializable]
public class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name) { }

    public override void RecordEvent()
    {
        Points += 100;
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"[ ] {Name}: {Points} points (Eternal goals cannot be marked as complete)");
    }
}

[Serializable]
public class ChecklistGoal : Goal
{
    public int CompletionCount { get; private set; }
    public int TargetCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int targetCount, int bonusPoints) : base(name)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        CompletionCount++;
        Points += 50;
        if (CompletionCount == TargetCount)
        {
            Points += BonusPoints; 
            IsComplete = true;
        }
    }

    public override void DisplayStatus()
    {
        Console.WriteLine($"{(IsComplete ? "[X]" : "[ ]")} {Name}: Completed {CompletionCount}/{TargetCount} times, {Points} points");
    }
}

[Serializable]
public class User
{
    public List<Goal> Goals { get; private set; }
    public int Score { get; private set; }

    public User()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void CreateGoal(string type, string name, int targetCount = 0, int bonusPoints = 0)
    {
        Goal goal = type switch
        {
            "simple" => new SimpleGoal(name),
            "eternal" => new EternalGoal(name),
            "checklist" => new ChecklistGoal(name, targetCount, bonusPoints),
            _ => throw new ArgumentException("Invalid goal type.")
        };

        Goals.Add(goal);
    }

    public void RecordEvent(string name)
    {
        var goal = Goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.RecordEvent();
            Score += goal.Points;
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            goal.DisplayStatus();
        }
    }

    public void SaveProgress(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Create);
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, this);
    }

    public static User LoadProgress(string filePath)
    {
        using var stream = new FileStream(filePath, FileMode.Open);
        var formatter = new BinaryFormatter();
        return (User)formatter.Deserialize(stream);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        User user = new User();

        user.CreateGoal("simple", "Run a Marathon");
        user.CreateGoal("eternal", "Read Scriptures");
        user.CreateGoal("checklist", "Attend the Temple", 10, 500);

        user.RecordEvent("Run a Marathon");
        user.RecordEvent("Read Scriptures");
        user.RecordEvent("Attend the Temple");
        
        user.DisplayGoals();
        Console.WriteLine($"Total Score: {user.Score}");

        user.SaveProgress("userProgress.dat");
        User loadedUser = User.LoadProgress("userProgress.dat");
        loadedUser.DisplayGoals();
    }
}
