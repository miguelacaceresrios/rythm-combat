// Median of Two Sorted Arrays (Hard)
// https://leetcode.com/problems/median-of-two-sorted-arrays/
//
// Dados dos arrays ordenados nums1 y nums2 de tamaños m y n, devolver la mediana de los dos arrays
// combinados, en O(log(m+n)).
//
// Explicación:
// Búsqueda binaria sobre el array más chico para encontrar un corte (partición) tal que todos los
// elementos a la izquierda de ambos arrays combinados sean menores o iguales a los de la derecha.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Hard
{
    public class Solution {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            if (nums1.Length > nums2.Length) {
                return FindMedianSortedArrays(nums2, nums1);
            }
            int m = nums1.Length, n = nums2.Length;
            int low = 0, high = m;
            int half = (m + n + 1) / 2;

            while (low <= high) {
                int cut1 = (low + high) / 2;
                int cut2 = half - cut1;

                int left1 = cut1 == 0 ? int.MinValue : nums1[cut1 - 1];
                int left2 = cut2 == 0 ? int.MinValue : nums2[cut2 - 1];
                int right1 = cut1 == m ? int.MaxValue : nums1[cut1];
                int right2 = cut2 == n ? int.MaxValue : nums2[cut2];

                if (left1 <= right2 && left2 <= right1) {
                    if ((m + n) % 2 == 0) {
                        return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                    }
                    return Math.Max(left1, left2);
                } else if (left1 > right2) {
                    high = cut1 - 1;
                } else {
                    low = cut1 + 1;
                }
            }
            throw new ArgumentException("Los arrays de entrada no están ordenados.");
        }
    }
}
