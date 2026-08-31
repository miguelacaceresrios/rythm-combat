// Palindrome Number (Easy)
// https://leetcode.com/problems/palindrome-number/
//
// Dado un entero x, devolver true si x es un número palíndromo, es decir, si se lee igual al
// derecho y al revés.
//
// Explicación:
// Los números negativos nunca son palíndromos. Para el resto, se invierten los dígitos usando long
// para evitar overflow y se compara contra el original.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public bool IsPalindrome(int x) {
            if (x < 0) return false;
            long original = x;
            long reversed = 0;
            long n = x;
            while (n != 0) {
                reversed = reversed * 10 + n % 10;
                n /= 10;
            }
            return reversed == original;
        }
    }
}
