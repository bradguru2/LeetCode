using System;
using System.Collections.Generic;

namespace LeetCode37
{
	public class Solution {
		const int numberOfCols = 9;
		const int numberOfRows = numberOfCols;
		const int numberOfCells = numberOfRows * numberOfCols;
		const int squareLength = 3;

		bool[,] xVisited;
		bool[,] yVisited;
		bool[,] zVisited;

		private bool IsValidMove(int row, int column, char digit){
			int index = digit - '1';

			if (yVisited [column, index] ||
			    xVisited [row, index] || 
			    zVisited [squareLength * (row / squareLength) + 
			          column / squareLength, index]) {
				return false;
			}

			return zVisited [squareLength * (row / squareLength) + 
			          column / squareLength, index] = 
				yVisited [column, index] = 
					xVisited [row, index] = true;
		}

		private bool Solve(char[,] board, int position){
			bool filled = true;

			if (position < numberOfCells) {
				int i = position / numberOfRows;
				int j = position % numberOfCols;

				if (board [i, j] == '.') {
					filled = false;
					for (char digit = '1'; digit <= '9'; digit++) {
						if (IsValidMove (i, j, digit)) {
							//try it
							board [i, j] = digit;
							if (Solve (board, position + 1)) {
								return true;
							}
							//did not work so restore
							int index = board [i, j] - '1';
							zVisited[squareLength * (i/squareLength) + j / squareLength, index] = 
								yVisited[j, index] = 
									xVisited[i, index] = false;
							board [i, j] = '.';
						}
					}
				} else {//look for an open cell
					return Solve (board, position + 1);
				}
			}

			return filled;
		}

		private void InitializeVisited(char[,] board){
			for (int i = 0; i < numberOfRows; i++) {
				for (int j = 0; j < numberOfCols; j++) {
					if (board [i, j] != '.') {
						int index = board [i, j] - '1';
						zVisited[squareLength * (i/squareLength) + j / squareLength, index] = 
							yVisited[j, index] = 
							xVisited[i, index] = true;
					}
				}
			}
		}

		public void SolveSudoku(char[,] board){
			if (board.Length == numberOfCells) { //Assume standard Sudoku board
				//Creating tables to use like hash sets
				xVisited = new bool[9, 9];
				yVisited = new bool[9, 9];
				zVisited = new bool[9, 9];

				InitializeVisited (board);//Initial state of board

				Solve (board, 0);
			}
		}
	}
}

