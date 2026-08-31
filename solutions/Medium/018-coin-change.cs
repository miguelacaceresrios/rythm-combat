// Coin Change (Medium)
// https://leetcode.com/problems/coin-change/
//
// Dado un array de denominaciones de monedas coins y un monto total amount, devolver la cantidad
// mínima de monedas necesarias para completar ese monto, o -1 si no es posible.
//
// Explicación:
// Programación dinámica bottom-up: dp[i] guarda el mínimo de monedas para formar el monto i,
// calculado a partir de subproblemas menores (i - coin) ya resueltos.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Medium
{
    public class Solution {
        public int CoinChange(int[] coins, int amount) {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            for (int i = 1; i <= amount; i++) {
                foreach (int coin in coins) {
                    if (coin <= i) {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
