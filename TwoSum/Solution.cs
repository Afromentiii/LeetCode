using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Collections.Generic;

public class TestCase
{
    public int[] nums { get; set; }
    public int target { get; set; }
}

[JsonSerializable(typeof(List<TestCase>))]
public partial class TestCaseContext : JsonSerializerContext
{
}

public class Solution 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        
        return new int[] { -1, -1 };
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        
        Console.WriteLine("--- Odczyt zewnętrznego payloadu (payload.json) ---");
        
        string payloadPath = "payload.json";
        if (!File.Exists(payloadPath))
        {
            Console.WriteLine("Błąd: Nie znaleziono pliku payload.json!");
            return;
        }

        string jsonString = File.ReadAllText(payloadPath);
        
        // Deserializacja z użyciem Source Generatora (wsparcie dla AOT)
        List<TestCase> payload = JsonSerializer.Deserialize(jsonString, TestCaseContext.Default.ListTestCase);
        
        Console.WriteLine($"Pomyślnie wczytano {payload.Count} przypadków testowych z pliku.");
        
        Console.WriteLine("\n--- Pomiar czasu wykonania algorytmu (Brute Force O(N^2)) ---");
        
        int foundCount = 0;
        int notFoundCount = 0;
        
        Stopwatch sw = Stopwatch.StartNew();
        
        foreach (var test in payload)
        {
            int[] result = solution.TwoSum(test.nums, test.target);
            if (result[0] != -1) 
                foundCount++;
            else 
                notFoundCount++;
        }
        
        sw.Stop();
        
        Console.WriteLine($"Całkowity czas dla {payload.Count} przypadków testowych: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"-> Sukces (znaleziono parę): {foundCount} razy");
        Console.WriteLine($"-> Porażka (brak pary): {notFoundCount} razy");
    }
}