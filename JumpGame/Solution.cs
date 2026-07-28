public class Solution 
{
    public bool CanJump(int[] nums) 
    {
        return branchTravesal(nums, 0);       
    }

    private bool branchTravesal(int[] nums, int index)
    {
        if(index >= nums.Length - 1)
            return true;
            
        if(nums[index] == 0) 
            return false;

        for (int i = nums[index]; i >= 1; i--)
        {
            int newIndex = index + i;
            if(newIndex > nums.Length - 1)
                continue;
                
            if (branchTravesal(nums, newIndex))
                return true;
        }

        return false;
    }

    public bool CanJumpMemo(int[] nums) 
    {
        bool?[] memo = new bool?[nums.Length];
        return branchTravesalMemo(nums, 0, memo);       
    }

    private bool branchTravesalMemo(int[] nums, int index, bool?[] memo)
    {
        if(index >= nums.Length - 1)
            return true;
            
        if(memo[index].HasValue)
            return memo[index].Value;

        if(nums[index] == 0) 
        {
            memo[index] = false;
            return false;
        }

        for (int i = nums[index]; i >= 1; i--)
        {
            int newIndex = index + i;
            if(newIndex > nums.Length - 1)
                continue;
                
            if (branchTravesalMemo(nums, newIndex, memo))
            {
                memo[index] = true;
                return true;
            }
        }

        memo[index] = false;
        return false;
    }

    public static void Main(string[] args)
    {
        try
        {
            var solution = new Solution();

            System.Console.WriteLine("\nWczytywanie zewnetrznej paczki testowej (payload.txt)...");
            var lines = System.IO.File.ReadAllLines("payload.txt");
            var largePayload = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                largePayload[i] = new int[parts.Length];
                for (int j = 0; j < parts.Length; j++)
                {
                    largePayload[i][j] = int.Parse(parts[j]);
                }
            }

            System.Console.WriteLine($"Paczka wczytana ({largePayload.Length} tablic - w tym ogromne wartosci i skrajne przypadki!). Rozpoczynam obliczenia...");
            
            var sw = System.Diagnostics.Stopwatch.StartNew();
            int trues = 0;
            int falses = 0;
            bool[] originalResults = new bool[largePayload.Length];
            
            for (int i = 0; i < largePayload.Length; i++)
            {
                bool result = solution.CanJump(largePayload[i]);
                originalResults[i] = result;
                if (result) trues++;
                else falses++;
            }
            sw.Stop();
            
            System.Console.WriteLine($"Czas BEZ memo: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            int truesMemo = 0;
            int falsesMemo = 0;
            int mismatches = 0;
            for (int i = 0; i < largePayload.Length; i++)
            {
                bool result = solution.CanJumpMemo(largePayload[i]);
                
                if (result != originalResults[i])
                {
                    mismatches++;
                }

                if (result) truesMemo++;
                else falsesMemo++;
            }
            sw.Stop();

            System.Console.WriteLine($"Czas Z MEMO (zapamietywanie drog): {sw.ElapsedMilliseconds} ms");
            System.Console.WriteLine($"Wyniki -> True: {truesMemo}, False: {falsesMemo}");
            
            if (mismatches == 0)
            {
                System.Console.WriteLine("SUMA KONTROLNA: ZGODNA (Obydwa algorytmy daja identyczne wyniki we wszystkich przypadkach)");
            }
            else
            {
                System.Console.WriteLine($"SUMA KONTROLNA: BLAD! Wykryto {mismatches} rozbieznosci w wynikach.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Błąd podczas testowania: {ex.Message}");
        }
    }
}