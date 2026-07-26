public class Solution 
{
    public int Reverse(int x) 
    {
        if (x == 0)
            return 0;

        bool isNegative = x < 0;
        long tempX = Math.Abs((long)x);

        long bcd = 0L;
        int shift = 0;

        while (tempX > 0) 
        {
            long digit = tempX % 10;   
            tempX /= 10;        

            bcd |= (digit << shift);
            shift += 4;
        }

        string newX = "";
        for (int i = 0; i < shift; i += 4)
        {
            long digit = (bcd >> i) & 0xF;
            newX += digit.ToString();
        }

        if (!int.TryParse(newX, out int result))
        {
            return 0;
        }

        return isNegative ? -result : result;
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
        int newX = solution.Reverse(-321);
        Console.Write(newX);
    }
}