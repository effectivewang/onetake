using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    /// <summary>
    /// There is an array of stock prices, it start from the 9:30 AM, and end 3 PM, Caculate the max profilt if we buy and sell today.
    /// </summary>
    class MaxProfitCaculator
    {
        public int caculate(int[] array) {
            if (array == null || array.Length < 2) return 0;
           
            int maxProfit = 0;
            int min = int.MaxValue;

            for (int i = 0; i < array.Length; i++) {
                if (min > array[i]) min = array[i];

                maxProfit = array[i] - min;
            }

            return maxProfit;
        }

        public void test() { 
            int res = caculate(new int[10] {15,13,11,5,6,7,8,1,10,12});
            AssertHelper.areEqual(res, 11);
        }
    }
}
