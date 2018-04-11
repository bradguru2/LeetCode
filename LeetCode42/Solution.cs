using System;

namespace LeetCode42
{
	public class Solution {
		public int Trap(int[] height) {
			int level = 0, water = 0, left = 0, n = height.Length;
			while (--n>=0) {
				int lower = height[left] < height[left + n] ? height[left++] : height[left + n];

				if (lower > level) level = lower;

				water += level - lower;
			}
			return water;
		}
	}
}