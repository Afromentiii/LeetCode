public class Solution 
{
    public int Reverse(int x) 
    {
        if (x == 0)
            return 0;

        bool isNegative = x < 0;
        long number = Math.Abs((long)x);

        List<string> NumberList = new List<string>();

        while (number > 0) 
        {
            long digit = number % 10;   
            number /= 10;        

            NumberList.Add(digit.ToString());            
        }

        string newX = "";

        if (isNegative)
            newX += "-";

        for (int i = 0; i < NumberList.Count; i++)
            newX += NumberList.ElementAt(i);

        if (!int.TryParse(newX, out int result))
            return 0;

        return result;
    }

    public static void PrintBinary(int x)
    {
        for (int i = 31; i >= 0; i--)
            Console.Write((x >> i) & 1);
            
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int newX = solution.Reverse(-12);
        Console.Write(newX);
    }
}