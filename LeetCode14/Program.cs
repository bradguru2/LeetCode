using System;

namespace LeetCode14
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Solution sol = new Solution ();

			string[] parms = new string[] { "AAA","AAAB","AAC" };

			Console.WriteLine(sol.LongestCommonPrefix(parms));
		}
	}
}
