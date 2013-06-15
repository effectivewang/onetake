using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class RotatedArrayFinder
    {
        public int find(int[] array) {
            if (array == null || array.Length <= 1) return -1;
            if (array[0] < array[array.Length - 1]) return -1;
            
            return find(array, 0, array.Length - 1);
        }

        private int find(int[] array, int low, int high)
        {
            if (high == low) return high;

            int mid = (low + high) / 2;
            if (array[mid] > array[array.Length - 1])
                return find(array, mid + 1, high);
            else
                return find(array, low, mid);
        }

        public void test() {
            int[] array = { 5, 6, 7, 8, 1, 2, 3, 4 };
            int[] array2 = { 1, 2, 3, 4 };
            int[] array3 = { 5, 2, 3, 4 };
            int res = find(array);
            int none = find(array2);
            int one = find(array3);
        }
    }
}
