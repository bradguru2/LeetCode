using System;

namespace LeetCode.LeetCode101
{
	/// <summary>
	/// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
	/// </summary>
	public class Solution
	{
		private bool IsPalindrome(TreeNode left, TreeNode right){
			if(left==null || right==null)
				return left==right;
			if(left.val!=right.val)
				return false;
			return IsPalindrome(left.left, right.right) && IsPalindrome(left.right, right.left);
		}

		public bool IsSymmetric (TreeNode root)
		{
			return root == null || IsPalindrome (root.left, root.right);
		}
	}
}

