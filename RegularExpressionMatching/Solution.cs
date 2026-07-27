using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
public class Solution 
{   
    public bool IsMatch(string s, string p) 
    {
        return MatchFrom(0, 0, s, p);
    }

    private bool MatchFrom(int cursorS, int cursorP, string s, string p)
    {
        // Jeśli doszliśmy do końca wzorca, sprawdzamy czy tekst też się skończył
        if (cursorP == p.Length) 
            return cursorS == s.Length;

        // Sprawdzamy czy aktualny znak pasuje (uwzględniając kropkę)
        bool firstMatch = (cursorS < s.Length) && 
                        (p[cursorP] == s[cursorS] || p[cursorP] == '.');

        // Obsługa gwiazdki '*' (sprawdzamy czy następny znak w 'p' to '*')
        if (cursorP + 1 < p.Length && p[cursorP + 1] == '*')
        {
            // OPJA 1: Gwiazdka oznacza 0 powtórzeń (cursorP przeskakuje o 2)
            // OPCJA 2: Gwiazdka zjada znak (cursorS przeskakuje o 1, cursorP zostaje)
            return MatchFrom(cursorS, cursorP + 2, s, p) || 
                (firstMatch && MatchFrom(cursorS + 1, cursorP, s, p));
        }

        // Zwykły znak lub kropka (przesuwamy oba kursory o 1)
        return firstMatch && MatchFrom(cursorS + 1, cursorP + 1, s, p);
    }

    public static void Main(string[] args)
    {
        Solution sol = new Solution();
        int passed = 0;
        int total = 0;
        
        string payloadPath = "payload.txt";
        if (!System.IO.File.Exists(payloadPath))
        {
            System.Console.WriteLine($"Nie znaleziono pliku {payloadPath}");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(payloadPath);
        System.Console.WriteLine($"--- Rozpoczynam Testy (wczytano z payload.txt) ---");
        
        Stopwatch sw = Stopwatch.StartNew();
        
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            string[] parts = line.Split(';');
            if (parts.Length != 3) continue;
            
            string tc_s = parts[0];
            string tc_p = parts[1];
            bool expected = bool.Parse(parts[2]);
            
            total++;
            
            bool result = false;
            try 
            {
                result = sol.IsMatch(tc_s, tc_p);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"\n[ERROR] s=\"{tc_s}\", p=\"{tc_p}\" - Wyjątek: {ex.GetType().Name}");
                continue;
            }
            
            if (result == expected)
                passed++;
                
            string status = result == expected ? "[PASS]" : "[FAIL]";
            System.Console.WriteLine($"\n{status} s=\"{tc_s}\", p=\"{tc_p}\" | Oczekiwano: {expected}, Otrzymano: {result}");
        }
        
        sw.Stop();
        System.Console.WriteLine($"\n========================================================");
        System.Console.WriteLine($"WYNIK KOŃCOWY: Zaliczone {passed} / {total} testów.");
        System.Console.WriteLine($"CAŁKOWITY CZAS WYKONANIA: {sw.ElapsedMilliseconds} ms");
        System.Console.WriteLine($"========================================================");
    }
}