using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode94
{
	/// <summary>
	/// Given a binary tree, return the inorder traversal of its nodes' values.
	/// </summary>
	/// <example>
	/// Given binary tree [1,null,2,3],
	/// 1
    ///	 \
	///   2
	///  /
	/// 3
	// return [1,3,2].
	/// </example>
	public class Solution {
		public IList<int> InorderTraversal(TreeNode root) {
			Stack<TreeNode> stack = new Stack<TreeNode> ();
			TreeNode cur = root;
			IList<int> values = new List<int> ();

			while (cur != null || stack.Count > 0) {
				while (cur != null) {
					stack.Push (cur);
					cur = cur.left;
				}
				cur = stack.Pop ();
				values.Add (cur.val);
				cur = cur.right;
			}

			return values;
		}
	}
}

