using System;

namespace LeetCode37
{
	class SudokuSolver
	{
		public static void Main (string[] args)
		{
			char[,] board = 
			{{'.','.','.','.','5','.','.','1','.'},
			 {'.','4','.','2','.','.','.','.','.'},
			 {'.','.','.','.','.','3','.','.','9'},
			 {'8','.','.','.','.','.','.','2','.'},
			 {'.','.','2','.','7','.','.','.','.'},
			 {'.','1','5','.','.','.','.','.','.'},
			 {'.','.','.','.','.','2','.','.','.'},
			 {'.','2','.','9','.','.','.','.','.'},
			 {'.','.','4','.','.','.','.','.','.'}
			};
			/*char[,] board = {
				{'1','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'},
				{'.','.','.','.','.','.','.','.','.'}
			};*/

			Console.WriteLine("Initial Board:");
			for(int m=0; m <= board.GetUpperBound(0); m++){
				for (int n=0; n <= board.GetUpperBound(1); n++){
					Console.Write("{0} ", board[m,n]);
				} 
				Console.WriteLine();
			}

			new Solution().SolveSudoku(board);

			Console.WriteLine("Solved Board:");
			for(int m=0; m <= board.GetUpperBound(0); m++){
				for (int n=0; n <= board.GetUpperBound(1); n++){
					Console.Write("{0} ", board[m,n]);
				} 
				Console.WriteLine();
			}
		}
	}
}
