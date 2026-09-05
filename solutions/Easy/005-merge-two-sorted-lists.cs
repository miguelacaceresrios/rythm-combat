// Merge Two Sorted Lists (Easy)
// https://leetcode.com/problems/merge-two-sorted-lists/
//
// Dadas las cabezas de dos listas enlazadas ordenadas, fusionarlas en una sola lista ordenada y
// devolver su cabeza.
//
// Explicación:
// Se usa un nodo dummy y un puntero current que siempre enlaza el nodo más chico entre l1 y l2. Al
// terminar uno de los dos, se cuelga el resto del otro.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Easy
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
            var dummy = new ListNode(0);
            var current = dummy;
            while (l1 != null && l2 != null) {
                if (l1.val <= l2.val) {
                    current.next = l1;
                    l1 = l1.next;
                } else {
                    current.next = l2;
                    l2 = l2.next;
                }
                current = current.next;
            }
            current.next = l1 ?? l2;
            return dummy.next;
        }
    }
}
