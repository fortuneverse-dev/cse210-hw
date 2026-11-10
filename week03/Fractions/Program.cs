using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        
        // 1. Verify all three constructors
        Fraction f1 = new Fraction();        // 1/1
        Fraction f2 = new Fraction(6);       // 6/1
        Fraction f3 = new Fraction(6, 7);    // 6/7

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine();

        // 2. Verify getters and setters
        Fraction f = new Fraction();
        f.SetTop(3);
        f.SetBottom(4);
        Console.WriteLine($"Top: {f.GetTop()}");
        Console.WriteLine($"Bottom: {f.GetBottom()}");
        Console.WriteLine();

        // 3. Verify the different representations
        Fraction a = new Fraction();
        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());

        Fraction b = new Fraction(5);
        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());

        Fraction c = new Fraction(3, 4);
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

        Fraction d = new Fraction(1, 3);
        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
    }
}