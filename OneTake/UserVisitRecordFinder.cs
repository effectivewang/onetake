using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class UserVisitRecordFinder
    {
        public string find(string user, string[] records)
        {
            if (user == null || records == null) return null;

            string mostVisited = string.Empty;

            return mostVisited;
        }

        public void test()
        {
            string[] records = { "home", "product", "product detail", "product", "product detail" , "home", ""};
            string mostVisited = find("roger", records);

        }
    }
}
