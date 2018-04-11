using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;


namespace LeetCode6
{
	public class Solution {
		/*public string Convert(string s, int numRows) {
			StringBuilder sb = new StringBuilder ();
			StringBuilder[] sbArray = new StringBuilder[numRows];

			for (int i=0; i<numRows; i++) {
				sbArray [i] = new StringBuilder ();
			}

			bool down=true;
			int row = 0;
			int rowIncrement = (numRows > 1) ? 1 : 0;

			for (int i=0; i< s.Length; i++) {
				sbArray [row].Append (s [i]);

				if (row == 0) {
					down = true;
				} else if (row == numRows - 1) {
					down = false;
				}

				row = (down) ? row + rowIncrement : row - rowIncrement;
			}

			foreach (StringBuilder elem in sbArray) {
				sb.Append (elem);
			}

			return sb.ToString ();
		}*/

		//Strange enough this one is the fastest?
		public string Convert(string s, int numRows) {
			LinkedList<char> [] listArray = new LinkedList<char>[numRows];
			char[] master = new char[s.Length];

			for (int i=0; i<numRows; i++) {
				listArray [i] = new LinkedList<char>();
			}

			bool down=true;
			int row = 0;
			int rowIncrement = (numRows > 1) ? 1 : 0;

			for (int i=0; i< s.Length; i++) {
				listArray [row].AddLast (s [i]);

				if (row == 0) {
					down = true;
				} else if (row == numRows - 1) {
					down = false;
				}

				row = (down) ? row + rowIncrement : row - rowIncrement;
			}

			//populate char buffer
			int charCount = 0;
			foreach (LinkedList<char> elem in listArray) {
				foreach (char item in elem) {
					master[charCount++] = item;
				}
			}

			return new string(master);
		}

		/*
		public string Convert(string s, int numRows) {
			string answer = s;
			StringBuilder sb = new StringBuilder(s.Length);

			if (numRows > 1) {
				for (int i=0; i<numRows; i++) {
					for (int j=i; j<s.Length; j+=2*(numRows - 1)) {
						sb.Append (s [j]);

						if (i > 0 && i < (numRows - 1) && j + 2 * (numRows - 1 - i) < s.Length) {
							sb.Append (s [j + 2 * (numRows - 1 - i)]);
						}
					}
				}
				answer = sb.ToString();
			}

			return answer;
		}*/
	}
}

