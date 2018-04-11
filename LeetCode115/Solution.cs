using System;

namespace LeetCode.LeetCode115
{
	/// <summary>
	/// Given a string S and a string T, count the number of distinct subsequences of S which equals T.
	/// A subsequence of a string is a new string which is formed from the original string by deleting 
	/// some (can be none) of the characters without disturbing the relative positions of the remaining
	/// characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
	/// </summary>
	/// <example>
	/// S = "rabbbit", T = "rabbit"
	/// Return 3.
	/// </example>
	public class Solution 
	{
		public int NumDistinct(string s, string t) 
		{
			int m = t.Length, n = s.Length;
			int[,] dp = new int[m+1, n+1];

			for (int i=0; i <= n; i++) {
				dp [0, i] = 1;
			}

			for (int i=1; i <= m; i++) {
				for (int j=1; j <= n; j++) {
					if (t [i - 1] == s [j - 1]) {
						dp [i, j] = dp [i - 1, j - 1] + dp [i, j - 1];
					} else {
						dp [i, j] = dp [i, j - 1];
					}
				}
			}

			return dp[m, n];
		}
	}
}

