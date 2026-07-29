using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Solution 
{
    public bool IsPalindrome(int x) 
    {
        if (x < 0)
            return false;

        string convertedX = x.ToString();
        int cursorLeft = 0;
        int cursorRight = convertedX.Length - 1;
        int steps = 0;
        
        while (true)
        {
            if (cursorLeft != cursorRight && steps < convertedX.Length)
            {
                if (convertedX[cursorLeft] == convertedX[cursorRight])
                {
                    cursorLeft += 1;
                    cursorRight -= 1;
                    steps += 2;
                    continue;
                }
                return false;
            }
            break;
        }
        return true;
    }

    public static bool IsPalindromeBCD(uint n)
    {
        if (n < 10) return true;

        ulong bcd = 0;
        int digitCount = 0;
        uint temp = n;

        while (temp > 0)
        {
            ulong digit = temp % 10;
            bcd |= (digit << (digitCount * 4));
            digitCount++;
            temp /= 10;
        }

        int leftShift = (digitCount - 1) * 4;
        int rightShift = 0;

        while (leftShift > rightShift)
        {
            ulong leftNibble = (bcd >> leftShift) & 0xF;
            ulong rightNibble = (bcd >> rightShift) & 0xF;

            if (leftNibble != rightNibble)
                return false;

            leftShift -= 4;
            rightShift += 4;
        }

        return true;
    }

    public static bool IsPalindromeMath(int n)
    {
        if (n < 0 || (n % 10 == 0 && n != 0))
            return false;

        int original = n;
        int reversed = 0;

        while (n > 0)
        {
            int remainder = n % 10;
            reversed = (reversed * 10) + remainder;
            n /= 10;
        }

        return original == reversed;
    }

    public static void Main(string[] args)
    {
        string payloadPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "payload.txt");
        if (!File.Exists(payloadPath))
        {
            payloadPath = "payload.txt";
        }

        if (!File.Exists(payloadPath))
        {
            Console.WriteLine($"Nie znaleziono pliku: {payloadPath}");
            return;
        }

        string[] lines = File.ReadAllLines(payloadPath);
        List<int> testCases = new List<int>(lines.Length);
        foreach (string line in lines)
        {
            if (int.TryParse(line.Trim(), out int val))
            {
                testCases.Add(val);
            }
        }

        int[] tests = testCases.ToArray();
        Console.WriteLine($"Wczytano {tests.Length} przypadkow testowych z pliku {payloadPath}");

        Stopwatch swBcd = Stopwatch.StartNew();
        ulong checksumBcd = 14695981039346656037UL;
        int countBcd = 0;

        for (int i = 0; i < tests.Length; i++)
        {
            bool isPal = tests[i] >= 0 ? IsPalindromeBCD((uint)tests[i]) : false;
            if (isPal) countBcd++;
            checksumBcd ^= (ulong)tests[i] * (isPal ? 1337UL : 7331UL) + (ulong)(isPal ? 1 : 0);
            checksumBcd *= 1099511628211UL;
        }
        swBcd.Stop();

        Console.WriteLine("\n--- IsPalindromeBCD ---");
        Console.WriteLine($"Czas przeliczenia: {swBcd.Elapsed.TotalMilliseconds:F3} ms ({swBcd.ElapsedTicks} ticks)");
        Console.WriteLine($"Liczba palindromow: {countBcd}");
        Console.WriteLine($"Suma kontrolna (checksum): 0x{checksumBcd:X16}");

        Solution sol = new Solution();
        Stopwatch swString = Stopwatch.StartNew();
        ulong checksumString = 14695981039346656037UL;
        int countString = 0;

        for (int i = 0; i < tests.Length; i++)
        {
            bool isPal = sol.IsPalindrome(tests[i]);
            if (isPal) countString++;
            checksumString ^= (ulong)tests[i] * (isPal ? 1337UL : 7331UL) + (ulong)(isPal ? 1 : 0);
            checksumString *= 1099511628211UL;
        }
        swString.Stop();

        Console.WriteLine("\n--- IsPalindrome (String) ---");
        Console.WriteLine($"Czas przeliczenia: {swString.Elapsed.TotalMilliseconds:F3} ms ({swString.ElapsedTicks} ticks)");
        Console.WriteLine($"Liczba palindromow: {countString}");
        Console.WriteLine($"Suma kontrolna (checksum): 0x{checksumString:X16}");

        Stopwatch swMath = Stopwatch.StartNew();
        ulong checksumMath = 14695981039346656037UL;
        int countMath = 0;

        for (int i = 0; i < tests.Length; i++)
        {
            bool isPal = IsPalindromeMath(tests[i]);
            if (isPal) countMath++;
            checksumMath ^= (ulong)tests[i] * (isPal ? 1337UL : 7331UL) + (ulong)(isPal ? 1 : 0);
            checksumMath *= 1099511628211UL;
        }
        swMath.Stop();

        Console.WriteLine("\n--- IsPalindrome (Math) ---");
        Console.WriteLine($"Czas przeliczenia: {swMath.Elapsed.TotalMilliseconds:F3} ms ({swMath.ElapsedTicks} ticks)");
        Console.WriteLine($"Liczba palindromow: {countMath}");
        Console.WriteLine($"Suma kontrolna (checksum): 0x{checksumMath:X16}");
    }
}