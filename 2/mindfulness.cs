using System;  
using System.Collections.Generic;  
using System.Threading;  

class Program  
{  
    static void Main(string[] args)  
    {  
        MindfulnessApp app = new MindfulnessApp();  
        app.Start();  
    }  
}  

class MindfulnessApp  
{  
    public void Start()  
    {  
        while (true)  
        {  
            Console.Clear();  
            Console.WriteLine("Welcome to the Mindfulness App!");  
            Console.WriteLine("Select an activity:");  
            Console.WriteLine("1. Breathing Activity");  
            Console.WriteLine("2. Reflection Activity");  
            Console.WriteLine("3. Listing Activity");  
            Console.WriteLine("4. Exit");  

            string choice = Console.ReadLine();  

            if (choice == "1")  
            {  
                BreathingActivity breathing = new BreathingActivity();  
                breathing.StartActivity();  
            }  
            else if (choice == "2")  
            {  
                ReflectionActivity reflection = new ReflectionActivity();  
                reflection.StartActivity();  
            }  
            else if (choice == "3")  
            {  
                ListingActivity listing = new ListingActivity();  
                listing.StartActivity();  
            }  
            else if (choice == "4")  
            {  
                break;  
            }  
            else  
            {  
                Console.WriteLine("Invalid choice. Please try again.");  
            }  
        }  
    }  
}  

abstract class MindfulnessActivity  
{  
    protected int duration;  

    protected void StartMessage(string activityName, string description)  
    {  
        Console.Clear();  
        Console.WriteLine($"{activityName}\n{description}");  
        Console.Write("Enter duration in seconds: ");  
        duration = int.Parse(Console.ReadLine());  
        Console.WriteLine("Get ready...");  
        Pause(3);  
    }  

    protected void EndMessage(string activityName)  
    {  
        Console.WriteLine($"Well done! You've completed the {activityName} for {duration} seconds.");  
        Pause(3);  
    }  

    protected void Pause(int seconds)  
    {  
        for (int i = seconds; i > 0; i--)  
        {  
            Console.Write($"\rPausing for {i} seconds... ");  
            Thread.Sleep(1000);  
        }  
        Console.WriteLine();  
    }  
}  

class BreathingActivity : MindfulnessActivity  
{  
    public void StartActivity()  
    {  
        StartMessage("Breathing Activity", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.");  
        
        int cycles = duration / 6; // Each cycle takes 6 seconds (3s in, 3s out)  
        for (int i = 0; i < cycles; i++)  
        {  
            Console.WriteLine("Breathe in...");  
            Pause(3);  
            Console.WriteLine("Breathe out...");  
            Pause(3);  
        }  
        
        EndMessage("Breathing Activity");  
    }  
}  

class ReflectionActivity : MindfulnessActivity  
{  
    private List<string> prompts = new List<string>  
    {  
        "Think of a time when you stood up for someone else.",  
        "Think of a time when you did something really difficult.",  
        "Think of a time when you helped someone in need.",  
        "Think of a time when you did something truly selfless."  
    };  

    private List<string> questions = new List<string>  
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

    public void StartActivity()  
    {  
        StartMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.");  
        
        Random rand = new Random();  
        string prompt = prompts[rand.Next(prompts.Count)];  
        Console.WriteLine(prompt);  
        Pause(5); // Give time for the user to think  

        int cycles = duration / 5; // Each question takes 5 seconds  
        for (int i = 0; i < cycles; i++)  
        {  
            string question = questions[rand.Next(questions.Count)];  
            Console.WriteLine(question);  
            Pause(5);  
        }  

        EndMessage("Reflection Activity");  
    }  
}  

class ListingActivity : MindfulnessActivity  
{  
    private List<string> prompts = new List<string>  
    {  
        "Who are people that you appreciate?",  
        "What are personal strengths of yours?",  
        "Who are people that you have helped this week?",  
        "When have you felt the Holy Ghost this month?",  
        "Who are some of your personal heroes?"  
    };  

    public void StartActivity()  
    {  
        StartMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");  
        
        Random rand = new Random();  
        string prompt = prompts[rand.Next(prompts.Count)];  
        Console.WriteLine(prompt);  
        Pause(5); //
    }
}