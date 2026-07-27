#nullable disable
using System.Diagnostics;
using System.IO;
using System.Text;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode SwapPairs(ListNode head)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode cursor = dummy;

        while (cursor.next != null && cursor.next.next != null)
        {
            ListNode temp = cursor.next.next; // B
            cursor.next.next = temp.next;     // A -> C
            temp.next = cursor.next;          // B -> A
            cursor.next = temp;               // prev -> B

            cursor = cursor.next.next;    
        }

        return dummy.next;
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        
        if (!File.Exists("payload.txt"))
        {
            System.Console.WriteLine("Brak pliku payload.txt do wczytania!");
            return;
        }

        string[] lines = File.ReadAllLines("payload.txt");
        System.Console.WriteLine($"Wczytano {lines.Length} linii testowych (przykładów) z pliku payload.txt.");
        
        ListNode[] testCases = new ListNode[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            testCases[i] = ParseList(lines[i]);
        }

        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < testCases.Length; i++)
        {
            solution.SwapPairs(testCases[i]);
        }
        sw.Stop();
        
        System.Console.WriteLine("====================================================");
        System.Console.WriteLine($"Wspólny czas obliczeń całej paczki testów: {sw.Elapsed.TotalMilliseconds:F4} ms");
    }

    private static ListNode ParseList(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;
        
        string[] parts = line.Split(',');
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        
        foreach (string part in parts)
        {
            if (int.TryParse(part.Trim(), out int val))
            {
                current.next = new ListNode(val);
                current = current.next;
            }
        }
        
        return dummy.next;
    }
}