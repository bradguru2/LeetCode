using System;
using System.Collections.Generic;

namespace LeetCode40
{
	public class Solution {
		public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
			Array.Sort(candidates);//Big hit here but helps eliminate duplicate combos

			List<IList<int>> response = new List<IList<int>>(candidates.Length);
			LinkedList<int> path = new LinkedList<int>();

			FindUniqueCombinations(candidates, 0, target, path, response);

			return response;
		}

		void FindUniqueCombinations(int[] candidates, int index, int target, LinkedList<int> visited, List<IList<int>> response) {
			if (target == 0) {
				response.Add(new List<int>(visited));
				return ;
			}
			if (target < 0) return;
			for (int i = index; i < candidates.Length; i++){
				if (i > index && candidates[i] == candidates[i-1]) continue;//Requires the array to be sorted
				visited.AddLast(candidates[i]);//O(1)
				FindUniqueCombinations(candidates, i+1, target - candidates[i], visited, response);
				visited.RemoveLast();//O(1)
			}
		}
	}
}

