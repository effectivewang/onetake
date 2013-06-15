using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class MedianFinder
    {
        public int find(int[] array, int[] array2)
        {
            if ((array == null && array2 == null) || (array == null && array2.Length == 0)
                  || (array.Length == 0 && array2.Length == 0)
                  || (array2 == null && array.Length == 0))
                throw new ArgumentNullException(); ;

            if (array.Length == 0) return array2[array2.Length / 2];
            if (array2.Length == 0) return array[array.Length / 2];

            int i = array.Length / 2;
            int j = array2.Length / 2;

            int median = array[i];
            int median2 = array2[j];

            if (median == median2) return median;
            median = find(array, i, array2, j);

            return median;
        }


        public int find(int[] array, int i, int[] array2, int j)
        {
            int m, m2 = 0;

            m = array[i];
            m2 = array2[j];

            int total = array.Length + array2.Length;
            bool isOdd = total % 2 == 1; // 是否为奇数

            int left, right;
            if (isOdd)
            {
                left = i + j;
                right = total - (i + j);
            }
            else { 
            }

            return m;
        }

        public void test()
        {
            for (int i = 0; i < 10; i++)
                testSingle();
        }

        public void testSingle()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            SortedSet<int> list = new SortedSet<int>();
            SortedSet<int> list2 = new SortedSet<int>();

            for (int i = 0; i < random.Next(50); i++)
            {
                int temp = random.Next(1000);
                if (!list.Contains(temp))
                    list.Add(temp);
            }
            for (int i = 0; i < random.Next(50); i++)
            {
                int temp = random.Next(1000);
                if (!list2.Contains(temp))
                    list2.Add(temp);
            }
            int median = find(list.ToArray(), list2.ToArray());

            int lessThan = 0;
            int moreThan = 0;

            foreach (var v in list)
            {
                if (v <= median) lessThan++;
                else moreThan++;
            }

            foreach (var v in list2)
            {
                if (v <= median) lessThan++;
                else moreThan++;
            }

            AssertHelper.assert(lessThan == moreThan || Math.Abs(lessThan - moreThan) == 1, "Less and More should have the same count.");
        }
    }
}