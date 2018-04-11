using System;
using System.Text;

namespace LeetCode14
{
	public class Solution
	{
		public string LongestCommonPrefix(string[] strs)
		{
			string previous = string.Empty;

			if (strs.Length > 0) {
				previous = strs [0];

				StringBuilder sb = new StringBuilder ();

				for (int i=1; i < strs.Length; i++) {
					int lengthToUse = (previous.Length < strs [i].Length) ? previous.Length : strs[i].Length;

					for (int j=0; j < lengthToUse; j++) {
						if (strs [i] [j] == previous [j]) {
							sb.Append (previous [j]);
						} 
						else {
							break;
						}
					}

					if (sb.Length > 0) {
						if (sb.Length != previous.Length) {//Then we reset previous
							previous = sb.ToString ();
						}
						sb.Clear ();
					} 
					else {
						previous = string.Empty;
						break;
					}
				}
			}

			return previous;
		}
	}
}

