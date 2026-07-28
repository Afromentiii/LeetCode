using System;

public class Solution
{
    public string AddBinary(string a, string b)
    {
        return AddBinaryFaster(a, b);
    }

    public string AddBinaryFaster(string a, string b)
    {
        int maxLength = Math.Max(a.Length, b.Length);

        a = a.PadLeft(maxLength, '0');
        b = b.PadLeft(maxLength, '0');

        char[] result = new char[maxLength];
        int carry = 0;

        for (int i = maxLength - 1; i >= 0; i--)
        {
            int sum = (a[i] - '0') + (b[i] - '0') + carry;
            result[i] = (char)('0' + (sum % 2));
            carry = sum / 2;
        }

        string output = new string(result);
        return carry > 0 ? "1" + output : output;
    }

    public string AddBinaryOnlyStrings(string a, string b)
    {
        int maxLength = Math.Max(a.Length, b.Length);

        a = a.PadLeft(maxLength, '0');
        b = b.PadLeft(maxLength, '0');

        char[] aChar = a.ToCharArray();
        char[] bChar = b.ToCharArray();
        bool extraOne = false;

        for (int i = maxLength - 1; i >= 0; i--)
        {
            if (aChar[i] == '1' && bChar[i] == '1' && !extraOne)
            {
                aChar[i] = '0';
                extraOne = true;
            }
            else if (aChar[i] == '1' && bChar[i] == '1' && extraOne)
            {
                aChar[i] = '1';
                extraOne = true; 
            }
            else if ((aChar[i] == '1' || bChar[i] == '1') && !extraOne)
            {
                aChar[i] = '1';
                extraOne = false;
            }
            else if ((aChar[i] == '1' || bChar[i] == '1') && extraOne)
            {
                aChar[i] = '0';
                extraOne = true;
            }
            else if (aChar[i] == '0' && bChar[i] == '0' && extraOne)
            {
                aChar[i] = '1';
                extraOne = false; 
            }
            else if (aChar[i] == '0' && bChar[i] == '0' && !extraOne)
            {
                aChar[i] = '0';
                extraOne = false;
            }
        }

        string result = new string(aChar);

        if (extraOne)
        {
            result = "1" + result;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        try
        {
            var solution = new Solution();

            var testCases = new[]
            {
                (a: "11", b: "1", expected: "100"),
                (a: "1010", b: "1011", expected: "10101"),
                (a: "0", b: "0", expected: "0"),
                (a: "1111", b: "1111", expected: "11110"),
                (a: "1", b: "111", expected: "1000")
            };

            foreach (var (a, b, expected) in testCases)
            {
                try
                {
                    var result = solution.AddBinary(a, b);
                    var status = result == expected ? "PASS" : "FAIL";
                    Console.WriteLine($"[{status}] a=\"{a}\", b=\"{b}\" => Result=\"{result}\", Expected=\"{expected}\"");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"[TODO] a=\"{a}\", b=\"{b}\" => NotImplementedException");
                }
            }

            Console.WriteLine("\nWczytywanie zewnetrznej paczki testowej (payload.txt)...");
            var lines = System.IO.File.ReadAllLines("payload.txt");
            var largePayload = new (string a, string b)[lines.Length];
            
            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                largePayload[i] = (parts[0], parts[1]);
            }

            Console.WriteLine("Paczka wczytana. Rozpoczynam obliczenia...");
            
            long checksum1 = 0;
            var sw1 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < largePayload.Length; i++)
            {
                string result = solution.AddBinaryOnlyStrings(largePayload[i].a, largePayload[i].b);
                checksum1 += result.Length;
                foreach (char c in result)
                {
                    if (c == '1') checksum1++;
                }
            }
            sw1.Stop();
            
            long checksum2 = 0;
            var sw2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < largePayload.Length; i++)
            {
                string result = solution.AddBinaryFaster(largePayload[i].a, largePayload[i].b);
                checksum2 += result.Length;
                foreach (char c in result)
                {
                    if (c == '1') checksum2++;
                }
            }
            sw2.Stop();
            
            Console.WriteLine($"Czas przeliczania AddBinaryOnlyStrings: {sw1.ElapsedMilliseconds} ms (Suma: {checksum1})");
            Console.WriteLine($"Czas przeliczania AddBinaryFaster:      {sw2.ElapsedMilliseconds} ms (Suma: {checksum2})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"KRYTYCZNY BŁĄD: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }
}