using System;

namespace LeetCode31
{
	class Solution {

		public void SortFromIndex(int[] nums, int startIndex) {
			for(int i=startIndex; i < nums.Length; i++) {
				bool swapped = false;
				int temp;

				for(int j=startIndex; j < nums.Length - (i - startIndex) - 1; j++) {
					if(nums[j] > nums[j+1]) {
						swapped = true;
						temp = nums[j];
						nums[j] = nums[j+1];
						nums[j+1] = temp;
					}
				}

				if(!swapped) {
					break;
				}
			}
		}

		public int LastIndexOf(int[] nums, int value) {
			int result = 1;

			for(int i=nums.Length - 1; i>-1; i--) {
				if(nums[i] == value) {
					result = i;
					break;
				}
			}

			return result;
		}

		public int FindNextValueFrom(int[] nums, int startIndex) {

			int localMin = int.MaxValue;

			for (int i = startIndex + 1; i < nums.Length; i++) {
				if (nums[i] > nums[startIndex] && nums[i] < localMin) {
					localMin = nums[i];
				}
			}

			return localMin;
		}

		public void NextPermutation(int[] nums) {
			int sortIndex = 0;
			int temp;

			for(int i=nums.Length - 1; i>0; i--){
				if(nums[i] > nums[i-1]) {
					int nextValue = FindNextValueFrom(nums, i - 1);
					int nextIndex = LastIndexOf(nums, nextValue);
					temp = nums[i-1];
					nums[i-1] = nums[nextIndex];
					nums[nextIndex] = temp;
					sortIndex = i;
					break;
				}
			}

			SortFromIndex(nums, sortIndex);
		}
	}
}

