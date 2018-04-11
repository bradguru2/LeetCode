using System;

namespace LeetCode.LeetCode115
{
	class DistinctSubsequences
	{
		public static void Main (string[] args)
		{
			const string source = "rabbbit";
			const string target = "rabbit";
			Console.WriteLine (new Solution ().NumDistinct (source, target));
		}
	}
}
