using System;
using System.Collections.Generic;

namespace LeetCode40
{

	public class SolutionDfsMistake {
		int HashList(IList<int> source){
			//int hash = 2147483647;//Hopefully a Mersenne prime is good enough;
			int hash = 257;

			foreach (int elem in source) {
				hash += elem ^ hash;
			}

			return hash;
		}

		IList<IList<int>> FindCombos(int[] candidates, int target, LinkedList<int> visitedList, ISet<int> hashSet, int index, int total){
			List<IList<int>> answer = new List<IList<int>> (candidates.Length);
		
			if (total == target && visitedList.Count > 0) {
				List<int> itemToAdd = new List<int> (visitedList);

				itemToAdd.Sort ();

				int hash = HashList (itemToAdd);

				if (!hashSet.Contains(hash)) {
					answer.Add (itemToAdd);
					hashSet.Add (hash);
				}
			} else {
				int i = index + 1;
				while (i < candidates.Length) {
					if (candidates [index] + candidates [i] <= target) {
						visitedList.AddLast (candidates [i]);
						answer.AddRange(FindCombos (candidates, 
						                            target,
						                            visitedList,
						                            hashSet,
						                            i, 
						                            total + candidates [i]));
						visitedList.RemoveLast ();
					}
					i++;
				}
			}

			return answer;
		}

		public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
			List<IList<int>> answer = new List<IList<int>> ();

			if (candidates.Length > 0) {
				LinkedList<int> visitedList = new LinkedList<int> ();
				ISet<int> hashSet = new HashSet<int> ();

				int i = 0;

				while (i < candidates.Length) {
					if (candidates [i] <= target) {
						visitedList.AddFirst (candidates [i]);
						answer.AddRange(FindCombos (candidates, 
						                            target,
						                            visitedList, 
						                            hashSet,
						                            i, 
						                            candidates [i]));
						visitedList.RemoveLast ();
					}
					i++;
				}
			}

			return answer;
		}
	}
}

