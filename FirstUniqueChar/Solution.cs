using System;
using System.Diagnostics;
using System.Collections.Generic;

public class Solution 
{
    public int FirstUniqChar(string s) 
    {
        if(s.Length == 1)
            return 0;

        Dictionary<char, bool> seen = new Dictionary<char, bool>();

        for(int i = 0; i < s.Length; i++)
        {
            char temp = s[i];
            
            if (seen.ContainsKey(temp))
                continue;
                
            seen.Add(temp, true);

            bool foundEnd = false;
            for(int j = i + 1; j < s.Length; j++)
            {
                if(temp == s[j])
                    break;
                
                if (j == s.Length - 1)
                    foundEnd = true;
            }

            if (foundEnd || i == s.Length - 1)
                return i;
        }
        return -1;
    }

    public int FirstUniqCharFreq(string s)
    {
        int[] freq = new int[256]; 
        
        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i]]++;
        }
        
        for (int i = 0; i < s.Length; i++)
        {
            if (freq[s[i]] == 1)
            {
                return i;
            }
        }
        
        return -1;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        
        string longString = new string('a', 10000) + "b" + new string('c', 10000);
        
        string[] testCases = new string[] 
        {
            "leetcode",
            "loveleetcode",
            "aabb",
            "a",
            "abcabc",
            "z",
            "dddccdbba",
            "programming",
            "aabbccddeeffg",
            "xxyyzz",
            "abcdefghijklmnopqrstuvwxyz",
            longString
        };

        Console.WriteLine("Przypadki testowe i wyniki:");
        foreach (string s in testCases)
        {
            string displayStr = s.Length > 30 ? s.Substring(0, 27) + "..." : s;
            Console.WriteLine($"s = \"{displayStr,-30}\" -> Pierwsza funkcja: {solution.FirstUniqChar(s),-6} | Druga funkcja: {solution.FirstUniqCharFreq(s),-6}");
        }

        Console.WriteLine("\n--- Pomiary czasu (dla wszystkich powyzszych testow uruchamianych 1000 razy) ---");
        
        int iterations = 1000;
        
        Stopwatch sw1 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            foreach (string s in testCases)
            {
                solution.FirstUniqChar(s);
            }
        }
        sw1.Stop();
        Console.WriteLine($"FirstUniqChar (z zagniezdzona petla): {sw1.ElapsedMilliseconds} ms");

        Stopwatch sw2 = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            foreach (string s in testCases)
            {
                solution.FirstUniqCharFreq(s);
            }
        }
        sw2.Stop();
        Console.WriteLine($"FirstUniqCharFreq (zliczanie czestotliwosci): {sw2.ElapsedMilliseconds} ms");
    }
}