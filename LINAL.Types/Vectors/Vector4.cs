using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Vectors
{
    public class Vector4 : Point4, IEquatable<Vector4>
    {
        public double Length => Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
        public Vector4 Normalize => this / Length;

        public Vector4(double x, double y, double z, double w) : base(x, y, z, w)
        { }

        public Vector4 Cross(Vector4 other)
        {
            return new Vector4(
                (Y * other.Z) - (Z * other.Y),
                (Z * other.X) - (X * other.Z),
                (X * other.Y) - (Y * other.X),
                W
            );
        }

        public static Vector4 operator *(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vector4 operator *(Vector4 a, double scalar)
        {
            if (a == null)
                return null;

            return new Vector4(a.X * scalar, a.Y * scalar, a.Z * scalar, a.W * scalar);
        }

        public static Vector4 operator /(Vector4 a, double scalar)
        {
            return new Vector4(a.X / scalar, a.Y / scalar, a.Z / scalar, a.W / scalar);
        }

        public bool Equals(Vector4 other)
        {
            return Math.Abs(X - other.X) < Double.Epsilon
                && Math.Abs(Y - other.Y) < Double.Epsilon
                && Math.Abs(Z - other.Z) < Double.Epsilon
                && Math.Abs(W - other.W) < Double.Epsilon;
        }
    }
}
