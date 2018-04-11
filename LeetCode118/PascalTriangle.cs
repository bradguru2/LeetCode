using System;

namespace LeetCode.LeetCode118
{
	class PascalTriangle
	{
		public static void Main (string[] args)
		{
			const int n = 5;
			var sol = new Solution ();
			var answer = sol.Generate (n);

			for (int i = 0; i < answer.Count; i++) {
				for (int j = 0; j < answer[i].Count; j++) {
					Console.Write ("{0} ", answer [i] [j]);
				}
				Console.WriteLine ();
			}
		}
	}
}
