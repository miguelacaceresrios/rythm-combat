// Product of Array Except Self (Medium)
// https://leetcode.com/problems/product-of-array-except-self/
//
// Dado un array nums, devolver un array answer tal que answer[i] sea el producto de todos los
// elementos de nums excepto nums[i], sin usar el operador de división y en O(n).
//
// Explicación:
// Se calcula primero el producto de todos los elementos a la izquierda de cada posición, y luego
// se multiplica por el producto acumulado de los elementos a la derecha, sin usar división.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public int[] ProductExceptSelf(int[] nums) {
            int n = nums.Length;
            int[] result = new int[n];
            result[0] = 1;
            for (int i = 1; i < n; i++) {
                result[i] = result[i - 1] * nums[i - 1];
            }
            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--) {
                result[i] *= rightProduct;
                rightProduct *= nums[i];
            }
            return result;
        }
    }
}
