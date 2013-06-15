using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class FiveMaxGradeStudentFinder
    {
        int[] maxFive;

        public int[] findMaxFive(int[] students)
        {
            if (students == null || students.Length <= 5)
                return students;

            maxFive = new int[5];
            for (int i = 0; i < students.Length; i++)
            {
                if (i < 5)
                {
                    addMax(students[i]);
                }
                else if (students[i] > maxFive[maxFive.Length - 1])
                {
                    addMax(students[i]);
                }
            }

            return maxFive;
        }

        private void addMax(int value)
        {
            for (int i = 0; i < maxFive.Length; i++)
            {
                if (value > maxFive[i])
                {
                    for (int j = maxFive.Length - 1; j > i; j--)
                    {
                        maxFive[j] = maxFive[j - 1];
                    }
                    maxFive[i] = value;


                    break;
                }
            }
        }

        public void test()
        {
            for (int count = 0; count < 1000; count++)
            {
                int[] students = NumberGenerator.Instance.GetRandIntegers(count);
                int[] maxFive = findMaxFive(students);

                if (count == 0) {
                    AssertHelper.assert(students == null && maxFive == null, "Correct");
                    continue;
                }
                else if (count < 6)
                {
                    AssertHelper.assert(students == maxFive, "Correct");
                    continue;
                }

                Array.Sort(students);

                bool succeed = true;
                for (int i = 0; i < maxFive.Length; i++)
                {
                    if (maxFive[i] != students[students.Length - 1 - i])
                        succeed = false;
                }

                AssertHelper.assert(succeed, "Correct");
            }
        }
    }
}
