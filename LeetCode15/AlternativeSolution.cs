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
	class AlternativeSolution {

		private IList<int[]> TwoSum (int[] nums, int a, int target)
		{
			Dictionary<int, int> map = new Dictionary<int, int> ();
			List<int[]> results = new List<int[]> ();
			int n = nums.Length;

			for (int i = a; i < n; i++) {
				int complement = target - nums [i];
				if (map.ContainsKey (complement)) {
					results.Add(new int[2] { map[complement], i });
				}
				map [nums[i]] = i;
			}

			return results;
		}

		private long GetAnagramHash(string a, string b, string c)
		{
			long result = a.GetHashCode ();
			result += b.GetHashCode ();
			result += c.GetHashCode ();
			return result;
		}

		public IList<IList<int>> ThreeSum(int[] nums) 
		{
			List<IList<int>> answer = new List<IList<int>> ();
			int n = nums.Length;
			HashSet<long> visited = new HashSet<long> ();

			for (int i=0; i < n; i++) {
				int target = 0 - nums [i];//b + c = 0 - a
				IList<int[]> result = TwoSum (nums, i + 1, target);

				foreach(int[] item in result) {
					if (visited.Add(GetAnagramHash(nums[i].ToString(), 
					                               nums[item[0]].ToString(), 
					                               nums[item[1]].ToString()))) {
						List<int> row = new List<int> ();
						row.Add (nums[i]);
						row.Add (nums[item[0]]);
						row.Add (nums [item [1]]);
						answer.Add (row);
					}
				}
			}

			return answer;
		}
	}
}

