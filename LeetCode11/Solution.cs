using System;
using System.Linq;

namespace LeetCode11
{
	public class Solution {
		public int MaxArea(int[] height) {
			int area = 0, left = 0, right = height.Length - 1;

			//Did not need a for loop
			while (left < right) {
				area = Math.Max( area, Math.Min(height[left], height[right]) *
				           (right - left));
				if (height [left] < height [right]) {
					left ++;
				} else {
					right --;
				}
			}

			return area;
		}
	}
}

