using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> numbers = new List<int>();
        
        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0) 
            {
                break;
            }

            numbers.Add(input); 
        }

       
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int largest = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("No positive numbers were entered.");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
