using System;

namespace LeetCode.LeetCode415
{
	public class Solution {
		bool IsValidNum(string num) {
			for(int i=0; i < num.Length/2; i++) {
				if(!Char.IsDigit(num[i]) || 
				   !Char.IsDigit(num[num.Length - i - 1])) {
					return false;
				}
			}
			return num.Length > 0;
		}

		public string AddStrings(string num1, string num2) {
			string answer = String.Empty;
			const byte ten = 10;

			if(IsValidNum(num1) && IsValidNum(num2)){
				int len = num1.Length >= num2.Length ? num1.Length : num2.Length;
				byte[] result = new byte[len + 1];
				int position = len;
				int i = num1.Length - 1;
				int j = num2.Length - 1;

				while(position > 0){
					if(i >= 0){
						result[position]+=(byte)(num1[i--] - '0');
					}

					if(j >= 0){
						result[position]+=(byte)(num2[j--] - '0');
					}

					if(result[position] >= ten){                
						result[position - 1] += (byte)(result[position]/ten);
						result[position] %= ten;
					}
					position--;
				}

				if(result[position]==0){
					position++;
				}

				char[] buff = new char[result.Length - position];

				i=0;
				while(position < result.Length){
					buff[i++] = (char)(result[position++] + '0');
				}

				answer = new string(buff);
			}

			return answer;
		}
	}
}