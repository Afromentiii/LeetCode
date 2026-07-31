using System;

public class Solution 
{
    public bool IsPalindrome(string s) 
    {
        int cursor1 = 0;
        int cursor2 = s.Length - 1;
        bool isPalindrome = true;

        while (cursor1 < cursor2)
        {
            while (cursor1 < cursor2 && !char.IsLetterOrDigit(s[cursor1]))
                cursor1++;

            while (cursor1 < cursor2 && !char.IsLetterOrDigit(s[cursor2]))
                cursor2--;

            if (char.ToLower(s[cursor1]) != char.ToLower(s[cursor2]))
                return false;

            cursor1++;
            cursor2--;
        }

        return isPalindrome;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();

        var testCases = new[]
        {
            (s: "A man, a plan, a canal: Panama", expected: true),
            (s: "race a car", expected: false),
            (s: " ", expected: true)
        };

        foreach (var test in testCases)
        {
            bool result = solution.IsPalindrome(test.s);
            string status = result == test.expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] s=\"{test.s}\" => Result={result}, Expected={test.expected}");
        }
    }
}