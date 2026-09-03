// Longest Substring Without Repeating Characters (Medium)
// https://leetcode.com/problems/longest-substring-without-repeating-characters/
//
// Dado un string s, encontrar la longitud del substring más largo sin caracteres repetidos.
//
// Explicación:
// Ventana deslizante: se mantiene el índice de la última aparición de cada carácter. Si un
// carácter se repite dentro de la ventana actual, el inicio salta justo después de esa aparición
// previa.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public int LengthOfLongestSubstring(string s) {
            var lastIndex = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;
            for (int i = 0; i < s.Length; i++) {
                char c = s[i];
                if (lastIndex.TryGetValue(c, out int prevIndex) && prevIndex >= start) {
                    start = prevIndex + 1;
                }
                lastIndex[c] = i;
                maxLength = Math.Max(maxLength, i - start + 1);
            }
            return maxLength;
        }
    }
}
