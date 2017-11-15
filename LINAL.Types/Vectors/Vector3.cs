using LINAL.Types.Points;
using System;

namespace LINAL.Types.Vectors
{
    public class Vector3 : Point3, IEquatable<Vector3>
    {
        public double Length => Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
        public Vector3 Normalize => this / Length;

        public Vector3(double x, double y, double z) : base(x, y, z)
        { }

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                (Y * other.Z) - (Z * other.Y),
                (Z * other.X) - (X * other.Z),
                (X * other.Y) - (Y * other.X)
            );
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
            if (a == null)
                return null;

            return new Vector3(a.X * scalar, a.Y * scalar, a.Z * scalar);
        }

        public static Vector3 operator /(Vector3 a, double scalar)
        {
            return new Vector3(a.X / scalar, a.Y / scalar, a.Z / scalar);
        }

        public bool Equals(Vector3 other)
        {
            return Math.Abs(X - other.X) < Double.Epsilon
                && Math.Abs(Y - other.Y) < Double.Epsilon
                && Math.Abs(Z - other.Z) < Double.Epsilon;
        }
    }
}
