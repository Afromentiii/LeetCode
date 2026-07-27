#nullable disable

using System.Collections.Generic;
using System.Diagnostics;

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution 
{
    public IList<int> InorderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        Traverse(root, result);
        return result;
    }

    private void Traverse(TreeNode node, List<int> result)
    {
        if (node == null)
            return;

        Traverse(node.left, result); 
        result.Add(node.val);        
        Traverse(node.right, result);
    }
}

public class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        // Przypadek 1: [1, null, 2, 3]
        TreeNode root1 = new TreeNode(1);
        root1.right = new TreeNode(2);
        root1.right.left = new TreeNode(3);

        // Przypadek 2: Drzewo puste
        TreeNode root2 = null;

        // Przypadek 3: Drzewo z 1 elementem [1]
        TreeNode root3 = new TreeNode(1);

        // Przypadek 4: Pełne drzewo binarne [4, 2, 6, 1, 3, 5, 7]
        // Odpowiada to drzewu:
        //       4
        //     /   \
        //    2     6
        //   / \   / \
        //  1   3 5   7
        TreeNode root4 = new TreeNode(4);
        root4.left = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        root4.right = new TreeNode(6, new TreeNode(5), new TreeNode(7));

        // Testujemy za pomocą metody pomocniczej liczącej czas
        RunTest(solution, root1, "Test 1 [1, null, 2, 3]");
        RunTest(solution, root2, "Test 2 [] (Puste)");
        RunTest(solution, root3, "Test 3 [1]");
        RunTest(solution, root4, "Test 4 [Pełne drzewo binarne]");
    }

    private static void RunTest(Solution solution, TreeNode root, string testName)
    {
        Stopwatch sw = Stopwatch.StartNew();
        IList<int> result = solution.InorderTraversal(root);
        sw.Stop();
        
        System.Console.WriteLine($"{testName}: [{string.Join(", ", result)}]");
        System.Console.WriteLine($"Czas wykonania: {sw.Elapsed.TotalMilliseconds:F4} ms\n");
    }
}