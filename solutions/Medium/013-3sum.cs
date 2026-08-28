// 3Sum (Medium)
// https://leetcode.com/problems/3sum/
//
// Dado un array de enteros nums, devolver todos los tripletes únicos [nums[i], nums[j], nums[k]]
// tales que i != j != k y su suma sea 0.
//
// Explicación:
// Con el array ordenado, se fija un número y se buscan los otros dos con dos punteros desde los
// extremos. Saltar valores repetidos evita tripletes duplicados en el resultado.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++) {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1, right = nums.Length - 1;
                while (left < right) {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0) {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    } else if (sum < 0) {
                        left++;
                    } else {
                        right--;
                    }
                }
            }
            return result;
        }
    }
}
