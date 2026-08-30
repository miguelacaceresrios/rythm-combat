// Rotate Image (Medium)
// https://leetcode.com/problems/rotate-image/
//
// Dada una matriz n x n que representa una imagen, rotarla 90 grados en sentido horario in-place.
//
// Explicación:
// Rotar 90° en sentido horario equivale a transponer la matriz (intercambiar filas por columnas) y
// luego invertir cada fila, todo hecho in-place.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public void Rotate(int[][] matrix) {
            int n = matrix.Length;
            for (int i = 0; i < n; i++) {
                for (int j = i + 1; j < n; j++) {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }
            for (int i = 0; i < n; i++) {
                Array.Reverse(matrix[i]);
            }
        }
    }
}
