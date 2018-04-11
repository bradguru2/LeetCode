using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode17
{
	public class Solution {
		private static Dictionary<char, string> digitMapping = new Dictionary<char, string>(10){
			{'0', "0"},
			{'1', "1"},
			{'2', "abc"},
			{'3', "def"},
			{'4', "ghi"},
			{'5', "jkl"},
			{'6', "mno"},
			{'7', "pqrs"},
			{'8', "tuv"},
			{'9', "wxyz"}
		};

		private string PrintCombination(int[] loopContainers, string digits){
			StringBuilder sb = new StringBuilder (digits.Length);

			for (int i=0; i<digits.Length; i++) {
				sb.Append (digitMapping [digits [i]] [loopContainers [i]]);
			}

			return sb.ToString ();
		}

		private int FindNextIndex(int[] loopContainers, string digits){
			int answer = -1;

			for (int z = loopContainers.Length - 1; z>=0; z--) {
				if (loopContainers [z] < digitMapping[digits[z]].Length - 1) { //Remain within Array bounds
					answer = z;
					break;
				}
			}

			return answer;		
		}

		private void IncrementLoop(int[] loopContainers,int index){
			loopContainers [index]++;

			for (int i=index + 1; i<loopContainers.Length; i++) {
				loopContainers [i] = 0;
			}
		}

		public List<string> LetterCombinations(string digits) {
			List<string> answer = new List<string> ();
			int[] loopContainers = new int[digits.Length];

			if (loopContainers.Length > 0) {

				int nextIndex = FindNextIndex (loopContainers, digits);

				while (nextIndex > -1) {

					answer.Add (PrintCombination (loopContainers, digits));

					IncrementLoop (loopContainers, nextIndex);

					nextIndex = FindNextIndex (loopContainers, digits);
				}

				answer.Add (PrintCombination (loopContainers, digits));
			}

			return answer;
		}
	}
}

