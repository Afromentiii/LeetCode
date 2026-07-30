using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class Solution 
{
    public void MergeOriginal(int[] nums1, int m, int[] nums2, int n) 
    {
        int currentM = m;

        for (int j = 0; j < n; j++) 
        {
            int num2IndexValue = nums2[j];
            int swapIndex = -1;

            for (int i = 0; i < currentM; i++)
            {
                if (nums1[i] > num2IndexValue)
                {
                    swapIndex = i;
                    break; 
                }
            }

            if (swapIndex == -1)
                swapIndex = currentM;

            for (int k = currentM; k > swapIndex; k--)
                nums1[k] = nums1[k - 1];

            nums1[swapIndex] = num2IndexValue;
            currentM++;
        }
    }

    public void MergeQuickSort(int[] nums1, int m, int[] nums2, int n) 
    {
        int[] merged = new int[m + n];
        
        Array.Copy(nums1, 0, merged, 0, m);
        Array.Copy(nums2, 0, merged, m, n);
        
        if (merged.Length > 0)
        {
            QuickSort(merged, 0, merged.Length - 1);
        }
        
        Array.Copy(merged, 0, nums1, 0, m + n);
    }

    private void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);
            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int swapTemp = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = swapTemp;

        return i + 1;
    }

    public static void Main(string[] args)
    {
        if (!File.Exists("payload.txt"))
        {
            Console.WriteLine("Brak pliku payload.txt.");
            return;
        }

        string[] lines = File.ReadAllLines("payload.txt");
        if (lines.Length == 0) return;

        int totalCases = int.Parse(lines[0]);
        var solution = new Solution();

        Stopwatch swOriginal = new Stopwatch();
        Stopwatch swQuickSort = new Stopwatch();

        bool allMatch = true;

        int lineIndex = 1;
        for (int c = 0; c < totalCases; c++)
        {
            if (lineIndex >= lines.Length) break;

            string[] mn = lines[lineIndex++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(mn[0]);
            int n = int.Parse(mn[1]);

            int[] nums1 = new int[m + n];
            int[] nums2 = new int[n];

            string[] arr1Str = lines[lineIndex++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr1Str.Length && i < m + n; i++)
            {
                nums1[i] = int.Parse(arr1Str[i]);
            }
            
            string[] arr2Str = lines[lineIndex++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr2Str.Length && i < n; i++)
            {
                nums2[i] = int.Parse(arr2Str[i]);
            }

            int[] nums1ForOriginal = (int[])nums1.Clone();
            int[] nums1ForQuickSort = (int[])nums1.Clone();

            swOriginal.Start();
            solution.MergeOriginal(nums1ForOriginal, m, nums2, n);
            swOriginal.Stop();

            swQuickSort.Start();
            solution.MergeQuickSort(nums1ForQuickSort, m, nums2, n);
            swQuickSort.Stop();

            if (!nums1ForOriginal.SequenceEqual(nums1ForQuickSort))
            {
                allMatch = false;
                Console.WriteLine($"BŁĄD KONTROLNY na przypadku {c + 1} (m={m}, n={n})");
                Console.WriteLine($"Oczekiwano wyniku jak w funkcji oryginalnej, ale QuickSort zwrócił coś innego.");
            }
        }

        Console.WriteLine($"Przetworzono {totalCases} przypadków testowych z pliku payload.txt.");
        Console.WriteLine($"Suma kontrolna poprawna (wyniki obu podejść są identyczne): {allMatch}");
        Console.WriteLine($"Czas wykonania oryginalnej implementacji (MergeOriginal): {swOriginal.ElapsedMilliseconds} ms");
        Console.WriteLine($"Czas wykonania funkcji z QuickSortem (MergeQuickSort): {swQuickSort.ElapsedMilliseconds} ms");
    }
}