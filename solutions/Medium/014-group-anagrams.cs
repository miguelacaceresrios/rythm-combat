// Group Anagrams (Medium)
// https://leetcode.com/problems/group-anagrams/
//
// Dado un array de strings, agrupar los anagramas juntos. Se puede devolver el resultado en
// cualquier orden.
//
// Explicación:
// Dos strings son anagramas si sus caracteres ordenados son iguales. Esa versión ordenada se usa
// como clave de un diccionario para agrupar los strings originales.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            var groups = new Dictionary<string, List<string>>();
            foreach (var str in strs) {
                var chars = str.ToCharArray();
                Array.Sort(chars);
                var key = new string(chars);
                if (!groups.ContainsKey(key)) {
                    groups[key] = new List<string>();
                }
                groups[key].Add(str);
            }
            return groups.Values.Select(g => (IList<string>)g).ToList();
        }
    }
}
