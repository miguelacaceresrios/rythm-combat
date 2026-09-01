// Longest Palindromic Substring (Medium)
// https://leetcode.com/problems/longest-palindromic-substring/
//
// Dado un string s, devolver el substring palíndromo más largo dentro de s.
//
// Explicación:
// Se expande desde cada posible centro (par o impar) hacia afuera mientras los caracteres
// coincidan, guardando el palíndromo más largo encontrado.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public string LongestPalindrome(string s) {
            if (string.IsNullOrEmpty(s)) return "";
            int start = 0, maxLength = 1;

            void Expand(int left, int right) {
                while (left >= 0 && right < s.Length && s[left] == s[right]) {
                    if (right - left + 1 > maxLength) {
                        start = left;
                        maxLength = right - left + 1;
                    }
                    left--;
                    right++;
                }
            }

            for (int i = 0; i < s.Length; i++) {
                Expand(i, i);
                Expand(i, i + 1);
            }
            return s.Substring(start, maxLength);
        }
    }
}
