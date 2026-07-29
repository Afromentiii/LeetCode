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
        
        while(true)
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

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        
        int[] testCases = { 121, -121, 10, 1221, 11 };
        foreach (int testCase in testCases)
        {
            System.Console.WriteLine($"IsPalindrome({testCase}) = {solution.IsPalindrome(testCase)}");
        }
    }
}