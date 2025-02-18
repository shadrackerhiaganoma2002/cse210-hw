using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    protected DateTime date;
    protected int duration; // duration in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    
    public string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({duration} min): " +
               $"Distance {GetDistance()} units, Speed: {GetSpeed()} units/h, Pace: {GetPace()} min/unit";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / duration) * 60; // mph

    public override double GetPace() => duration / distance; // min/mile
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed * duration) / 60; // miles

    public override double GetSpeed() => speed; // mph

    public override double GetPace() => 60 / speed; // min/mile
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance() => (laps * 50) / 1000.0; // in km

    public override double GetSpeed() => (GetDistance() / duration) * 60; // kph

    public override double GetPace() => duration / GetDistance(); // min/km
}

// Program to demonstrate the functionality
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0), // 3 miles run
            new Cycling(new DateTime(2022, 11, 5), 45, 15.0), // 15 mph cycling
            new Swimming(new DateTime(2022, 11, 7), 30, 20) // 20 laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
