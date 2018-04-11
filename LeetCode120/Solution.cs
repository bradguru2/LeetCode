using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode120
{
	/// <summary>
	/// Given a triangle, find the minimum path sum from top to bottom. 
	/// Each step you may move to adjacent numbers on the row below.
	/// </summary>
	/// <example>
	/// [
	/// [2],
	/// [3,4],
	/// [6,5,7],
	/// [4,1,8,3]
	/// ] = 11
	/// </example>
	/// <remarks>
	/// Apparently an adjacent node means +- 1 index away
	/// 
	/// </remarks>
	public class Solution {
		public int MinimumTotal(IList<IList<int>> triangle) {
			int[] dp = new int[triangle.Count + 1];//dp state-reduction array; O(mn) complexity; O(n) space
			for(int i=triangle.Count-1;i>=0;i--)
			{
				for(int j=0;j<triangle[i].Count;j++)
				{
					dp[j] = Math.Min(dp[j],dp[j+1]) + triangle[i][j];
				}
			}
			return dp[0];
		}
	}
}

