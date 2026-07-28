public class Solution 
{
    public bool IsPowerOfTwo(int n) 
    {
        if (n <= 0) 
            return false;
        if (n == 1) 
            return true;
        if (n % 2 != 0) 
            return false;

        return IsPowerOfTwo(n / 2);
    }

    public bool IsPowerOfTwoFaster(int n)
    {
        return (n > 0) && ((n & (n - 1)) == 0);        
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] testCases = new int[] 
        {
            1, 2, 3, 4, 16, 218, 1024, 1048576, 1048577, 
            0, -1, -16, 2147483647, 1073741824
        };

        System.Console.WriteLine("Przykładowe wyniki:");
        foreach (int n in testCases)
        {
            System.Console.WriteLine($"n = {n,-12} -> {solution.IsPowerOfTwo(n)}");
        }

        // Aby czas był w ogóle zauważalny dla tak prostej operacji, wykonujemy ją wielokrotnie
        int iterations = 5_000_000;
        
        bool[] originalResults = new bool[testCases.Length];
        var sw = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            for (int j = 0; j < testCases.Length; j++)
            {
                originalResults[j] = solution.IsPowerOfTwo(testCases[j]);
            }
        }
        sw.Stop();
        
        System.Console.WriteLine($"\nCzas BEZ optymalizacji bitowej (rekurencja): {sw.ElapsedMilliseconds} ms");

        int mismatches = 0;
        sw.Restart();
        for (int i = 0; i < iterations; i++)
        {
            for (int j = 0; j < testCases.Length; j++)
            {
                bool result = solution.IsPowerOfTwoFaster(testCases[j]);
                // Sprawdzanie różnic tylko za pierwszym obrotem
                if (i == 0 && result != originalResults[j]) 
                {
                    mismatches++;
                }
            }
        }
        sw.Stop();

        System.Console.WriteLine($"Czas Z optymalizacja bitowa O(1): {sw.ElapsedMilliseconds} ms");
        
        if (mismatches == 0)
        {
            System.Console.WriteLine("SUMA KONTROLNA: ZGODNA (Oba algorytmy zwaracaja ten sam wynik)");
        }
        else
        {
            System.Console.WriteLine($"SUMA KONTROLNA: BŁĄD! Wykryto {mismatches} rozbieznosci.");
        }
    }
}