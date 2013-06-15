using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class SortedArrayOneFinder
    {
        public int find(int[] array)
        {
            if (array == null || array.Length == 0) return -1;

            return find(array, 0, array.Length - 1);
        }

        private int find(int[] array, int low, int high)
        {
            if (high == low) {
                if (array[low] == 1) return low;

                return -1;
            }

            int mid = (low + high) / 2;
            if (array[mid] == 0)
                return find(array, mid + 1, high);
            else
                return find(array, low, mid);
        }

        public void test()
        {
            int[] allOne = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] allZero = { 0, 0, 0, 0, 0 };
            int[] normalCase = { 0, 1, 1 };
            int[] normal2 = { 0, 0, 0, 1 };
            int[] normal5 = { 0, 0, 0, 0, 0, 1 };
            int[] normal6 = { 0, 0, 0, 0, 0, 0, 1 };
            int[] normal7 = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
            int[] normal4 = { 0, 0, 0, 0, 1 };

            int zero = find(allOne);
            int none = find(allZero);
            int first = find(normalCase);
            int three = find(normal2);
            int four = find(normal4);
            int five = find(normal5);
            int seven = find(normal7);

            int none2 = find(new int[] { });
            int none3 = find(new int[] { 0 });
            int none4 = find(new int[] { 1 });
        }

    }
}
