using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public int Reverse(int x) 
    {
        if (x == 0)
            return 0;

        bool isNegative = x < 0;
        
        uint number = x == int.MinValue ? 2147483648 : (uint)Math.Abs(x);

        List<string> NumberList = new List<string>();

        while (number > 0) 
        {
            uint digit = number % 10;   
            number /= 10;        

            NumberList.Add(digit.ToString());            
        }

        string newX = "";

        if (isNegative)
            newX += "-";

        for (int i = 0; i < NumberList.Count; i++)
            newX += NumberList.ElementAt(i);

        int result;
        if (!int.TryParse(newX, out result))
            return 0;

        return result;
    }

    public static void PrintBinary(int x)
    {
        for (int i = 31; i >= 0; i--)
            Console.Write((x >> i) & 1);
            
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        if (args.Length > 0 && System.IO.File.Exists(args[0]))
        {
            string[] lines = System.IO.File.ReadAllLines(args[0]);
            Solution solution = new Solution();
            
            var sw = System.Diagnostics.Stopwatch.StartNew();
            long sum = 0;

            foreach (string line in lines)
            {
                int input;
                if (int.TryParse(line, out input))
                {
                    sum += solution.Reverse(input);
                }
            }

            sw.Stop();
            Console.WriteLine("Czas algorytmiczny (wewnetrzny C#): " + sw.Elapsed.TotalMilliseconds + " ms");
            Console.WriteLine("Suma kontrolna wynikow: " + sum);
        }
        else
        {
            Console.WriteLine("Podaj prawidlowa sciezke do pliku payload.txt jako argument.");
        }
    }
}