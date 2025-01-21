using System;  

class Program  
{  
    static void Main(string[] args)  
    {  
        Random randomGenerator = new Random();  
        string playAgain;  
        
        do  
        {
            int magicNumber = randomGenerator.Next(1, 101);  
            int guess = 0;  
            int guessCount = 0;  

            Console.WriteLine("Welcome to 'Guess My Number'!");  
            Console.WriteLine("I have selected a magic number between 1 and 100.");  

           
            while (guess != magicNumber)  
            {  
                Console.Write("What is your guess? ");  
                guess = int.Parse(Console.ReadLine());  
                guessCount++;  

        
                if (guess < magicNumber)  
                {  
                    Console.WriteLine("Higher");  
                }  
                else if (guess > magicNumber)  
                {  
                    Console.WriteLine("Lower");  
                }  
                else  
                {  
                    Console.WriteLine("You guessed it!");  
                }  
            }  

            
            Console.WriteLine($"It took you {guessCount} guesses to find the magic number.");  

            Console.Write("Do you want to play again? (yes/no): ");  
            playAgain = Console.ReadLine().ToLower();  

        } while (playAgain == "yes");  

        Console.WriteLine("Thank you for playing!");  
    }  
}