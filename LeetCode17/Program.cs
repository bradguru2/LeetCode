using System;

namespace LeetCode17
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Solution sol = new Solution ();
			var answer = sol.LetterCombinations ("23");

			Console.Write ("[");
			foreach (var item in answer) {
				Console.Write (" ");
				Console.Write (item);
			}
			Console.WriteLine(" ]");

		}
	}
}
