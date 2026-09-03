// Climbing Stairs (Easy)
// https://leetcode.com/problems/climbing-stairs/
//
// Se están subiendo n escalones. En cada paso se puede subir 1 o 2 escalones. Determinar de
// cuántas formas distintas se puede llegar arriba.
//
// Explicación:
// El número de formas de llegar al escalón n es la suma de las formas de llegar a n-1 y n-2
// (equivalente a Fibonacci), calculado de forma iterativa en O(n).

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int ClimbStairs(int n) {
            if (n <= 2) return n;
            int prev = 1, curr = 2;
            for (int i = 3; i <= n; i++) {
                int next = prev + curr;
                prev = curr;
                curr = next;
            }
            return curr;
        }
    }
}
