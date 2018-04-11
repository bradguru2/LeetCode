using System;
using System.Text;

namespace LeetCode43
{
	class Solution {
		bool IsValidNum(string num) {
			for(int i=0; i < num.Length/2; i++) {
				if(!Char.IsDigit(num[i]) || 
				   !Char.IsDigit(num[num.Length - i - 1])) {
					return false;
				}
			}
			return num.Length > 0;
		}

		public string Multiply(string num1, string num2) {
			string answer = String.Empty;

			if(num1=="0" || num2=="0") {//x*0=0, for all x
				answer = "0";
			}
			else if(IsValidNum(num1) && IsValidNum(num2)){
				byte[] result = new byte[num1.Length + num2.Length];

				int position = result.Length - num1.Length;//seed the first position
				for(int i=num2.Length - 1; i>=0; i--) {
					position+=num1.Length - 1;
					for(int j=num1.Length - 1; j>=0; j--) {
						result[position] += (byte)((num1[j] - '0') * (num2[i] - '0'));
						result[position - 1] += (byte)(result[position] / 10);
						result[position--] %= 10;
					}
				}

				if(result[position]==0) {
					position++;
				}

				char[] answerBuffer = new char[result.Length - position];
				int k=0;
				while(position < result.Length) {
					answerBuffer[k++] = (char)(result[position++] + '0');
				}
				answer = new string(answerBuffer);
			}

			return answer;
		}
	}
}
