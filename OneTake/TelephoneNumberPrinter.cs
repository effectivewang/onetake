using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class TelephoneNumberPrinter
    {
        const int PHONE_NUMBER_LENGTH = 7;
        private List<String> output = new List<string>();

        public void print(int[] numbers) {
            char[] phoneChars = new char[PHONE_NUMBER_LENGTH];

            doPrintTelephoneNumber(numbers, 0, phoneChars);
        }

        private void doPrintTelephoneNumber(int[] numbers, int cur, char[] phone) {
            if (cur == PHONE_NUMBER_LENGTH) {
                Console.WriteLine(new String(phone));
                output.Add(new String(phone));
                return;
            }

            for (int i = 0; i < 3; i++) {
                if (numbers[cur] == 0 || numbers[cur] == 1) return;

                phone[cur] = getChar(numbers[cur], i);
                doPrintTelephoneNumber(numbers, cur + 1, phone);
            }
        }

        private char getChar(int number, int i) {
            const string CHARs = "ABCDEFGHIJKLMNOPQRSTUVWXY";

            return CHARs[(number - 2) * 3 + i];
        }

        public void test()
        {
            int[] data = { 8, 6, 6, 2, 6, 6, 5 };
            print(data);
        }
    }
}
