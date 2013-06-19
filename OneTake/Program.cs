/* Sample program illustrating input/output */
using System;
using System.Collections.Generic;
using System.IO;
using OneTake;

class Solution
{
    private static String[] readArguments() {
        String count = Console.ReadLine().Trim();
        int c = int.Parse(count);

        String[] args = new String[c];
        for (int i = 0; i < c; i++) {
            args[i] = Console.ReadLine();
        }

        return args;
    }

    static void Main(String[] args)
    {
        //String[] arguments = readArguments();
        MaxProfitCaculator c = new MaxProfitCaculator();
        c.test();

        Console.Read();
   }
}