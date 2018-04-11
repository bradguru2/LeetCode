using System;
using System.Text;

namespace LeetCode43
{
	public class SolutionOriginal {
		string Add(string num1, string num2){
			int carry = 0;
			StringBuilder sb = new StringBuilder ();

			//Left-pad with zeroes
			if (num1.Length < num2.Length) {
				for(int i=num1.Length ; i < num2.Length; i++){
					sb.Append ('0');
				}
				sb.Append (num1);
				num1 = sb.ToString ();
				sb.Clear ();
			} else if (num2.Length < num1.Length) {
				for(int i=num2.Length ; i < num1.Length; i++){
					sb.Append ('0');
				}
				sb.Append (num2);
				num2 = sb.ToString ();
				sb.Clear ();
			}

			for (int i=num1.Length - 1; i >= 0; i--) {
				int digit1 = carry;
				int digit2 = 0;

				digit2 += num2 [i] - '0';

				digit1 += num1 [i] - '0';

				digit1 += digit2;

				if(digit1 >= 10 & i > 0){
					digit1 -= 10;
					carry = 1;
				}
				else{
					carry = 0;
				}

				sb.Insert(0,digit1);
			}

			return sb.ToString();
		}

		bool IsValidNum(string str){
			bool isValid = str.Length > 0;

			for (int i=0; i <= str.Length/2; i++) {
				if(!Char.IsDigit(str[i]) || 
				   !Char.IsDigit(str[str.Length - i - 1])){
					isValid = false;
					break;
				}
			}

			return isValid;
		}

		public string Multiply(string num1, string num2) {
			StringBuilder sb = new StringBuilder ();
			int carry = 0;
			string intermediate = "0";

			if (IsValidNum (num1) && IsValidNum (num2) && num1!="0" && num2!="0") {
				for (int i=num1.Length - 1; i >= 0; i--) {
					for (int j=num2.Length - 1; j >= 0; j--) {
						int digit1 = num1 [i] - '0';
						int digit2 = num2 [j] - '0';
						digit1 *= digit2;
						digit1 += carry;

						if (digit1 >= 10 && j!=0) {
							carry = digit1 / 10;
							digit1 = digit1 - carry * 10;
						} else {
							carry = 0;
						}
						sb.Insert (0, digit1);
					}

					for (int j=num1.Length - 1; j > i; j--){
						sb.Append (0);
					}

					intermediate = Add(intermediate, sb.ToString());
					sb.Clear ();
				}
			}

			return intermediate;
		}
	}
}

