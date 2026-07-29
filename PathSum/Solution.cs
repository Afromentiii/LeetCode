using System;

public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution 
{
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if (root == null)
            return false;

        bool found = false;
        Travel(root, targetSum, 0, ref found);

        return found;
    }

    private void Travel(TreeNode node, int targetSum, int sum, ref bool found)
    {
        if (node == null || found)
            return;

        sum += node.val;

        if (node.left == null && node.right == null && sum == targetSum)
        {
            found = true;
            return;
        }

        Travel(node.left, targetSum, sum, ref found);
        Travel(node.right, targetSum, sum, ref found);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();

        var tree1 = new TreeNode(5, 
            new TreeNode(4, 
                new TreeNode(11, new TreeNode(7), new TreeNode(2))), 
            new TreeNode(8, 
                new TreeNode(13), new TreeNode(4, null, new TreeNode(1))));
        Console.WriteLine(solution.HasPathSum(tree1, 22)); // Oczekiwane: True

        var tree2 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        Console.WriteLine(solution.HasPathSum(tree2, 5)); // Oczekiwane: False
    }
}