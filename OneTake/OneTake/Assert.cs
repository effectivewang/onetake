using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class AssertHelper
    {
        public static void assert(bool condition, string message) {
            if (!condition)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);
        }

        public static void areEqual<T>(T expected, T actual) {
            bool condition = false;

            if(expected == null && actual == null) condition = true;
            else if(expected == null) condition = false;
            else condition = expected.Equals(actual);

            assert(condition, String.Format("Expected - {0}, Actual - {1}", expected, actual));
        }
    }
}
