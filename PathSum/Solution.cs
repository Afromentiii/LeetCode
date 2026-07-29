public class Solution 
{
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        if (root == null || targetSum == 0) return false;
        
        int sum = 0;
        Traverse(root, ref sum, targetSum);

        if(sum == targetSum)
            return true;
        return false;
    }


    private void Traverse(TreeNode node, ref int sum, int targetSum)
    {
        if (node == null) return;

        sum += node.val;
        
        Traverse(node.left, ref sum, targetSum); 
        Traverse(node.right, ref sum, targetSum);
    }
}