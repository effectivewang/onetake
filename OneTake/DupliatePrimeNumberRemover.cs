using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    /// <summary>
    /// Write code to remove duplicates from array of prime numbers.
    /// </summary>
    class DupliatePrimeNumberRemover
    {
        public int[] remove(int[] array)
        {
            if(array == null || array.Length < 2) return array;
            int accu = 1;

            List<int> res = new List<int>();
            foreach (int v in array) {
                if (accu % v == 0) {
                    continue;
                }

                accu = accu * v;
                res.Add(v);
            }

            return res.ToArray();
        }

        public void test() {
            int[] primeArray = { 2, 3, 5, 7, 11, 13,13, 17, 19, 23, 31, 37, 41 };

            var res = remove(primeArray);
            AssertHelper.areEqual(res.Length, primeArray.Length - 1);

            res = remove(null);
            AssertHelper.areEqual(res, null);

            var array = new int[1] { 2 };
            res = remove(array);
            AssertHelper.areEqual(res.Length, array.Length);
            AssertHelper.areEqual(res[0], array[0]);

            array = new int[4] { 2, 3, 5, 2 };
            res = remove(array);
            AssertHelper.areEqual(res.Length, array.Length - 1);
        }
    }
}
