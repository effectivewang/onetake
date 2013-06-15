using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class MaxHeap
    {
        public int[] heapArray;
        private int index;

        public MaxHeap(int n)
        {
            heapArray = new int[n];
        }

        public int Max
        {
            get { return heapArray[0]; }
        }

        public int Add(int v)
        {
            if (IsEmpty) heapArray[0] = v;

            bool isLast = index + 1 == heapArray.Length;
            if (isLast)
            {
                Remove();
            }

            return Add(v, isLast ? index : index++);
        }

        private int Add(int v, int i)
        {
            int parent = i / 2;
            while (heapArray[i] > heapArray[parent] && i != 0)
            {
                int temp = heapArray[i];
                heapArray[i] = heapArray[parent];
                heapArray[parent] = temp;

                i = parent;
                parent = i / 2;
            }

            return v;
        }

        public bool IsEmpty { get { return Max == 0; } }

        public void Remove()
        {
            index--;

        }
    }
    class KSmallestFinder
    {
        public int find(int[] array, int k)
        {
            if (array == null || array.Length == 0) return -1;

            SortedSet<int> queue = new SortedSet<int>();
            int maxItem = array[0];
            queue.Add(array[0]);

            foreach (int v in array)
            {
                if (queue.Count < k)
                    queue.Add(v);
                // can enqueue
                else if (v < queue.Max)
                {
                    queue.Remove(queue.Max);
                    queue.Add(v);
                }
            }

            int res = -1;
            foreach (var v in queue) {
                if (--k == 0) { 
                    res = v;
                    break;
                }
            }

            return res;
        }

        public void test() {
            int[] array = { 1, 3, 5, 7, 22, 10, 23, 25, 190 };
            AssertHelper.assert(find(array, 3) == 5, "True");
            AssertHelper.assert(find(array, 1) == 1, "True");
            AssertHelper.assert(find(array, 6) == 22, "True");
            AssertHelper.assert(find(array, 7) == 23, "True");
            AssertHelper.assert(find(array, 8) == 25, "True");
            AssertHelper.assert(find(array, 9) == 190, "True");
        }
    }
}
