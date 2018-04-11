using System;

namespace LeetCode41
{
	class FirstMissingPositive
	{
		public static void Main (string[] args)
		{
			int[] input = {3, 5, 4, -2};//{6, 5, 4, 3, 2, 1};//{0,2,2,4,0,1,0,1,3};//{3,5,4,-1};//{1,2,0};

			Console.WriteLine("Input:");

			foreach(int elem in input){
				Console.Write("{0} ", elem);
			}

			Console.WriteLine();

			Console.WriteLine("The first missing positive is {0}", new Solution().FirstMissingPositive(input));
		}
	}
}
