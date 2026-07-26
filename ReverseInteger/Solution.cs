using System;

public class Solution 
{
    public int Reverse(int x) 
    {
        if (x == 0)
            return 0;

        bool isNegative = x < 0;
        
        uint tempX = x == int.MinValue ? 2147483648 : (uint)Math.Abs(x);

        int bcdLow = 0;
        int bcdHigh = 0;
        int shift = 0;

        while (tempX > 0) 
        {
            uint digit = tempX % 10;   
            tempX /= 10;        

            if (shift < 32)
                bcdLow |= (int)digit << shift;
            else
                bcdHigh |= (int)digit << (shift - 32);

            shift += 4;
        }

        string newX = "";
        for (int i = 0; i < shift; i += 4)
        {
            int digit = (i < 32) ? ((bcdLow >> i) & 0xF) : ((bcdHigh >> (i - 32)) & 0xF);
            newX += digit.ToString();
        }

        int result;
        if (!int.TryParse(newX, out result))
        {
            return 0;
        }

        return isNegative ? -result : result;
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