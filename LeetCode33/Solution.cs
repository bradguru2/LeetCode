using System;

namespace LeetCode33
{
	public class Solution {
		int SearchHybridBinary (int[] nums, int low, int high, int target)
		{
			const int strategyPivot = 50;
			int len = high - low + 1, answer = -1, mid = (high + low)/2;
			bool searchedLow = false;

			if (len <= strategyPivot) {
				answer = Array.IndexOf (nums, target, low, len);
			} else {
				if (nums [mid] > target || (nums[low] < target && nums[mid] < target && nums[high] < target)) {
					answer = SearchHybridBinary (nums, low, mid - 1, target);
					searchedLow = true;
				}

				if (answer == -1) {
					answer = SearchHybridBinary (nums, mid, high, target);
				}

				if (answer == -1 && !searchedLow){
					answer = SearchHybridBinary (nums, low, mid - 1, target);
				}
			}

			return answer;
		}

		/*public int Search(int[] nums, int target) {
		    int lo = 0, hi = nums.Length - 1;
            while (lo < hi) {
                int mid = (lo + hi) / 2;
                if ((nums[0] > target) ^ (nums[0] > nums[mid]) ^ (target > nums[mid]))
                    lo = mid + 1;
                else
                    hi = mid;
            }
            return lo == hi && nums[lo] == target ? lo : -1;    	
		}*/

		/*public int Search(int[] nums, int target) {
			return Array.IndexOf (nums, target);//really?
		}*/

		public int Search(int[] nums, int target) {
			return SearchHybridBinary(nums, 0, nums.Length - 1, target);
		}
	}
}

