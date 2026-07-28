using System;

public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) 
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution 
{
    public ListNode ReverseBetween(ListNode head, int left, int right) 
    {
        if (head == null || left == right) 
            return head;

        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode pre = dummy;

        for (int i = 0; i < left - 1; i++) 
        {
            pre = pre.next;
        }

        ListNode start = pre.next;
        ListNode then = start.next;

        for (int i = 0; i < right - left; i++) 
        {
            start.next = then.next;
            then.next = pre.next;
            pre.next = then;
            then = start.next;
        }

        return dummy.next;
    }

    private static ListNode BuildList(int[] values)
    {
        if (values == null || values.Length == 0) return null;
        ListNode head = new ListNode(values[0]);
        ListNode current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }
        return head;
    }

    private static string PrintList(ListNode head)
    {
        if (head == null) return "[]";
        System.Collections.Generic.List<int> result = new System.Collections.Generic.List<int>();
        while (head != null)
        {
            result.Add(head.val);
            head = head.next;
        }
        return "[" + string.Join(", ", result) + "]";
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();

        var testCases = new (int[] values, int left, int right)[]
        {
            (new int[] { 1, 2, 3, 4, 5 }, 2, 4),
            (new int[] { 5 }, 1, 1),
            (new int[] { 1, 2, 3 }, 1, 3), // odwrócenie całej listy
            (new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, 6)
        };

        Console.WriteLine("Testy dla Reverse Linked List II:");
        foreach (var test in testCases)
        {
            ListNode head = BuildList(test.values);
            Console.WriteLine($"\nLista początkowa: {PrintList(head)}, Left: {test.left}, Right: {test.right}");
            
            ListNode result = solution.ReverseBetween(head, test.left, test.right);
            Console.WriteLine($"Lista po odwróceniu: {PrintList(result)}");
        }
    }
}