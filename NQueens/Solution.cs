using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Solution 
{
    List<int[,]> matrixList = new List<int[,]>();
    IList<IList<string>> solutions = new List<IList<string>>();
    int result = 0;
    int currentQueens = 0;
    public IList<IList<string>> SolveNQueens(int n) 
    {
        int[,] matrix = new int[n, n];

        Backtrack(matrix, 0, 0, n);

        return solutions;
    }

    public void Backtrack(int[,] matrix, int row, int col, int max)
    {
        if (row == max)
        {
            result++;
            var board = new List<string>();
            for (int i = 0; i < max; i++)
            {
                var rowStr = "";
                for (int j = 0; j < max; j++)
                    rowStr += matrix[i, j] == 1 ? "Q" : ".";
                board.Add(rowStr);
            }
            solutions.Add(board);
            return;
        }

        if (col >= max)
            return;

        if (IsQueenSafe(matrix, row, col))
        {
            matrix[row, col] = 1;
            currentQueens++;

            // for (int i = 0; i < max; i++)
            // {
            //     for (int j = 0; j < max; j++)
            //     {
            //         Console.Write(matrix[i, j] + " ");
            //     }
            //     Console.WriteLine();
            // }
            // Console.WriteLine("---");

            Backtrack(matrix, row + 1, 0, max);

            matrix[row, col] = 0;
            currentQueens--;
        }
        Backtrack(matrix, row, col + 1, max);
    }

    private bool IsQueenSafe(int[,] matrix, int row, int col)
    {
        int colsCount = matrix.GetLength(1);

        for (int i = row - 1; i >= 0; i--)
        {
            if (matrix[i, col] == 1) return false;
        }

        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (matrix[i, j] == 1) return false;
        }

        for (int i = row - 1, j = col + 1; i >= 0 && j < colsCount; i--, j++)
        {
            if (matrix[i, j] == 1) return false;
        }

        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        var result = solution.SolveNQueens(4);
        Console.Write("[");
        for (int i = 0; i < result.Count; i++)
        {
            Console.Write("[" + string.Join(",", result[i].Select(s => $"\"{s}\"")) + "]");
            if (i < result.Count - 1) Console.Write(",");
        }
        Console.WriteLine("]");
    }
}