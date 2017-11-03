using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types
{
    public class Point3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3(double x, double y, double z)
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
    }
}
