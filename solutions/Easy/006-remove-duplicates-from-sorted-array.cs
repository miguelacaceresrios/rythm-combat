// Remove Duplicates from Sorted Array (Easy)
// https://leetcode.com/problems/remove-duplicates-from-sorted-array/
//
// Dado un array ordenado nums, eliminar los duplicados in-place de forma que cada elemento único
// aparezca una sola vez, y devolver la nueva longitud.
//
// Explicación:
// Dos punteros: k marca la posición del próximo elemento único, i recorre el array. Como está
// ordenado, basta comparar contra el último elemento único escrito.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int RemoveDuplicates(int[] nums) {
            if (nums.Length == 0) return 0;
            int k = 1;
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] != nums[k - 1]) {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }
    }
}
