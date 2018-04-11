using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode15
{
	/// <summary>
	/// Given an array S of n integers, are there elements a, b, c 
	/// in S such that a + b + c = 0? Find all unique triplets in 
	/// the array which gives the sum of zero.
	/// </summary>
	/// <example>
	/// S = [-1, 0, 1, 2, -1, -4],
	/// A solution set is:
	/// [
	///  [-1, 0, 1],
	///  [-1, -1, 2]
	/// ]
	/// </example>
	class Solution {

		public IList<IList<int>> ThreeSum(int[] nums) 
		{
			List<IList<int>> answer = new List<IList<int>> ();
			int n = nums.Length;
			Array.Sort (nums);
		
			for (int i = 0; i < n-2 && nums[i] < 1; i++) {
				if (i == 0 || (i > 0 && nums[i] != nums[i-1])) {
					int lo = i+1, hi = n-1, sum = 0 - nums[i];
					while (lo < hi) {
						if (nums[lo] + nums[hi] == sum) {
							List<int> row = new List<int> ();
							row.Add (nums [i]);
							row.Add (nums [lo]);
							row.Add (nums [hi]);
							answer.Add (row);
							while (lo < hi && nums[lo] == nums[lo+1]) lo++;
							while (lo < hi && nums[hi] == nums[hi-1]) hi--;
							lo++; hi--;
						} else if (nums[lo] + nums[hi] < sum) lo++;
						else hi--;
					}
				}
			}
			return answer;
		}
	}
}

