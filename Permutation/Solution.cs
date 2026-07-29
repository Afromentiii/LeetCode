using System;
using System.Collections.Generic;

public class Solution 
{
    public IList<IList<int>> Permute(int[] nums) 
    {
        int permutationMax = Factorial(nums.Length);
        
        IList<IList<int>> permutationList = new List<IList<int>>();
        
        int[] current = (int[])nums.Clone();
        permutationList.Add(new List<int>(current));

        for (int i = 0; i < permutationMax - 1; i++)
        {
            singlePermutation(current);
            permutationList.Add(new List<int>(current));
        }
        
        return permutationList;
    }

    public void singlePermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;

        if (i >= 0) 
        {
            int j = nums.Length - 1;
            while (nums[j] <= nums[i])
                j--;

            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        Array.Reverse(nums, i + 1, nums.Length - (i + 1));
    }

    public int Factorial(int n) 
    {
        if (n < 0) return 0; 
        
        int result = 1;
        for (int i = 2; i <= n; i++) 
            result *= i;
        return result;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[][] testCases = new int[][] 
        {
            new int[] { 1, 2, 3 },
            new int[] { 0, 1 },
            new int[] { 1 },
            new int[] { 1, 2, 3, 4}
        };
        
        foreach (var nums in testCases)
        {
            Console.WriteLine("\nTest dla tablicy: [" + string.Join(", ", nums) + "]");
            
            try 
            {
                var result = solution.Permute(nums);
                Console.WriteLine($"Wygenerowano {result.Count} permutacji:");
                
                foreach (var perm in result)
                {
                    Console.WriteLine("[" + string.Join(", ", perm) + "]");
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił wyjątek: " + ex.Message);
            }
        }
    }
}