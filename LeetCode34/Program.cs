using System;

namespace LeetCode34
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] nums = {2, 2};
			const int target = 2;

			int[] result = new Solution().SearchRange(nums, target);

			foreach(int item in result){
				Console.Write(item + " ");
			}
		}
	}
}
