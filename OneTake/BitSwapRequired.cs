using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    /// <summary>
    /// Write a function to determine the number of bits required to convert integer A to integer B.
    /// </summary>
    class BitSwapRequired
    {
        public int bitRequired(int a, int b) {
            int count = 0;
            for (int c = a ^ b; c != 0; c = c >> 1)
                count += c & 1;

            return count;
        }

        public void test()
        {
            int c = bitRequired(31, 14);
            AssertHelper.areEqual(c, 2);
        }
    }
}
