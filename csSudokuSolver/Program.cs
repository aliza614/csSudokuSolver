using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Write a function that will solve a 9x9 Sudoku puzzle. The function will take one argument consisting of the 2D puzzle array, with the value 0 representing an unknown square.

The Sudokus tested against your function will be "easy" (i.e. determinable; there will be no need to assume and test possibilities on unknowns) and can be solved with a brute-force approach.

For Sudoku rules, see the Wikipedia article.

var puzzle = [
            [5,3,0,0,7,0,0,0,0],
            [6,0,0,1,9,5,0,0,0],
            [0,9,8,0,0,0,0,6,0],
            [8,0,0,0,6,0,0,0,3],
            [4,0,0,8,0,3,0,0,1],
            [7,0,0,0,2,0,0,0,6],
            [0,6,0,0,0,0,2,8,0],
            [0,0,0,4,1,9,0,0,5],
            [0,0,0,0,8,0,0,7,9]];

sudoku(puzzle);
/* Should return
[[5,3,4,6,7,8,9,1,2],
[6,7,2,1,9,5,3,4,8],
[1,9,8,3,4,2,5,6,7],
[8,5,9,7,6,1,4,2,3],
[4,2,6,8,5,3,7,9,1],
[7,1,3,9,2,4,8,5,6],
[9,6,1,5,3,7,2,8,4],
[2,8,7,4,1,9,6,3,5],
[3,4,5,2,8,6,1,7,9]] */
namespace csSudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var puzzle = new int[][]{
            new int[] {5, 3, 0, 0, 7, 0, 0, 0, 0},
            new int[] {6, 0, 0, 1, 9, 5, 0, 0, 0},
            new int[] {0, 9, 8, 0, 0, 0, 0, 6, 0},
            new int[] {8, 0, 0, 0, 6, 0, 0, 0, 3},
            new int[] {4, 0, 0, 8, 0, 3, 0, 0, 1},
            new int[] {7, 0, 0, 0, 2, 0, 0, 0, 6},
            new int[] {0, 6, 0, 0, 0, 0, 2, 8, 0},
            new int[] {0, 0, 0, 4, 1, 9, 0, 0, 5},
            new int[] {0, 0, 0, 0, 8, 0, 0, 7, 9} };
            var result=csSudokuSolver(puzzle);
            
        }

        public static int [][] csSudokuSolver(int[][] board)
        {
            if (board.Length != 9 || board[0].Length!=9) return Array.Empty<int[]>();
            bool isSolved = false;
            while (!isSolved)
            {
                isSolved = true;
                for(int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (board[row][col] == 0)
                        {
                            isSolved = false;
                            figureOut(board, row, col);
                            printBoard(board);
                        }
                    }
                }
            }
            return board;
        }
        public static void figureOut(int[][] board, int row, int col)
        {
            var fullRow = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var notUsed = fullRow.Where(x => !board[row].Contains(x)).ToList();

            for (int index=0;index<notUsed.Count;index++)
            {
                for (int checkRow = 0; checkRow < 9; checkRow++)
                {
                    if (index >= notUsed.Count) break;
                    var temp = board[checkRow][col];
                    if (board[checkRow][col] == notUsed.ElementAt(index)) notUsed.RemoveAt(index);
                }
            }
            if (notUsed.Count == 1)
            {
                board[row][col] = notUsed.ElementAt(0);
                Console.WriteLine($"At {row}, {col}: {notUsed.ElementAt(0)}");
            }    
        }
        public static void printBoard(int[][] board)
        {
            foreach (var collection in board)
            {
                foreach (var item in collection)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }
    }
}
