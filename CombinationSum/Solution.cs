using System;
using System.Collections.Generic;

public class Solution 
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        var combinationsForSum = new List<IList<int>>[target + 1];
        for (int currentSum = 0; currentSum <= target; currentSum++) 
            combinationsForSum[currentSum] = new List<IList<int>>();
        
        
        combinationsForSum[0].Add(new List<int>());
        
        foreach (int candidate in candidates) 
        {
            for (int currentSum = candidate; currentSum <= target; currentSum++) 
            {
                foreach (var combination in combinationsForSum[currentSum - candidate]) 
                {
                    var newCombination = new List<int>(combination);
                    newCombination.Add(candidate);
                    combinationsForSum[currentSum].Add(newCombination);
                }
            }
        }
        
        return combinationsForSum[target];
    }
}

class Program {
    static void Main() {
        Solution solution = new Solution();
        
        int[] candidates1 = { 2, 3, 6, 7 };
        int target1 = 7;
        var result1 = solution.CombinationSum(candidates1, target1);
        Console.WriteLine("Test 1:");
        PrintResult(result1);

        int[] candidates2 = { 2, 3, 5 };
        int target2 = 8;
        var result2 = solution.CombinationSum(candidates2, target2);
        Console.WriteLine("Test 2:");
        PrintResult(result2);
        
        int[] candidates3 = { 2 };
        int target3 = 1;
        var result3 = solution.CombinationSum(candidates3, target3);
        Console.WriteLine("Test 3:");
        PrintResult(result3);
    }
    
    static void PrintResult(IList<IList<int>> result) {
        foreach (var combination in result) {
            Console.WriteLine("[" + string.Join(", ", combination) + "]");
        }
        Console.WriteLine();
    }
}
