using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marathon
{
    /// <summary>
    /// Extensions making a LinkedList circular
    /// </summary>
    public static class CircularLinkedListExtension
    {
        /// <summary>
        /// Returns the next or first node in the LinkedList, treating the LinkedList as if it was circular
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static LinkedListNode<Series> NextOrFirst(this LinkedListNode<Series> current)
        {
            if (current != null)
            {
                if (current.Next == null)
                    return current.List.First;
                return current.Next;
            }
            else return null;
        }

        /// <summary>
        /// Returns the previous or last node in the LinkedList, treating the LinkedList as if it was circular
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static LinkedListNode<Series> PreviousOrLast(this LinkedListNode<Series> current)
        {
            if (current != null)
            {
                if (current.Previous == null)
                    return current.List.Last;
                return current.Previous;
            }
            else return null;
        }

    }
}
