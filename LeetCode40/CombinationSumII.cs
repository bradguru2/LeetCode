using System;
using System.Collections.Generic;

namespace LeetCode40
{
	class CombinationSumII
	{
		public static void Main (string[] args)
		{
			const int target = 8;
			int[] elems = {10, 1, 2, 7, 6, 1, 5};

			Console.WriteLine("Input:");
			foreach(int elem in elems){
				Console.Write("{0} ", elem);
			}
			Console.WriteLine();

			Solution sol = new Solution();
			var results = sol.CombinationSum2(elems, target);

			Console.WriteLine("Output:");
			foreach(IList<int> list in results){
				foreach(int elem in list){
					Console.Write("{0} ", elem);
				}
				Console.WriteLine();
			}
		}
	}
}
