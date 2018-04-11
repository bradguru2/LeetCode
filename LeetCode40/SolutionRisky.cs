using System;
using System.Collections.Generic;

namespace LeetCode40
{
	public class SolutionRisky {
		int HashList(IList<int> source){
			const long mersenne = 2147483647;//Hopefully a Mersenne prime is good enough;
			long hash = 257;

			foreach (int elem in source) {
				hash *= (elem + 1);//never negative but just in case 0
			}

			return (int)(hash % mersenne);
		}

		void FindUniqueCombinations(int[] candidates, int index, int target, LinkedList<int> visited, List<IList<int>> response, ISet<int> hashSet) {
			if (target == 0) {
				List<int> itemToAdd = new List<int> (visited);

				int hash = HashList (itemToAdd);

				if (!hashSet.Contains (hash)) {
					response.Add (itemToAdd);
					hashSet.Add (hash);
				}
				return ;
			}
			if (target < 0) return;
			for (int i = index; i < candidates.Length; i++){
				visited.AddLast(candidates[i]);//O(1)
				FindUniqueCombinations(candidates, i+1, target - candidates[i], visited, response, hashSet);
				visited.RemoveLast();//O(1)
			}
		}

		public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
			List<IList<int>> response = new List<IList<int>>(candidates.Length);
			LinkedList<int> path = new LinkedList<int>();
			ISet<int> hashSet = new HashSet<int> ();

			FindUniqueCombinations(candidates, 0, target, path, response, hashSet);

			return response;
		}
	}
}

