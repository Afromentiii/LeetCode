public class Solution 
{
    public int[] PlusOne(int[] digits) 
    {
        int index = digits.Length - 1;

        while (index >= 0)
        {
            if (digits[index] < 9)
            {
                digits[index] += 1;
                return digits;
            }
            digits[index] = 0;
            index -= 1;
        }

        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        System.Console.WriteLine(string.Join(", ", solution.PlusOne([1, 2, 3])));
        System.Console.WriteLine(string.Join(", ", solution.PlusOne([4, 3, 2, 1])));
        System.Console.WriteLine(string.Join(", ", solution.PlusOne([9])));
        System.Console.WriteLine(string.Join(", ", solution.PlusOne([9, 9, 9])));
    }
}