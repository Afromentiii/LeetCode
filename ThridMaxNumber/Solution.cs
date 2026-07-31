using System;

public class Solution 
{
    public int ThirdMax(int[] nums) 
    {
        if (nums == null || nums.Length == 0) return 0;

        QuickSortDescending(nums, 0, nums.Length - 1);

        int count = 1;
        int lastMax = nums[0];
        int prevMax = nums[0]; 

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != lastMax)
            {
                prevMax = lastMax;
                lastMax = nums[i];
                count++;
            }

            if (count == 3)
                return lastMax;
        }

        return prevMax;
    }

    private void QuickSortDescending(int[] arr, int left, int right) 
    {
        if (left < right) 
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSortDescending(arr, left, pivotIndex - 1);
            QuickSortDescending(arr, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] arr, int left, int right) 
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++) 
        {
            if (arr[j] > pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;

        return i + 1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        
        Console.WriteLine($"Test 1: {solution.ThirdMax(new int[] { 3, 2, 1 }) == 1}");
        Console.WriteLine($"Test 2: {solution.ThirdMax(new int[] { 1, 2 }) == 2}");
        Console.WriteLine($"Test 3: {solution.ThirdMax(new int[] { 2, 2, 3, 1 }) == 1}");
    }
}