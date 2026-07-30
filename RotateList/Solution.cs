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
    public ListNode RotateRight(ListNode head, int k) 
    {
        ListNode dummy = new ListNode(0);
        ListNode lastNode = null;
        int counter = 0;
        
        ListNode counterNode = head;
        while(counterNode != null)
        {
            counterNode = counterNode.next;
            counter++;
        }

        if (head != null && head.next != null)
        for(int i = 0; i < k % counter; i++)
        {

            lastNode = head;
            while(lastNode.next.next != null && lastNode.next != null)
                    lastNode = lastNode.next;
                    
            ListNode tempNode = lastNode.next;
            lastNode.next = null;
            dummy.next = tempNode;
            tempNode.next = head;
            head = dummy.next;

            // ListNode dbg = head;
            // Console.Write($"i={i}: ");
            // while (dbg != null) { Console.Write(dbg.val + (dbg.next != null ? " -> " : "")); dbg = dbg.next; }
            // Console.WriteLine();
        }
        return head;
    }
}

public class Program
{
    static ListNode BuildList(params int[] vals)
    {
        if (vals.Length == 0) return null;
        ListNode head = new ListNode(vals[0]);
        ListNode curr = head;
        for (int i = 1; i < vals.Length; i++)
        {
            curr.next = new ListNode(vals[i]);
            curr = curr.next;
        }
        return head;
    }

    static string ListToString(ListNode head)
    {
        if (head == null) return "[]";
        var parts = new System.Collections.Generic.List<string>();
        while (head != null)
        {
            parts.Add(head.val.ToString());
            head = head.next;
        }
        return "[" + string.Join(",", parts) + "]";
    }

    static void Test(string description, int[] values, int k, string expected)
    {
        try 
        {
            var solution = new Solution();
            ListNode result = solution.RotateRight(BuildList(values), k);
            string actual = ListToString(result);
            bool passed = actual == expected;
            Console.WriteLine($"{(passed ? "PASS" : "FAIL")} | {description}");
            if (!passed)
                Console.WriteLine($"       expected: {expected}, got: {actual}");
        } 
        catch (NotImplementedException) 
        {
            Console.WriteLine($"FAIL | {description} (NotImplementedException)");
        }
    }

    public static void Main(string[] args)
    {
        Test("k=2, list [1,2,3,4,5]", new[] { 1, 2, 3, 4, 5 }, 2, "[4,5,1,2,3]");
        Test("k=4, list [0,1,2]",      new[] { 0, 1, 2 },       4, "[2,0,1]");
        Test("k=0, no rotation",       new[] { 1, 2, 3 },       0, "[1,2,3]");
        Test("k=3, one element",       new[] { 1 },              3, "[1]");
        Test("k=length",               new[] { 1, 2, 3 },       3, "[1,2,3]");
        Test("k=2, two elements",      new[] { 1, 2 },           2, "[1,2]");
    }
}