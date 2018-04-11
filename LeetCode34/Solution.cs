using System;

namespace LeetCode34
{
	public class Solution {
		public int[] SearchRange(int[] nums, int target) {
			int[] answer = new int[] {-1, -1};

			//Go ahead and use built-in Binary Search
			int startingIndex = Array.BinarySearch(nums, target);

			if (startingIndex >= 0){
				//Inititially we only know one start and end
				answer[1] = startingIndex;
				answer[0] = startingIndex;

				bool advancing = true;
				int left = startingIndex - 1;
				int right = startingIndex + 1;

				//Extend out binarily to get range
				while(advancing){
					advancing = false;

					if (left > -1) {
						if (nums [left] == target) {
							answer [0] = left--;
							advancing = true;
						} else {
							left = -1;
						}
					}

					if (right < nums.Length) {
						if (nums [right] == target) {
							answer [1] = right++;
							advancing = true;
						} else {
							right = nums.Length;
						}
					}
				}

			}

			return answer;
		}
	}
}

