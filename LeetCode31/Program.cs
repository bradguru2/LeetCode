using System;

namespace LeetCode31
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] nums = {1,3,2};
			Solution sol = new Solution();

			Console.WriteLine("Nums before processing:");
			foreach(int num in nums) {
				Console.Write(num);
				Console.Write(" ");
			}
			Console.WriteLine();

			sol.NextPermutation(nums);

			Console.WriteLine("Nums after processing:");
			foreach (int num in nums) {
				Console.Write(num);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
	}
}
