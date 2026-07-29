public class Solution 
{
    public int MySqrt(long x)
    {
        if (x < 2) return (int)x; 

        long NextStep(long xn) => (xn + x / xn) / 2;

        long xn = x; 
        long xNext = NextStep(xn);

        while (xNext < xn)
        {
            xn = xNext;
            xNext = NextStep(xn);
        }

        return (int)xn;
    }

    public static void Main(string[] args)
    {
        var solution = new Solution();

        int[][] tests = 
        {
            new[] { 0, 0 },
            new[] { 1, 1 },
            new[] { 2, 1 },
            new[] { 4, 2 },
            new[] { 8, 2 },
            new[] { 9, 3 },
            new[] { 16, 4 },
            new[] { 2147395599, 46339 }
        };

        foreach (var test in tests)
        {
            int input = test[0];
            int expected = test[1];
            int result = solution.MySqrt(input);
            string status = result == expected ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] MySqrt({input}) = {result}, expected {expected}");
        }
    }
}