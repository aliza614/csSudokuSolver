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
            var puzzle2a = new int[][]{
            new int[] {0, 3, 5, 2, 0, 9, 7, 8, 1},
            new int[] {6, 8, 2, 5, 7, 1, 4, 9, 3},
            new int[] {1, 9, 7, 8, 3, 4, 5, 6, 2},
            new int[] {8, 2, 6, 1, 9, 5, 3, 4, 7},
            new int[] {3, 7, 4, 6, 8, 2, 9, 1, 5},
            new int[] {9, 5, 1, 7, 4, 3, 6, 2, 8},
            new int[] {5, 1, 9, 3, 2, 6, 8, 7, 4},
            new int[] {2, 4, 8, 9, 5, 7, 1, 3, 6},
            new int[] {7, 6, 3, 4, 1, 8, 2, 5, 9} };


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
            var puzzle4 = new int[][]
                {   new int[]{2,0,0,0,1,0,0,7,8 },
                    new int[]{0,0,8,0,0,0,4,0,9 },
                    new int[]{4,3,0,9,2,0,0,6,1 },
                    new int[]{1,0,0,6,0,0,9,8,4 },
                    new int[]{9,0,0,0,3,0,2,0,7 },
                    new int[]{0,0,2,0,0,9,6,1,0 },
                    new int[]{0,7,0,0,8,0,0,0,6 },
                    new int[]{8,0,0,3,0,0,7,0,5 },
                    new int[]{6,4,9,0,5,0,0,0,2 }
            };
            PrintBoard(puzzle3);
            Console.WriteLine("Now Solve it:");
            csSudokuSolver3(puzzle3);
            PrintBoard(puzzle3);
            
        }

        public static void PrintBoard(int[][] board)
        {
            /*
            foreach (var collection in board)
            {
                foreach (var item in collection)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            */
            for(int row = 0; row < board.Length; row++)
            {
                for(int col = 0; col < board[row].Length; col++)
                {
                    Console.Write(board[row][col]);
                    if (col % 3 == 2) Console.Write("|");
                }
                Console.WriteLine();
                if(row%3==2)
                {
                    for (int col = 0; col < board[row].Length+2; col++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine("|") ;
                }
            }
        }
       
        public static bool csSudokuSolver3(int[][] board)
        {
            while (HasEmptyPlaces(board))
            {
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {

                        if (board[row][col] == 0)
                        {
                            List<int> possible = new List<int>();
                            for (int option = 1; option <= 9; option++)
                            {
                                if (Works3(board, option, row, col))
                                {
                                    board[row][col] = option;
                                    if (csSudokuSolver3(board))
                                    {
                                        possible.Add(option);
                                    }
                                    board[row][col] = 0;

                                }
                            }
                            if (possible.Count == 0) return false;
                            if (possible.Count == 1)
                            {
                                board[row][col] = possible[0];
                                return true;
                            }
                            if (possible.Count > 1)
                            {
                                board[row][col] = 0;
                                return true;
                            }
                        }
                    }

                }
            }
            return true;
        }
        public static bool HasEmptyPlaces(int[][] puzzle)
        {
            for(int r=0; r<puzzle.Length; r++)
            {
                for (int c=0; c<puzzle[r].Length; c++)
                {
                    if (puzzle[r][c] == 0) return true;
                }
            }
            return false;
        }
        public static bool Works3(int[][] puzzle, int option, int row, int col)
        {
            if (IsInCol3(puzzle, col, option)) return false;
            if(IsInRow3(puzzle, row, option)) return false;
            if (IsInBox3(puzzle, row, col, option)) return false;
            
            return true;

        }
        public static bool IsInCol3(int[][]puzzle,int col, int option)
        {

            for (int r = 0; r < puzzle.Length; r++)
            {
                if (puzzle[r][col] == option)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsInRow3(int[][] puzzle, int row, int option)
        {
            for (int c = 0; c < puzzle.Length; c++)
            {
                if (puzzle[row][c] == option)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsInBox3(int[][] puzzle, int row, int col, int option)
        {
            int startRow = row / 3 * 3;
            int startCol = col / 3 * 3;
            int endRow = startRow + 2;
            int endCol = startCol + 2;
            for (int r = startRow; r <= endRow; r++)
                for (int c = startCol; c <= endCol; c++)
                    if (puzzle[r][c] == option && c != col && r != row)
                        return true;
            return false;
        }
    }
}
