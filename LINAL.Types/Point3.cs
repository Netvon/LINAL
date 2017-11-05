using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types
{
    public class Point3 : IEnumerable<double>
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

        public IEnumerator<double> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y},Z:{Z}";
        }
    }
}
