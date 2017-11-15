using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Points
{
    public class Point4 : Point
    {
        public double X { get => this[0]; set => this[0] = value; }
        public double Y { get => this[1]; set => this[1] = value; }
        public double Z { get => this[2]; set => this[2] = value; }
        public double W { get => this[3]; set => this[3] = value; }

        public Point4() : this(0, 0, 0, 1)
        {

        }

        public Point4(double x, double y, double z, double w) : base(4)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Point4(Point point) : base(4)
        {
            X = point[0];
            Y = point[1];
            Z = point[2];
            W = point[3];
        }
    }
}
