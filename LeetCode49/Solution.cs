using System;
using System.Collections.Generic;

namespace LeetCode49
{
	public class Solution
	{
		//The objective is to put "reasonable" neighbors together
		//via score
		private int ScoreWord(string source){
			const char baseLetter = 'a';
			const int lengthPrime = 7;
			const int letterPrime = 257;

			int score = lengthPrime * source.Length;

			for (int i=0; i < source.Length; i++) {
				//Sigma 257*A[i]^2 reducing collisions
				score += letterPrime * (source [i] - baseLetter) * (source [i] - baseLetter);
			}

			return score;
		}

		private bool MatchAllChar(string source, string destination){
			bool matched = true;

			if (source.Length != destination.Length) {
				matched = false;
			} else {
				LinkedList<char> destinationList = new LinkedList<char> (destination);
				for (int i=0; i < source.Length; i++) {
					LinkedListNode<char> item = destinationList.Find (source [i]);
					if (item == null) {
						matched = false;
						break;
					} else {
						if (item.Value == destinationList.First.Value) {
							destinationList.RemoveFirst ();
						} else if (item.Value == destinationList.Last.Value) {
							destinationList.RemoveLast ();
						} else {
							destinationList.Remove (item);//O(N) part we have to live with for now
						}
					}
				}
			}

			return matched;
		}

		//Create a custom iteration based on anagram
		IEnumerable<string> NextAnagram (string item, IDictionary<int,List<string>> scoreMap, IDictionary<string, int> visited)
		{
			int score = ScoreWord (item);
			//evaluate neighbors
			if (scoreMap.ContainsKey (score)) {
				foreach(string elem in scoreMap[score]) {
					//check visited
					if (visited.ContainsKey (elem)) {
						if (MatchAllChar (item, elem)) {//is an anagram
							visited [elem]--;
							if (visited [elem] == 0) {
								visited.Remove (elem);//Remove if no more
							}
							yield return elem;//This facinates me :-)
						}
					}
				}
			}
		}

		/// <summary>
		/// A freaking-fast algoritm for anagrams
		/// </summary>
		/// <returns>The anagrams.</returns>
		/// <param name="strs">An array of strings to build anagrams from</param>
		/// <remarks>O(n)</remarks>
		public IList<IList<string>> GroupAnagrams(string[] strs) {
			int[] prime = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103};//最多10609个z

			Dictionary<int,int> map = new Dictionary<int,int>(strs.Length);

			IList<IList<string>> res = new List<IList<string>>(strs.Length);

			foreach (string s in strs) {
				int key = 1;
				foreach (char c in s) {
					//II prime(Ai)
					key *= prime[c - 'a'];
				}
				IList<string> t;
				if (map.ContainsKey(key)) {
					t = res[map[key]];
				} else {
					t = new List<string>();
					res.Add(t);
					map[key] = res.Count-1;
				}
				t.Add(s);
			}
			return res;
		}

		/// <summary>
		/// A BFS-type algorithm that returns anagrams
		/// </summary>
		/// <returns>The anagrams based on strs </returns>
		/// <param name="strs">An array of string to build anagrams from</param>
		/// <remarks>O(nlogn)</remarks>
		public IList<IList<string>> GroupAnagramsOld(string[] strs) {
			IList<IList<string>> results = new List<IList<string>> (strs.Length);
			IDictionary<string, int> visited = new Dictionary<string, int> (strs.Length);
			IDictionary<int, List<string>> scoreMap = new Dictionary<int, List<string>> (strs.Length);

			foreach (string item in strs) {
				//build a map based on score
				int score = ScoreWord (item);
				if (scoreMap.ContainsKey (score)) {
					scoreMap [score].Add(item);
				} else {
					scoreMap [score] = new List<string> ();
					scoreMap [score].Add (item);
				}
				//create visited items
				//in this case, we know ahead of time
				if (visited.ContainsKey(item)) {
					visited [item]++;
				} else {
					visited.Add (item, 1);
				}
			}

			//Build anagrams
			while(visited.Count > 0){
				//The key-order matches the insertion-order
				//of the values for the kev-value pairs.
				IEnumerator<string> enumerator = visited.Keys.
					GetEnumerator();
				enumerator.MoveNext ();
				string item = enumerator.Current;

				List<string> tmpList = new List<string>();
				//NextAnagram is a custom iteration pattern
				foreach (string elem in NextAnagram (item, scoreMap, visited)){
					tmpList.Add (elem);
				}
				results.Add (tmpList);

				enumerator.Dispose ();
			}

			return results;
		}
	}
}

