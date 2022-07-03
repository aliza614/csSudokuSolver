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
            //the missing number is 6
            var puzzle2 = new int[][]{
            new int[] {4, 3, 5, 2, 0, 9, 7, 8, 1},
            new int[] {6, 8, 2, 5, 7, 1, 4, 9, 3},
            new int[] {1, 9, 7, 8, 3, 4, 5, 6, 2},
            new int[] {8, 2, 6, 1, 9, 5, 3, 4, 7},
            new int[] {3, 7, 4, 6, 8, 2, 9, 1, 5},
            new int[] {9, 5, 1, 7, 4, 3, 6, 2, 8},
            new int[] {5, 1, 9, 3, 2, 6, 8, 7, 4},
            new int[] {2, 4, 8, 9, 5, 7, 1, 3, 6},
            new int[] {7, 6, 3, 4, 1, 8, 2, 5, 9} };
            //the above got solved by figure it out


            var puzzle3 = new int[][]{
            new int[] {4, 0, 3, 0, 0, 0, 0, 0, 0},
            new int[] {6, 8, 0, 0, 0, 0, 5, 0, 0},
            new int[] {7, 5, 0, 0, 0, 3, 0, 9, 0},
            new int[] {5, 0, 0, 0, 8, 0, 1, 3, 0},
            new int[] {0, 0, 0, 0, 9, 0, 7, 0, 2},
            new int[] {0, 1, 7, 0, 0, 5, 0, 0, 6},
            new int[] {0, 6, 0, 1, 3, 8, 9, 4, 0},
            new int[] {0, 0, 9, 0, 5, 2, 0, 6, 0},
            new int[] {0, 3, 0, 9, 0, 7, 8, 2, 5} };
            var result =csSudokuSolver(puzzle3);
            
        }

        public static int [][] csSudokuSolver(int[][] board)
        {
            if (board.Length != 9 || board[0].Length!=9) return Array.Empty<int[]>();
            bool isSolved = false;
            var possible = new List<int>[9,9];
            var list = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    possible[i,j] = list.ToList();
            }
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
                            FigureOut(board, possible,row, col);
                            
                            PrintBoard(board);
                        }
                    }
                }
            }
            return board;
        }
        public static void FigureOut(int[][] board, List<int>[,] possible,int row, int col)
        {
            List<int> myPoss = possible[row,col];

            myPoss = myPoss.Where(x => !board[row].Contains(x)).ToList();

            for (int index=0;index<myPoss.Count;index++)
            {
                for (int checkCol = 0; checkCol < 9; checkCol++)
                {
                    if (index >= myPoss.Count) break;
                    var temp = board[row][checkCol];
                    if (board[row][checkCol] == myPoss.ElementAt(index)) myPoss.RemoveAt(index);
                }
            }
            if (myPoss.Count == 1)
            {
                board[row][col] = myPoss.ElementAt(0);
                Console.WriteLine($"At {row}, {col}: {myPoss.ElementAt(0)}");
            }    
        }
        public static void FigureItOut2(int[][] board, List<int>[,] possible,int row, int col)
        {
            var myPoss=possible[row,col];
            int startRow = row / 3 * 3;
            int endRow = startRow+2;
            int startCol = col / 3 * 3;
            int endCol = startCol + 2;
            for(int i = startRow; i <= endRow; i++)
            {
                for(int j=startCol; j <= endCol; j++)
                {
                    if (board[i][j] != 0) myPoss.Remove(board[i][j]);
                }
            }
            if (myPoss.Count == 1)
            {
                board[row][col] = myPoss.ElementAt(0);
                Console.WriteLine($"At {row}, {col}: {myPoss.ElementAt(0)}");
            }
        }
        public static void PrintBoard(int[][] board)
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
