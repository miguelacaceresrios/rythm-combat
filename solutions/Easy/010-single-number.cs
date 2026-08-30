// Single Number (Easy)
// https://leetcode.com/problems/single-number/
//
// Dado un array de enteros no vacío donde cada elemento aparece dos veces excepto uno, encontrar
// ese elemento único.
//
// Explicación:
// XOR entre un número y sí mismo da 0, y XOR con 0 no cambia el valor. Al aplicar XOR sobre todo
// el array, los pares se cancelan y queda el único.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int SingleNumber(int[] nums) {
            int result = 0;
            foreach (int num in nums) {
                result ^= num;
            }
            return result;
        }
    }
}
