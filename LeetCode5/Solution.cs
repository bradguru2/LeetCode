using System;

namespace LeetCode5
{
	public class Solution {
		private int lo, maxLen, mid;

		public Solution(){
			lo = 0;
			maxLen = -1;
		}

		public string LongestPalindrome(string s) {
			int len = s.Length;
			mid = len / 2;

			if (len < 2)
				return s;

			for (int i = 0; i < len-1; i++) {
				ExtendPalindrome(s, i, i);  //assume odd length, try to extend Palindrome as possible
				ExtendPalindrome(s, i, i+1); //assume even length.
			}
			return s.Substring(lo,  maxLen);
		}

		private void ExtendPalindrome(string s, int j, int k) {
			int localMaxima = (j < mid ? 2*(j+1) : 2*(s.Length - k));

			if (localMaxima > maxLen) {//Otherwise, max has been found
				while (j >= 0 && k < s.Length && s[j] == s[k]) {
					j--;
					k++;
				}
				if (maxLen < k - j - 1) {
					lo = j + 1;
					maxLen = k - j - 1;
				}
			}
		}
	}

//	public class Solution
//	{
//		private bool IsPalindrome (string s, int startIndex, int strLen)
//		{
//			bool isPalindrome = true;
//			int n = startIndex + strLen - 1;
//
//			for (int i=startIndex; i< startIndex+strLen/2; i++) {
//				if (s [i] != s [n--]) {
//					isPalindrome = false;
//					break;
//				}
//			}
//
//			return isPalindrome;
//		}
//
//
//		private Tuple<int,int> PalindromeSubw (string s, int start, int end)
//		{
//			int maxLen = 0;
//			int startIndex = -1;
//
//			for (int i=start; i<end; i++) {
//				int x = end - i;
//
//				while (x>maxLen) {
//					if (IsPalindrome (s, i, x)) {
//						if (x > maxLen) {
//							maxLen = x;
//							startIndex = i;
//						}
//						break;
//					}
//					x--;
//				}
//
//				if (i >= end - maxLen) {
//					break;//Shortcut by logic, if we already have the largest one.
//				}
//			}
//
//			return new Tuple<int,int> (maxLen, startIndex);
//		}
//
//		private Tuple<int,int> PalindromeSub (string s, int start, int strLen)
//		{
//			int mid = (start + strLen) / 2;
//			Tuple<int,int> maxLen = new Tuple<int,int> (0, 0);
//			Tuple<int,int> leftResult, rightResult;
//
//			if (strLen - start > 1) {
//				leftResult = PalindromeSub (s, start, mid);
//				rightResult = PalindromeSub (s, mid, strLen);
//
//				maxLen = (leftResult.Item1 > rightResult.Item1) ? leftResult : rightResult;
//
//				for (int i=start; i < mid; i++) {
//					for (int j=strLen; j>mid; j--) {
//						if (j - i > maxLen.Item1) {
//							if (IsPalindrome (s, i, j - i)) {
//								if (j - i > maxLen.Item1) {
//									maxLen = new Tuple<int,int> (j - i, i);
//									break;//Largest found
//								}
//							}
//						} else {
//							break;//Largest Found
//						}
//					}
//				}
//			}
//
//			return maxLen;
//		}
//
//		public string LongestPalindrome (string s)
//		{
//			string longestPalindrome = "";
//			int strLen = s.Length;
//			Tuple<int,int> maxLen = new Tuple<int,int> (0, 0);
//
//			if (strLen > 1) {
//				maxLen = PalindromeSub (s, 0, strLen);
//			}
//
//			if (maxLen.Item1 == 0 && strLen > 0) {
//				longestPalindrome = s [0] + "";
//			} else if (strLen > 0) {
//				longestPalindrome = s.Substring (maxLen.Item2, maxLen.Item1);
//			}
//			return longestPalindrome;
//		}
//	}
}

