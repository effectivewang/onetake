using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class ClockwiseMatrixVisitor
    {
        public void visit(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix.GetLength(0);

            int left = 0;
            int right = m;
            int up = 0;
            int down = n;

            int i = 0,j = 0;
            int dirct = 0;  // 0 - Right, 1 - Down, 2 - Left, 3 - Up
            while (left != right || up != down)
            {
                if (dirct == 0) {
                    for (j = left; j < right; j++)
                        Console.Write(matrix[i][j] + " ");

                    up++;
                    j--;
                    dirct = 1;
                }
                else if (dirct == 1) {
                    for (i = up; i < down; i++)
                        Console.Write(matrix[i][j] + " ");

                    right--;
                    i--;
                    dirct = 2;
                }
                else if (dirct == 2)
                {
                    for (j = right - 1; j >= left; j--)
                        Console.Write(matrix[i][j] + " ");

                    down--;
                    j++;
                    dirct = 3;
                }
                else if (dirct == 3)
                {
                    for (i = down - 1; i >= up; i--)
                    {
                        Console.Write(matrix[i][j] + " ");
                    }

                    left++;
                    i++;
                    dirct = 0;
                }
            }
        }

        public void test()
        { 
            int[][] array = new int[5][];

            int k = 1;
            for(int i = 0; i < 5; i++) {
                array[i] = new int[5];
                for(int j = 0; j < 5; j++) {
                    array[i][j] = i + j;

                    Console.Write(array[i][j] + " ");
                }
            }

            Console.WriteLine();
            visit(array);
        }
    }
}
