using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTake
{
    struct Point {
        public int X;
        public int Y;

        public override string ToString()
        {
            return String.Format("X = {0}, Y = {1}", X, Y);
        }
    }

    class PointComparer : IComparer<Point>
    {
        Point _initial;
        public PointComparer(Point initial) {
            _initial = initial;
        }
        public int Compare(Point x, Point y)
        {
            int distX = (_initial.X - x.X) * (_initial.X - x.X) + (_initial.Y - x.Y) * (_initial.Y - x.Y);
            int distY = (_initial.X - y.X) * (_initial.X - y.X) + (_initial.Y - y.Y) * (_initial.Y - y.Y);

            return distX.CompareTo(distY);
        }
    }
        
    class KNearestPointFinder
    {
        public Point find(Point[] points)
        {
            if(points == null || points.Length == 0) throw new ArgumentNullException();
            
            Array.Sort(points, new PointComparer(new Point() {X = 0, Y = 0}));
            return points[0];
        }

        public void test()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < 100; i++) {
                Random rand = new Random(i);
                points.Add(new Point()
                {
                     X = 100 - i,
                     Y = 100 -i         
                });
            }

            Point p =  find(points.ToArray());
        }
    }
}
