using System;

namespace LeetCode.LeetCode124
{
	/// <summary>
	/// Given a binary tree, find the maximum path sum. For this problem, a path is defined
	/// as any sequence of nodes from some starting node to any node in the tree along the 
	/// parent-child connections. The path must contain at least one node and does not need 
	/// to go through the root.
	/// </summary>
	public class Solution 
	{
		private int MaxPathSum(ref int max, TreeNode root)
		{
			if(root == null)
				return 0;
			int leftMax =  Math.Max(0, MaxPathSum(ref max, root.left));
			int rightMax = Math.Max(0, MaxPathSum(ref max, root.right));
			max = Math.Max(max,  root.val + leftMax + rightMax);
			return root.val + Math.Max(leftMax, rightMax);
		}

		public int MaxPathSum(TreeNode root) 
		{
			int max = int.MinValue;
			MaxPathSum(ref max, root);
			return max;
		}

	}
}

