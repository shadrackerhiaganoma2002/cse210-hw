using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your grade percentage: ");
            string userInput = Console.ReadLine();
            int gradePercentage;

            if (!int.TryParse(userInput, out gradePercentage))
            {
                Console.WriteLine("Invalid input! Please enter a valid percentage.");
                return; 
            }

            string letter = "";
            string sign = "";

           
            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            
            if (letter == "A")
            {

                sign = "";
            }
            else if (letter == "F")
            {
                sign = ""; 
            }
            else
            {
                int lastDigit = gradePercentage % 10;

                if (lastDigit >= 7)
                {
                    sign = "+"; 
                }
                else if (lastDigit < 3)
                {
                    sign = "-"; 
                }
                else
                {
                    sign = "";
                }
            }

            Console.WriteLine($"Your letter grade is: {letter}{sign}");

            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You've passed the course.");
            }
            else
            {
                Console.WriteLine("Don't worry, keep trying! You can do it next time.");
            }
        }
    }
}
