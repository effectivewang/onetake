using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class AlphabetOrderFinder
    {
        private char[] find(String[] orderStrings)
        {
            Digraph g = new Digraph(26);

            int j = 0;
            for (int i = 0; i < orderStrings.Length - 1; i++)
            {
                string high = orderStrings[i + 1];
                string low = orderStrings[i];
                int minLength = Math.Min(low.Length, high.Length);

                for (j = 0; j < minLength; j++)
                {
                    if (low[j] == high[j])
                        continue;

                    if (low[j] != high[j])
                        g.addEdge(get(low[j]), get(high[j])); 
                }
            }

            DirectedCycle cycle = new DirectedCycle(g);
            if (cycle.hasCycle()) {
                foreach (var c in cycle.getCycle())
                    Console.Write(c + " -> ");

                Console.WriteLine();
                return null;
            }

            List<char> orders = new List<char>();
            DFSDiagraph dfs = new DFSDiagraph(g);
            foreach (var v in dfs.sort()) {
                orders.Add(get(v));
            }

            return orders.ToArray();
        }

        private int get(char c) {
            if (!Char.IsUpper(c))
                c = Char.ToUpper(c);

            return c - 'A';
        }

        public char get(int c) {
            return (char)(c + 'A');
        }

        public void test()
        {
            const string NEW_ORDER = "HIJKLMNOPQRSTUVWXYZABCDEFG";
            String[] newlyOrdered = {
                "HACD",
                "HIEF",
                "IBEA",
                "ID",
                "JAC",
                "K",
                "KB",
                "KC",
                "KD",
                "KE",
                "KF",
                "KG",
                "L",
                "LL",
                "LM",
                "LN",
                "LO",
                "LP",
                "LQ",
                "LR",
                "LS",
                "LT",
                "LU",
                "LV",
                "LW",
                "LX",
                "LY",
                "LZ",
                "Z",
                "A",
                "B"
            };

            char[] orders = find(newlyOrdered);
            String printRes = String.Join<char>(" -> ", orders);
            String res = String.Join<char>("", orders);

            Console.WriteLine(printRes);
            AssertHelper.areEqual(NEW_ORDER, res);
        }
    }
}
