#nullable disable
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
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        return TwoTreeTraversal(p, q);
    }

    private bool TwoTreeTraversal(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
            return true;
        
        if (p == null || q == null)
            return false;
            
        if (p.val != q.val)
            return false;

        return TwoTreeTraversal(p.left, q.left) && TwoTreeTraversal(p.right, q.right);
    }
}

class Program 
{
    static void Main() 
    {
        Solution solution = new Solution();

        TreeNode p1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        TreeNode q1 = new TreeNode(1, new TreeNode(2), new TreeNode(3));
        System.Console.WriteLine(solution.IsSameTree(p1, q1));

        TreeNode p2 = new TreeNode(1, new TreeNode(2));
        TreeNode q2 = new TreeNode(1, null, new TreeNode(2));
        System.Console.WriteLine(solution.IsSameTree(p2, q2));
        
        TreeNode p3 = new TreeNode(1, new TreeNode(2), new TreeNode(1));
        TreeNode q3 = new TreeNode(1, new TreeNode(1), new TreeNode(2));
        System.Console.WriteLine(solution.IsSameTree(p3, q3));
    }
}