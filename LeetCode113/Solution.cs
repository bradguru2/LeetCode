using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode113
{
	public class Solution {
		public void PathSum(TreeNode root, int sum, IList<IList<int>> paths, LinkedList<int> path){
			if(root==null) return;

			if(root.left == null && root.right == null && sum - root.val == 0) {
				path.AddLast(root.val);
				paths.Add(new List<int>(path));
				path.RemoveLast();
			}
			else{
				path.AddLast(root.val);
				PathSum(root.left, sum - root.val, paths, path); PathSum(root.right, sum - root.val, paths, path);    
				path.RemoveLast();
			}
		}

		public IList<IList<int>> PathSum(TreeNode root, int sum) {
			List<IList<int>> paths = new List<IList<int>>();
			PathSum(root, sum, paths, new LinkedList<int>());
			return paths;
		}
	}
}

