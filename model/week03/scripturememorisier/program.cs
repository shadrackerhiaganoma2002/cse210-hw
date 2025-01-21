using System;

class Program
{
    static void Main(string[] args)
    {
        // Use a verse from the Book of Mormon
        var scripture = new Scripture("1 Nephi 3:7", "I will go and do the things which the Lord hath commanded.");
        
        // Loop until all words are hidden or the user decides to quit
        while (true)
        {
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("All words are now hidden. Exiting...");
                break;
            }
        }
    }
}
