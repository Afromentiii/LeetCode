public class Solution 
{
    public int RemoveElement(int[] nums, int val) 
    {
        int cursor = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            if(val == nums[i])
            {
                continue;
            }
            nums[cursor++] = nums[i];
        }

        return cursor;
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Przykład 1
        int[] nums1 = { 3, 2, 2, 3 };
        int val1 = 3;
        System.Console.WriteLine("Oryginalnie: [3, 2, 2, 3], Usuwamy: 3");
        int k1 = solution.RemoveElement(nums1, val1);
        PrintResult(k1, nums1);

        // Przykład 2
        int[] nums2 = { 0, 1, 2, 2, 3, 0, 4, 2 };
        int val2 = 2;
        System.Console.WriteLine("\nOryginalnie: [0, 1, 2, 2, 3, 0, 4, 2], Usuwamy: 2");
        int k2 = solution.RemoveElement(nums2, val2);
        PrintResult(k2, nums2);
    }

    private static void PrintResult(int k, int[] nums)
    {
        System.Console.Write($"Zwrócona długość k = {k}. Tablica nums (pierwsze k elementów): [");
        for (int i = 0; i < k && i < nums.Length; i++)
        {
            System.Console.Write(nums[i] + (i < k - 1 ? ", " : ""));
        }
        System.Console.WriteLine("]");
    }
}