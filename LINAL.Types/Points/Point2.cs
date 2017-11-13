using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Points
{
    public class Point2 : Point
    {
        public double X { get => this[0]; set => this[0] = value; }
        public double Y { get => this[1]; set => this[1] = value; }

        public Point2(double x, double y) : base(2)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y}";
        }

        public Point2(Point point) : base(2)
        {
            X = point[0];
            Y = point[1];
        }
    }
}
