using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class LinkedListNode<T>
    {
        public T Value { get; private set; }
        public LinkedListNode(T value)
        {
            this.Value = value;
        }

        public LinkedListNode<T> Next;
    }

    class PalindromStringFinder
    {
        public bool find(LinkedListNode<char> node)
        {
            if (node == null || node.Next == null) return false;

            LinkedListNode<char> slow, fast;
            slow = null;
            fast = node;

            while (fast != null && fast.Next != null)
            {
                if (slow == null && fast == node)
                {
                    slow = node;
                    fast = node.Next;
                }
                else
                {
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }
            }

            fast = slow;
            Stack<LinkedListNode<char>> lastHalf = new Stack<LinkedListNode<char>>();
            while (fast != null)
            {
                lastHalf.Push(fast);
                fast = fast.Next;
            }

            // a -> b -> c -> a -> b -> c
            LinkedListNode<char> half = lastHalf.Pop();
            slow.Next = half;
            while (lastHalf.Count > 0)
            {
                half.Next = lastHalf.Pop();
                half = half.Next;
            }
            half.Next = null;

            fast = slow.Next;
            while (fast != null)
            {
                if (fast.Value != node.Value)
                    return false;

                fast = fast.Next;
                node = node.Next;
            }

            return true;
        }

        public void test()
        {
            LinkedListNode<char> node = new LinkedListNode<char>('A');
            node.Next = new LinkedListNode<char>('B');
            node.Next.Next = new LinkedListNode<char>('C');
            node.Next.Next.Next = new LinkedListNode<char>('C');
            node.Next.Next.Next.Next = new LinkedListNode<char>('B');
            node.Next.Next.Next.Next.Next = new LinkedListNode<char>('A');

            bool res = find(node);

            AssertHelper.areEqual(true, res);
        }
    }
}
