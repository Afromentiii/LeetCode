#nullable disable

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
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) 
        {
            ListNode head = new ListNode(0);
            ListNode current = head;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            current.next = (list1 != null) ? list1 : list2;

            return head.next;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Solution solution = new Solution();

            // Przypadek 1: Typowe listy (1->2->4 oraz 1->3->4)
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            PrintList("Przypadek 1", solution.MergeTwoLists(l1, l2));

            // Przypadek 2: Jedna lista pusta (null oraz 0)
            ListNode l3 = null;
            ListNode l4 = new ListNode(0);
            PrintList("Przypadek 2", solution.MergeTwoLists(l3, l4));

            // Przypadek 3: Obie listy puste (null oraz null)
            ListNode l5 = null;
            ListNode l6 = null;
            PrintList("Przypadek 3", solution.MergeTwoLists(l5, l6));

            // Przypadek 4: Nierówne listy (2 oraz 1->3->5)
            ListNode l7 = new ListNode(2);
            ListNode l8 = new ListNode(1, new ListNode(3, new ListNode(5)));
            PrintList("Przypadek 4", solution.MergeTwoLists(l7, l8));
        }

        private static void PrintList(string testName, ListNode node)
        {
            System.Console.Write(testName + ": ");
            if (node == null)
            {
                System.Console.WriteLine("null");
                return;
            }
            while (node != null)
            {
                System.Console.Write(node.val + (node.next != null ? " -> " : ""));
                node = node.next;
            }
            System.Console.WriteLine();
        }
    }
