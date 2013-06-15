using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    class Interval
    {
        public int Start { get; private set; }
        public int End { get; private set; }

        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", Start, End);
        }
    }

    class IntervalNode
    {
        public int Value { get; private set; }
        public bool IsStart { get; private set; }

        public IntervalNode(int value, bool start)
        {
            Value = value;
            IsStart = start;
        }
        
        public class Comparer : IComparer<IntervalNode>
        {
            public int Compare(IntervalNode x, IntervalNode y)
            {
                int compare = x.Value.CompareTo(y.Value);
                if (compare == 0)
                {
                    if (x.IsStart && !y.IsStart)
                        compare = -1;
                    else if (!x.IsStart && y.IsStart)
                        compare = 1;
                }

                return compare;
            }
        }
    }

    class MaxIntervalFinder
    {
        private List<IntervalNode> sorted;

        public Interval[] find(Interval[] pairs)
        {
            sorted = new List<IntervalNode>(pairs.Length);
            for (int i = 0; i < pairs.Length; i++)
            {
                sorted.Add(new IntervalNode(pairs[i].Start, true));
                sorted.Add(new IntervalNode(pairs[i].End, false));
            }

            sorted.Sort(new IntervalNode.Comparer());

            List<int> counts = new List<int>(sorted.Count);
            int count = 1;
            foreach (var v in sorted)
            {
                if (v.IsStart) count++;
                else count--;

                counts.Add(count);
            }

            int max = 0;
            foreach (var v in counts)
                if (max < v) max = v;

            List<Interval> res = new List<Interval>();
            for (int i = 0; i < counts.Count - 2; i++)
            {
                if (counts[i] == max && counts[i + 1] < counts[i])
                    res.Add(new Interval(sorted[i].Value, sorted[i + 1].Value));
            }

            return res.ToArray();
        }

        public void test()
        {
            Interval[] data = new Interval[4];
            data[0] = new Interval(5, 11);
            data[1] = new Interval(6, 18);
            data[2] = new Interval(2, 5);
            data[3] = new Interval(3, 12);

            var res = find(data);

            foreach (var v in res)
                Console.WriteLine(v.ToString());
        }
    }
}
