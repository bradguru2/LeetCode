using System;
using System.Collections.Generic;

namespace LeetCode.LeetCode18
{
	public class Solution {

		private IList<IList<int>> KSum(int[] nums, int target, int k, int index) {
			int len = nums.Length;
			List<IList<int>> res = new List<IList<int>>();
			if(index >= len) {
				return res;
			}
			if(k == 2) {
				int i = index, j = len - 1;
				while(i < j) {
					//find a pair
					if(target - nums[i] == nums[j]) {
						List<int> row = new List<int> ();
						row.Add(nums[i]);
						row.Add(target-nums[i]);
						res.Add(row);
						//skip duplication
						while(i<j && nums[i]==nums[i+1]) i++;
						while(i<j && nums[j-1]==nums[j]) j--;
						i++;
						j--;
						//move left bound
					} else if (target - nums[i] > nums[j]) {
						i++;
						//move right bound
					} else {
						j--;
					}
				}
			} else{
				for (int i = index; i < len - k + 1; i++) {
					//use current number to reduce ksum into k-1sum
					IList<IList<int>> temp = KSum(nums, target - nums[i], k-1, i+1);
					if(temp.Count > 0){
						//add previous results
						foreach (IList<int> t in temp) {
							t.Add(nums[i]);
						}
						res.AddRange(temp);
					}
					while (i < len-1 && nums[i] == nums[i+1]) {
						//skip duplicated numbers
						i++;
					}
				}
			}
			return res;
		}

		public IList<IList<int>> FourSum(int[] nums, int target) {
			Array.Sort(nums);
			return KSum(nums, target, 4, 0);
		}

	}
}

