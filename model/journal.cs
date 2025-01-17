using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new();
    private readonly Dictionary<string, List<string>> promptCategories = new()
    {
        { "Reflection", new List<string> { "What was the best part of your day?", "What did you learn today?", "If you could redo one thing today, what would it be?" } },
        { "Gratitude", new List<string> { "What are you most grateful for today?", "Who made your day better today?", "What is one thing that made you smile today?" } },
        { "Emotions", new List<string> { "What emotion did you feel the most today?", "What frustrated you today?", "What gave you the most joy today?" } }
    };

    public void AddEntry()
    {
        Console.WriteLine("Choose a category (Reflection, Gratitude, Emotions):");
        string category = Console.ReadLine()?.Trim();

        if (!promptCategories.ContainsKey(category))
        {
            Console.WriteLine("Invalid category. Defaulting to 'Reflection'.");
            category = "Reflection";
        }

        string prompt = GetRandomPrompt(category);
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        entries.Add(new Entry(prompt, response));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEntry added successfully!\n");
        Console.ResetColor();
    }

    public void DisplayEntries()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Your Journal Entries:");
        Console.ResetColor();

        if (entries.Count == 0)
        {
            Console.WriteLine("No entries available.\n");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (e.g., journal.json): ");
        string filename = Console.ReadLine();

        try
        {
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nJournal successfully saved to '{filename}'.\n");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error saving file: {ex.Message}\n");
        }
        finally
        {
            Console.ResetColor();
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (e.g., journal.json): ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found.\n");
                return;
            }

            string json = File.ReadAllText(filename);
            entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nJournal successfully loaded!\n");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error loading file: {ex.Message}\n");
        }
        finally
        {
            Console.ResetColor();
        }
    }

    public void SearchEntries()
    {
        Console.Write("Enter a keyword or date to search: ");
        string query = Console.ReadLine()?.ToLower();

        var results = entries.FindAll(entry =>
            entry.Date.ToLower().Contains(query) ||
            entry.Prompt.ToLower().Contains(query) ||
            entry.Response.ToLower().Contains(query));

        if (results.Count == 0)
        {
            Console.WriteLine("\nNo matching entries found.\n");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nSearch Results:");
        Console.ResetColor();

        foreach (var entry in results)
        {
            Console.WriteLine(entry);
        }
    }

    private string GetRandomPrompt(string category)
    {
        Random random = new();
        var prompts = promptCategories[category];
        return prompts[random.Next(prompts.Count)];
    }
}
