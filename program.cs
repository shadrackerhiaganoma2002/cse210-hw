using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Test constructors
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);

        Console.WriteLine($"Fraction 1: {f1.GetFractionString()}, Decimal: {f1.GetDecimalValue()}");
        Console.WriteLine($"Fraction 2: {f2.GetFractionString()}, Decimal: {f2.GetDecimalValue()}");
        Console.WriteLine($"Fraction 3: {f3.GetFractionString()}, Decimal: {f3.GetDecimalValue()}");


        // Test getters and setters
        f3.Top = 10;
        f3.Bottom = 3;
        Console.WriteLine($"\nFraction 3 (modified): {f3.GetFractionString()}, Decimal: {f3.GetDecimalValue()}");

        try
        {
            Fraction f4 = new Fraction(5,0); //this will throw an exception
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"\nException caught: {e.Message}");
        }


    }
}

