using System;
using System.Linq;

public class Solution 
{
    public string LongestCommonPrefix(string[] strs) 
    {
        if (strs == null || strs.Length == 0) return "";
        int minLen = strs.Min(s => s.Length);
        
        for (int i = 0; i < minLen; i++)
        {
            char currentChar = strs[0][i];

            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] != currentChar)
                    return strs[0].Substring(0, i);
            }
        }

        return strs[0].Substring(0, minLen);
    }
}    

class Program 
{
    static void Main(string[] args) 
    {
        var solution = new Solution();
        
        string[] test1 = { "flower", "dog", "flight" };
        Console.WriteLine($"Test 1: {solution.LongestCommonPrefix(test1)}");
        
        string[] test2 = { "dog", "racecar", "car" };
        Console.WriteLine($"Test 2: {solution.LongestCommonPrefix(test2)}");
    }
}
