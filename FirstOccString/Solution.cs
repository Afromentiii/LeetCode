using System;

public class Solution 
{
    public int StrStr(string haystack, string needle) 
    {
        int hLen = haystack.Length;
        int nLen = needle.Length;

        for (int i = 0; i <= hLen - nLen; i++)
        {
            int j;
            for (j = 0; j < nLen; j++)
            {
                if (haystack[i + j] != needle[j])
                    break;
            }

            if (j == nLen)
                return i;
        }

        return -1;
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        Console.WriteLine(sol.StrStr("sadbutsad", "sad"));
        Console.WriteLine(sol.StrStr("leetcode", "leeto"));
    }
}