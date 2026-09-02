// Two Sum (Easy)
// https://leetcode.com/problems/two-sum/
//
// Dado un array de enteros nums y un entero target, devolver los índices de los dos números que
// suman target. Se asume que existe exactamente una solución y no se puede usar el mismo elemento
// dos veces.
//
// Explicación:
// Un diccionario guarda cada valor visto junto a su índice. Por cada número se busca si su
// complemento (target - num) ya apareció antes, logrando O(n) en vez de O(n²).

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int[] TwoSum(int[] nums, int target) {
            var seen = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) {
                int complement = target - nums[i];
                if (seen.TryGetValue(complement, out int idx)) {
                    return new int[] { idx, i };
                }
                seen[nums[i]] = i;
            }
            return Array.Empty<int>();
        }
    }
}
