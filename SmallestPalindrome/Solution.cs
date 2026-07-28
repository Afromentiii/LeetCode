public class Solution 
{
    public string SmallestPalindrome(string s) 
    {
        int[] counts = new int[26];
        foreach (char c in s)
        {
            counts[c - 'a']++;
        }

        string middle = "";
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] % 2 != 0)
            {
                middle = ((char)(i + 'a')).ToString();
                counts[i]--;
                break;
            }
        }

        System.Text.StringBuilder firstHalf = new System.Text.StringBuilder();
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] > 0)
            {
                firstHalf.Append((char)(i + 'a'), counts[i] / 2);
            }
        }

        string leftPart = firstHalf.ToString();
        char[] leftArray = leftPart.ToCharArray();
        System.Array.Reverse(leftArray);
        string rightPart = new string(leftArray);

        return leftPart + middle + rightPart;
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        
        string[] payloads = { "daccad", "racecar", "madam", "kayak", "radar", "level", "a" };
        
        foreach (string payload in payloads)
        {
            System.Console.WriteLine($"String: {payload} -> Palindrom: {solution.SmallestPalindrome(payload)}");
        }
    }
}
