using System;

namespace LeetCode42
{
	class TrappingRain
	{
		public static void Main (string[] args)
		{
			int[] elems = {0,1,0,2,1,0,1,3,2,1,2,1};
			Console.WriteLine (new Solution().Trap(elems));
		}
	}
}
