public class Solution 
{
    public int SearchInsert(int[] nums, int target) 
    {
        int left = 0;
        int right = nums.Length - 1;
        
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        
        return left;
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        
        int[] payload = { 1, 3, 5, 6 };
        System.Console.WriteLine($"Test z tablicą: [1, 3, 5, 6]");
        System.Console.WriteLine($"Target 5 -> Index: {solution.SearchInsert(payload, 5)}");
        System.Console.WriteLine($"Target 2 -> Index: {solution.SearchInsert(payload, 2)}");
        System.Console.WriteLine($"Target 7 -> Index: {solution.SearchInsert(payload, 7)}");
        System.Console.WriteLine($"Target 0 -> Index: {solution.SearchInsert(payload, 0)}");
    }
}