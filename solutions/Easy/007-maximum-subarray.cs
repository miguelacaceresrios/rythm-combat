// Maximum Subarray (Easy)
// https://leetcode.com/problems/maximum-subarray/
//
// Dado un array de enteros nums, encontrar el subarray contiguo (con al menos un elemento) que
// tenga la mayor suma, y devolver esa suma.
//
// Explicación:
// Algoritmo de Kadane: en cada posición se decide si conviene extender el subarray actual o
// empezar uno nuevo desde ese elemento, guardando el máximo visto.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int MaxSubArray(int[] nums) {
            int maxSum = nums[0];
            int currentSum = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }
            return maxSum;
        }
    }
}
