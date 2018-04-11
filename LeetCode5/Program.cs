using System;

namespace LeetCode5
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Solution sol = new Solution ();
			//"aaaabcaaaa"
			//"cbbd"
			//"abb"
			//"a"
			//"eabcb"
			//"bb"
			Console.WriteLine(sol.LongestPalindrome("aaaabcaaaa"));
		}
	}
}
