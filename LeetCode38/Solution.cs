using System;
using System.Text;

namespace LeetCode38
{
	public class Solution {
		public string CountAndSay(int n) {
			if(n==1)  {
				return "1";
			}
			else{
				string digits = "1";//starting digits

				for(int j = 1; j < n; j++){
					StringBuilder sb = new StringBuilder();

					int i = 0;
					while (i < digits.Length) {
						int k = 0;
						char previousDigit = digits [i];
						//Count consecutive digits
						while (i + k < digits.Length && digits[i+k] == previousDigit) {
							previousDigit = digits [i + k];
							k++;
						}
						if (k > 1) {
							sb.Append (k);
							sb.Append (digits [i]);
							i += k;
						} else {
							sb.Append ('1');
							sb.Append (digits [i]);
							i++;
						}
					}

					digits = sb.ToString ();
				}

				return digits;
			}
		}
	}
}

