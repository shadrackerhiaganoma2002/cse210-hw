using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new();
        bool isRunning = true;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("=== Welcome to Your Journal App ===\n");
        Console.ResetColor();

        while (isRunning)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    journal.SearchEntries();
                    break;
                case "6":
                    SimulateDailyReminder();
                    break;
                case "7":
                    Console.WriteLine("Goodbye! Have a wonderful day!");
                    isRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Menu:");
        Console.ResetColor();
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Search the journal");
        Console.WriteLine("6. Simulate a daily reminder");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option (1-7): ");
    }

    static void SimulateDailyReminder()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nSimulating daily reminders for the next 5 seconds...\n");
        Console.ResetColor();

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Reminder {i}: Don't forget to write in your journal!");
            Thread.Sleep(1000);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nReminder simulation complete.\n");
        Console.ResetColor();
    }
}
