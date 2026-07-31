using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Solution 
{
    public int LengthOfLastWordNaive(string s) 
    {
        int lenCounter = 0;
        bool isSpaceLast = false;
        foreach(char c in s)
        {
            if (c == ' ')
            {
                isSpaceLast = true;
                continue;
            }

            if(isSpaceLast)
                lenCounter = 0;

            lenCounter++;
            isSpaceLast = false;
        }
        return lenCounter;
    }

    public int LengthOfLastWordOptimized(string s) 
    {
        int lenCounter = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] != ' ')
                lenCounter++;
                
            else if (lenCounter > 0)
                break; 
        }
        return lenCounter;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();

        if (!File.Exists("payload.txt"))
        {
            Console.WriteLine("Błąd: Nie znaleziono pliku payload.txt.");
            return;
        }

        Console.WriteLine("Wczytywanie ekstremalnych testów z payload.txt...");
        var testCases = new List<(string s, int expected)>();
        string currentS = null;
        
        // Czytamy po linii, ponieważ niektóre teksty mogą mieć 10-20 MB długości
        foreach (var line in File.ReadLines("payload.txt"))
        {
            if (line.StartsWith("s: \""))
            {
                currentS = line.Substring(4, line.Length - 5);
            }
            else if (line.StartsWith("expected: "))
            {
                int expected = int.Parse(line.Substring(10));
                testCases.Add((currentS, expected));
            }
        }

        Console.WriteLine($"Wczytano {testCases.Count} zróżnicowanych testów. Rozpoczynam wyliczanie...");
        
        int passedCount = 0;
        var swTotal = Stopwatch.StartNew();
        var swOptimized = new Stopwatch();
        var swNaive = new Stopwatch();

        for (int i = 0; i < testCases.Count; i++)
        {
            var (s, expected) = testCases[i];
            
            swOptimized.Start();
            int optResult = solution.LengthOfLastWordOptimized(s);
            swOptimized.Stop();
            
            swNaive.Start();
            int naiveResult = solution.LengthOfLastWordNaive(s);
            swNaive.Stop();

            if (optResult != expected || naiveResult != expected)
            {
                Console.WriteLine($"[BŁĄD] Test #{i + 1}: Zoptymalizowany={optResult}, Naiwny={naiveResult}, Oczekiwano={expected}");
            }
            else
            {
                passedCount++;
            }
        }

        swTotal.Stop();

        Console.WriteLine($"Suma kontrolna (testy przeszły pomyślnie): {passedCount} / {testCases.Count}");
        Console.WriteLine($"Czas nowej metody z pętlą 'for' od tyłu (early-exit): {swOptimized.ElapsedMilliseconds} ms");
        Console.WriteLine($"Czas starej metody z pętlą 'foreach' (od przodu): {swNaive.ElapsedMilliseconds} ms");
        Console.WriteLine($"Całkowity czas walidacji sumy kontrolnej z logiką wokół: {swTotal.ElapsedMilliseconds} ms");
    }
}