// Reverse Integer (Easy)
// https://leetcode.com/problems/reverse-integer/
//
// Dado un entero de 32 bits con signo x, devolver x con sus dígitos invertidos. Si el resultado se
// sale del rango de un entero de 32 bits, devolver 0.
//
// Explicación:
// Se acumula el resultado en un long para detectar overflow de 32 bits antes de convertir de
// vuelta a int, evitando que el propio cálculo desborde.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int Reverse(int x) {
            long result = 0;
            while (x != 0) {
                int digit = x % 10;
                x /= 10;
                result = result * 10 + digit;
                if (result > int.MaxValue || result < int.MinValue) {
                    return 0;
                }
            }
            return (int)result;
        }
    }
}
