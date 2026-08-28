// Best Time to Buy and Sell Stock (Easy)
// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
//
// Dado un array prices donde prices[i] es el precio de una acción en el día i, maximizar la
// ganancia eligiendo un día para comprar y otro (posterior) para vender.
//
// Explicación:
// Se recorre el array una sola vez llevando el precio mínimo visto hasta el momento y actualizando
// la ganancia máxima posible si se vendiera hoy.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class Solution {
        public int MaxProfit(int[] prices) {
            int minPrice = int.MaxValue;
            int maxProfit = 0;
            foreach (int price in prices) {
                if (price < minPrice) {
                    minPrice = price;
                } else if (price - minPrice > maxProfit) {
                    maxProfit = price - minPrice;
                }
            }
            return maxProfit;
        }
    }
}
