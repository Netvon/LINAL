using System;
using System.Collections;
using System.Collections.Generic;

namespace LINAL.Types
{
    public class Vector3 : IEnumerable<double>, IEquatable<Vector3>
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public double Length => Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        public Vector3 Normalize => this / Length;

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator *(Vector3 a, double scalar)
        {
            return new Vector3(a.X * scalar, a.Y * scalar, a.Z * scalar);
        }

        public static Vector3 operator /(Vector3 a, double scalar)
        {
            return new Vector3(a.X / scalar, a.Y / scalar, a.Z / scalar);
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

        public bool Equals(Vector3 other)
        {
            return Math.Abs(X - other.X) < Double.Epsilon
                && Math.Abs(Y - other.Y) < Double.Epsilon
                && Math.Abs(Z - other.Z) < Double.Epsilon;
        }
    }
}
