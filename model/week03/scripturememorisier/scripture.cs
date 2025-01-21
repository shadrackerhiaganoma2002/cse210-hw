using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Ref { get; private set; }
    private List<Word> Words { get; set; }

    public Scripture(string reference, string text)
    {
        Ref = new Reference(reference);
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWord()
    {
        var notHiddenWords = Words.Where(w => !w.IsHidden).ToList();
        if (notHiddenWords.Count == 0)
            return;

        Random rand = new Random();
        var randomWord = notHiddenWords[rand.Next(notHiddenWords.Count)];
        randomWord.Hide();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Ref);
        Console.WriteLine(string.Join(" ", Words.Select(w => w.Display())));
    }

    public bool AllWordsHidden() => Words.All(w => w.IsHidden);
}
