using System;

namespace LeetCode41
{
	public class Solution {
		private int CountValidElems(int[] nums, int length)
		{
			int q = 0;

			for (int i = 0; i < length; i++) {
				if (nums [i] > 0) {
					int temp = nums [q];
					nums [q] = nums [i];
					nums [i] = temp;
					q++;
				}
			}

			return q;
		}

		public int FirstMissingPositive(int[] nums) {
			int k = CountValidElems (nums, nums.Length);
			int firstMissingIndex = k;

			for (int i=0; i < k; i++) {
				int temp = Math.Abs (nums [i]);

				//setting valid numbers to negative value
				//At the same time putting numbers in their proper index
				if (temp <= k) {
					nums [temp - 1] = (nums [temp - 1] > 0 ? -nums [temp - 1] : nums [temp - 1]);
				}
			}

			for (int i=0; i < k; i++) {
				if (nums [i] > 0) {
					firstMissingIndex = i;
					break;
				}
			}

			return firstMissingIndex + 1;
		}
	}
}

