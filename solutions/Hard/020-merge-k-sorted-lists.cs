// Merge k Sorted Lists (Hard)
// https://leetcode.com/problems/merge-k-sorted-lists/
//
// Dado un array de k listas enlazadas, cada una ordenada, fusionarlas en una sola lista ordenada y
// devolverla.
//
// Explicación:
// Una cola de prioridad (min-heap) mantiene siempre accesible el nodo más chico entre las cabezas
// de las k listas. Requiere .NET 6+ por el uso de PriorityQueue.

using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyCodingBot.Solutions.Hard
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
        public ListNode MergeKLists(ListNode[] lists) {
            var queue = new PriorityQueue<ListNode, int>();
            foreach (var node in lists) {
                if (node != null) {
                    queue.Enqueue(node, node.val);
                }
            }

            var dummy = new ListNode(0);
            var current = dummy;
            while (queue.Count > 0) {
                var node = queue.Dequeue();
                current.next = node;
                current = current.next;
                if (node.next != null) {
                    queue.Enqueue(node.next, node.next.val);
                }
            }
            return dummy.next;
        }
    }
}
