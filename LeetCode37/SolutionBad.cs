using System;

namespace LeetCode37
{
	public class SolutionBad {
		private void StoreSquare(char [,] board, char[,] storage, int squareNumber){
			const int numberOfCols = 3;
			const int numberOfRows = numberOfCols;
			const int maxPosition = numberOfRows * numberOfCols;

			for (int i=0; i < numberOfRows; i++) {
				for (int j=0; j < numberOfCols; j++) {
					storage [i, j] = board [i + numberOfCols * (squareNumber / numberOfRows), 
					                        j + numberOfCols*(squareNumber % numberOfCols)];
				}
			}
		}

		private void RestoreSquare(char [,] board, char[,] storage, int squareNumber){
			const int numberOfCols = 3;
			const int numberOfRows = numberOfCols;
			const int maxPosition = numberOfRows * numberOfCols;

			for (int i=0; i < numberOfRows; i++) {
				for (int j=0; j < numberOfCols; j++) {
					 board [i + numberOfCols * (squareNumber / numberOfRows), 
					        j + numberOfCols*(squareNumber % numberOfCols)] = storage [i, j];
				}
			}
		}

		private bool FillSquare(char[,] board, int squareNumber, int position){
			const int numberOfCols = 3;
			const int numberOfRows = numberOfCols;
			const int maxPosition = numberOfRows * numberOfCols;
			bool filled = true;

			if (position < maxPosition) {
				int i = position / numberOfRows + numberOfCols*(squareNumber/numberOfRows);
				int j = position % numberOfCols + numberOfCols*(squareNumber % numberOfCols);

				if (board [i, j] == '.') {
					filled = false;
					for (char digit = '1'; digit <= '9'; digit++) {
						if (IsValidMove (board, i, j, digit)) {
							board [i, j] = digit;
							if (FillSquare (board, squareNumber, position + 1)) {
								return true;
							}
						}
					}
				} else {
					return FillSquare (board, squareNumber, position + 1);
				}
			}

			return filled;
		}

		private bool IsValidMove(char[,] board, int row, int column, char digit){
			const int numberOfCols = 9;
			const int squareLength = 3;

			for(int i=0; i < numberOfCols; i++){
				if (board [row, i] == digit) {
					return false;
				}
				if (board [i, column] == digit) {
					return false;
				}
				//*Integer division truncates
				if (board [squareLength * (row / squareLength) + i / squareLength, 
				           squareLength * (column / squareLength) + i % squareLength] == digit) {
					return false;
				}
			}

			return true;
		}

		private bool Solve(char[,] board, int position){
			const int numberOfCols = 9;
			const int numberOfRows = numberOfCols;
			const int maxPosition = numberOfRows * numberOfCols;
			const int squareLength = 3;
			bool filled = true;

			if (position < maxPosition) {
				int i = position / numberOfRows;
				int j = position % numberOfCols;

				if (board [i, j] == '.') {
					filled = false;
					for (char digit = '1'; digit <= '9'; digit++) {
						if (IsValidMove (board, i, j, digit)) {
							char [,] storage = new char[squareLength, squareLength];
							StoreSquare (board, storage, position/numberOfCols);
							board [i, j] = digit;
							if (FillSquare(board, position/numberOfCols, 0)) {
								if (Solve (board, position + squareLength)) {
									return true;
								}
								return Solve (board, position + 1);
							}
							RestoreSquare (board, storage, position/numberOfCols);
						}
					}
				} else {
					return Solve (board, position + 1);
				}
			}

			return filled;
		}

		public void SolveSudoku(char[,] board){
			if (board.Length == 81) { //we deal with standard Sudoku board
				Solve (board, 0);
			}
		}
	}
}

