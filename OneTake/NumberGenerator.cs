using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class NumberGenerator
    {
        public static NumberGenerator Instance = new NumberGenerator();

        private NumberGenerator() { }

        public int[] GetRandIntegers(int count)
        {
            if (count == 0) return null;

            int[] list = new int[count];

            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < count; i++)
            {
                list[i] = rand.Next(1000);
            }

            return list;
        }
    }

}
