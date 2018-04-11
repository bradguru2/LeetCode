using System;

namespace LeetCode41
{
	public class SolutionAlternative {
		public int FirstMissingPositive(int[] nums) {
			int firstMissingPositive = 1;
			bool isFlagged = true;

			int passCount = 0;
			while (isFlagged) {
				int originalMissing = firstMissingPositive;

				for (int i=0; i < nums.Length; i++) {
					if (nums [i] == firstMissingPositive) {
						isFlagged = true;
						firstMissingPositive++;
					}
					if (nums [nums.Length - 1 - i] == firstMissingPositive) {
						isFlagged = true;
						firstMissingPositive++;
					}
					if (nums [i / 2] == firstMissingPositive) {
						isFlagged = true;
						firstMissingPositive++;
					}
				}

				if (originalMissing == firstMissingPositive) {
					isFlagged = false;
				}

				passCount ++;
			}

			if (passCount > 30) {
				throw new InvalidOperationException (passCount.ToString ());
			}

			return firstMissingPositive;
		}
	}
}

