using System;

namespace LeetCode6
{
	class MainClass
	{
		private static int Len(int z){
			return (int) Math.Log10(z)+1;
		}

		private static int DigitValue(int x, int n){
			while (n-->0) {
				x /= 10;
			}

			if (x > 9) {
				x %= 10;
			}

			return x;
		}

		public static bool IsPalindrome(int x) {
			if (x < 0) { 
				return false;
			}
			else if (x < 10){
				return true;
			}

			bool isPalindrome = true;
			int intLen = Len (x);

			for (int i=0; i< intLen / 2; i++) {
				if (DigitValue (x, i) != DigitValue (x, intLen - i - 1)) {
					isPalindrome = false;
					break;
				}
			}

			return isPalindrome;
		}

		public static void Main (string[] args)
		{
			Solution sol = new Solution ();
			//"PAYPALISHIRING", 3
			//"ABC", 2
			Console.WriteLine (IsPalindrome (1001));
			Console.WriteLine (sol.Convert("PAYPALISHIRING", 3));
		}
	}
}
