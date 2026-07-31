using System.Diagnostics.Metrics;

public class Solution 
{
    public int LengthOfLastWord(string s) 
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

            // Console.WriteLine($"c='{c}' | lenCounter={lenCounter} | isSpaceLast={isSpaceLast}");
        }
        return lenCounter;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();

        Console.WriteLine(solution.LengthOfLastWord("Hello World"));   // 5
        Console.WriteLine(solution.LengthOfLastWord("   fly me   to   the moon  ")); // 4
        Console.WriteLine(solution.LengthOfLastWord("luffy is still joyboy")); // 6
    }
}