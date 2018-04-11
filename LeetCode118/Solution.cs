using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode118
{
	/// <summary>
	///Given numRows, generate the first numRows of Pascal's triangle.
	/// </summary>
	/// <example>
	/// (n=5)
	/// [
	/// [1],
	/// [1,1],
	/// [1,2,1],
	/// [1,3,3,1],
	/// [1,4,6,4,1]
	/// ]
	/// </example>
	public class Solution 
	{
		public IList<IList<int>> Generate(int numRows) {
			List<IList<int>> rows = new List<IList<int>> ();

			for (int i=0; i < numRows; i++) {
				List<int> row = new List<int> ();
				row.Add (1);

				for (int j=1; j < i; j++) {
					row.Add (rows [i - 1] [j] + rows [i - 1] [j - 1]);
				}

				if (i > 0) {
					row.Add (1);
				}

				rows.Add (row);
			}

			return rows;
		}
	}
}

