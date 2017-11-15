using LINAL.Types.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Points
{
    public class Point3 : Point
    {
        public double X { get => this[0]; set => this[0] = value; }
        public double Y { get => this[1]; set => this[1] = value; }
        public double Z { get => this[2]; set => this[2] = value; }

        public Point3() : this(0, 0, 1)
        {

        }

        public Point3(double x, double y, double z) : base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public IEnumerable<Point3> Offsets(Vector3 vector)
        {
            yield return new Point3(X + vector.X, Y, Z);
            yield return new Point3(X, Y + vector.Y, Z);
            yield return new Point3(X, Y, Z + vector.Z);
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y},Z:{Z}";
        }

        public Point3(Point point) : base(3)
        {
            X = point[0];
            Y = point[1];
            Z = point[2];
        }
    }
}
