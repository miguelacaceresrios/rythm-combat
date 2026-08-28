// Trapping Rain Water (Hard)
// https://leetcode.com/problems/trapping-rain-water/
//
// Dado un array de enteros no negativos que representa un mapa de elevación donde el ancho de cada
// barra es 1, calcular cuánta agua de lluvia queda atrapada después de llover.
//
// Explicación:
// Dos punteros desde los extremos: el agua atrapada en una posición depende del menor entre el
// máximo a su izquierda y el máximo a su derecha, así que se avanza siempre desde el lado con
// menor altura máxima.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Hard
{
    public class Solution {
        public int Trap(int[] height) {
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            int water = 0;
            while (left < right) {
                if (height[left] <= height[right]) {
                    leftMax = Math.Max(leftMax, height[left]);
                    water += leftMax - height[left];
                    left++;
                } else {
                    rightMax = Math.Max(rightMax, height[right]);
                    water += rightMax - height[right];
                    right--;
                }
            }
            return water;
        }
    }
}
