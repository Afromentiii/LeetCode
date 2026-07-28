using System;

public class Solution 
{
    public double MyPow(double x, int n) 
    {
        long N = n;
        if (N < 0) 
        {
            x = 1 / x;
            N = -N;
        }

        return FastPow(x, N);
    }

    private double FastPow(double x, long n) 
    {
        if (n == 0) 
            return 1.0;

        double half = FastPow(x, n / 2);

        if (n % 2 == 0) 
            return half * half;
        else 
            return half * half * x;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        
        var testCases = new (double x, int n)[] 
        {
            (2.00000, 10),
            (2.10000, 3),
            (2.00000, -2),
            (1.00000, 2147483647), // int.MaxValue
            (-1.00000, -2147483648), // int.MinValue
            (0.00000, 1),
            (2.00000, 0)
        };

        Console.WriteLine("Testy dla MyPow (x^n):");
        
        foreach (var test in testCases)
        {
            double result = solution.MyPow(test.x, test.n);
            double expected = Math.Pow(test.x, test.n);
            
            Console.WriteLine($"\nBaza (x): {test.x}, Wykładnik (n): {test.n}");
            Console.WriteLine($"-> MyPow: {result}");
            Console.WriteLine($"-> Wbudowane Math.Pow: {expected}");
        }
    }
}