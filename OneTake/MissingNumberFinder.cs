using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class MissingNumberFinder
    {
        public int find(int[] array)
        {
            int res = 0;

            for (int i = 0; i < array.Length; i++) {
                int pos = array[i];
                res = res ^ pos;
            }

            return res;
        }

        public void test()
        {
            int[] numbers = new int[1000];

            int missing = (int)(DateTime.Now.Ticks % 1000);
            for (int i = 0; i < 1000; i++)
            {
                if (missing != i)
                    numbers[i] = i;
                else
                    numbers[i] = 0;
            }

            int res = find(numbers);

            AssertHelper.assert(res == missing, "succeed!");
        }
    }
}
