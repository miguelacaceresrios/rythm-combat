// Valid Parentheses (Easy)
// https://leetcode.com/problems/valid-parentheses/
//
// Dado un string s que contiene solo los caracteres '(', ')', '{', '}', '[' y ']', determinar si
// el string es válido: cada paréntesis abierto se cierra con el mismo tipo y en el orden correcto.
//
// Explicación:
// Una pila guarda los símbolos de apertura. Al encontrar un cierre, debe coincidir con el tope de
// la pila; si no coincide o la pila está vacía, el string es inválido.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public bool IsValid(string s) {
            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };
            foreach (char c in s) {
                if (pairs.ContainsValue(c)) {
                    stack.Push(c);
                } else if (pairs.ContainsKey(c)) {
                    if (stack.Count == 0 || stack.Pop() != pairs[c]) {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
