// N-Queens (Hard)
// https://leetcode.com/problems/n-queens/
//
// Dado un entero n, devolver todas las formas distintas de ubicar n reinas en un tablero de
// ajedrez n x n de modo que ninguna reina ataque a otra.
//
// Explicación:
// Backtracking fila por fila: se prueba cada columna válida para la reina actual, marcando
// columnas y diagonales ocupadas, y se retrocede cuando ninguna posición de una fila es viable.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Hard
{
    public class Solution {
        public IList<IList<string>> SolveNQueens(int n) {
            var results = new List<IList<string>>();
            var columns = new HashSet<int>();
            var diagonals = new HashSet<int>();
            var antiDiagonals = new HashSet<int>();
            var board = new int[n];

            void Backtrack(int row) {
                if (row == n) {
                    var solution = new List<string>();
                    for (int r = 0; r < n; r++) {
                        var rowChars = new char[n];
                        Array.Fill(rowChars, '.');
                        rowChars[board[r]] = 'Q';
                        solution.Add(new string(rowChars));
                    }
                    results.Add(solution);
                    return;
                }
                for (int col = 0; col < n; col++) {
                    int diag = row - col;
                    int antiDiag = row + col;
                    if (columns.Contains(col) || diagonals.Contains(diag) || antiDiagonals.Contains(antiDiag)) {
                        continue;
                    }
                    columns.Add(col);
                    diagonals.Add(diag);
                    antiDiagonals.Add(antiDiag);
                    board[row] = col;

                    Backtrack(row + 1);

                    columns.Remove(col);
                    diagonals.Remove(diag);
                    antiDiagonals.Remove(antiDiag);
                }
            }

            Backtrack(0);
            return results;
        }
    }
}
