using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

public class Solution 
{
    public int GetCommon(int[] nums1, int[] nums2) 
    {
        int cursor1 = 0;
        int cursor2 = 0;

        while(cursor1 < nums1.Length && cursor2 < nums2.Length)
        {
            if(nums1[cursor1] == nums2[cursor2])
                return nums1[cursor1];

            if(nums1[cursor1] < nums2[cursor2])
                cursor1++;
            else
                cursor2++;
        }
       
        return -1;
    }

    public int GetCommonNaive(int[] nums1, int[] nums2) 
    {
        for(int i = 0; i < nums1.Length; i++)
        {
            for(int j = 0; j < nums2.Length; j++)
            {
                if(nums1[i] == nums2[j])
                    return nums1[i];
            }
        }
        return -1;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();
        TestPayload.RunTests(solution);
    }
}

public static class TestPayload
{
    public static void RunTests(Solution solution)
    {
        if (!File.Exists("payload.txt"))
        {
            Console.WriteLine("Błąd: Nie znaleziono pliku payload.txt.");
            return;
        }

        var lines = File.ReadAllLines("payload.txt");
        var testCases = new List<(int[] nums1, int[] nums2, int expected)>();
        
        int[] currentNums1 = null;
        int[] currentNums2 = null;

        foreach (var line in lines)
        {
            if (line.StartsWith("nums1: ["))
            {
                string inner = line.Substring(8, line.Length - 9);
                currentNums1 = string.IsNullOrEmpty(inner) ? new int[0] : inner.Split(',').Select(int.Parse).ToArray();
            }
            else if (line.StartsWith("nums2: ["))
            {
                string inner = line.Substring(8, line.Length - 9);
                currentNums2 = string.IsNullOrEmpty(inner) ? new int[0] : inner.Split(',').Select(int.Parse).ToArray();
            }
            else if (line.StartsWith("expected: "))
            {
                int expected = int.Parse(line.Substring(10));
                testCases.Add((currentNums1, currentNums2, expected));
            }
        }

        Console.WriteLine($"Wczytano {testCases.Count} testów z 'payload.txt'. Uruchamianie...");

        int passedCount = 0;
        
        var swTotal = Stopwatch.StartNew();
        var swOptimized = new Stopwatch();
        var swNaive = new Stopwatch();

        for (int i = 0; i < testCases.Count; i++)
        {
            var (nums1, nums2, expected) = testCases[i];
            
            swOptimized.Start();
            int optimizedResult = solution.GetCommon(nums1, nums2);
            swOptimized.Stop();
            
            swNaive.Start();
            int naiveResult = solution.GetCommonNaive(nums1, nums2);
            swNaive.Stop();

            if (optimizedResult != expected || naiveResult != expected)
            {
                Console.WriteLine($"[BŁĄD] Test #{i + 1}: Zoptymalizowany dał {optimizedResult}, Naiwny dał {naiveResult}, Oczekiwano: {expected}.");
            }
            else
            {
                passedCount++;
            }
        }

        swTotal.Stop();

        Console.WriteLine($"Suma kontrolna (testy przeszły): {passedCount} / {testCases.Count}");
        Console.WriteLine($"Czas zoptymalizowanego algorytmu: {swOptimized.ElapsedMilliseconds} ms");
        Console.WriteLine($"Czas naiwnego algorytmu (brute-force): {swNaive.ElapsedMilliseconds} ms");
        Console.WriteLine($"Całkowity czas trwania testu: {swTotal.ElapsedMilliseconds} ms");
    }
}