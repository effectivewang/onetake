using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    using System;
    public class BinarySearchClass
    {
        public static int binary_search(int[] array, int n, int value)
        {
            //write your code here
            if (array == null || array.Length != n)
            {
                return -1;
            }

            return search(array, value, 0, n - 1);
        }

        private static int search(int[] array, int value, int start, int end)
        {
            if (end < start) return -1;

            int mid = (start + end) / 2;
            int midValue = array[mid];
            if (value == midValue)
            {
                int min = mid;
                if (array[start] == value) min = start;
                else
                {
                    for (int i = mid; i >= start; i--)
                    {
                        if (array[i] == value) min = i;
                        else break;
                    }
                }

                return min;
            }

            if (value < midValue)
            {
                return search(array, value, start, mid - 1);
            }
            else
            {
                return search(array, value, mid + 1, end);
            }
        }


        //start 提示：自动阅卷起始唯一标识，请勿删除或增加。
        public  void Run()
        {
            int n = 129;
            int m = 16; // 10000
            int i = 2;
            int j = 7;

            int mask = (1 << j) - (1 << i); // 11111110
            int result = n | ((mask & m << i));

            int max = ~0; /* All 1’s */

            // 1’s through position j, then 0’s
            int left = max - ((1 << j) - 1);

            // 1’s after position i
            int right = ((1 << i) - 1);

            // 1’s, with 0s between i and j
            mask = left | right;

            // Clear i through j, then put m in there
            result = (n & mask) | (m << i);

            //write your code here    
            int[] array = new int[5] { 1, 2, 3, 4, 5 };
            int pos = binary_search(array, 5, 3);
            System.Console.WriteLine("pos = " + (pos == 2));

            pos = binary_search(array, 4, -1);
            System.Console.WriteLine("pos = " + (pos == -1));

            pos = binary_search(array, 4, 1);
            System.Console.WriteLine("pos = " + (pos == -1));

            pos = binary_search(array, 5, 5);
            System.Console.WriteLine("pos = " + (pos == 4));

            pos = binary_search(array, 5, 1);
            System.Console.WriteLine("pos = " + (pos == 0));

            array = new int[1000];
            for (i = 0; i < array.Length; i++)
            {
                array[i] = i + 1;
            }

            for (i = 0; i < 100; i++)
            {
                Random rand = new Random(i);
                int value = rand.Next(1, array.Length);

                int index = binary_search(array, array.Length, value);
                if (index != (value - 1))
                    System.Console.Write(false);
            }

            array = new int[100];
            pos = binary_search(array, 100, 0);
            System.Console.WriteLine("pos = " + (pos == 0));

            array[0] = -11;
            array[1] = -5;
            array[2] = -3;

            pos = binary_search(array, 100, 0);
            System.Console.WriteLine("pos = " + (pos == 3));

        }
        //end //提示：自动阅卷结束唯一标识，请勿删除或增加。
    }
}
