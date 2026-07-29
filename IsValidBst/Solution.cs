using System;

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
    public bool IsValidBST(TreeNode root)
    {
        return IsValidTravel(root, long.MinValue, long.MaxValue);
    }

    private bool IsValidTravel(TreeNode root, long min, long max)
    {
        if (root == null)
            return true;

        if (root.val <= min || root.val >= max)
            return false;

        return IsValidTravel(root.left, min, root.val) && IsValidTravel(root.right, root.val, max);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();

        var tree1 = new TreeNode(2, new TreeNode(1), new TreeNode(3));
        Console.WriteLine(solution.IsValidBST(tree1));

        var tree2 = new TreeNode(5, new TreeNode(1), new TreeNode(4, new TreeNode(3), new TreeNode(6)));
        Console.WriteLine(solution.IsValidBST(tree2));
    }
}