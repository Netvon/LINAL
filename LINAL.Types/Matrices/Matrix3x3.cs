using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Matrices
{
    public class Matrix3x3 : Matrix
    {
        public Matrix3x3(bool isIdentity = true) : base(3, 3, isIdentity)
        { }

        public Point3 Transform(Point3 point)
        {
            var x = (this[0, 0] * point.X) + (this[0, 1] * point.Y) + (this[0, 2] * point.Z);
            var y = (this[1, 0] * point.X) + (this[1, 1] * point.Y) + (this[1, 2] * point.Z);
            var z = (this[2, 0] * point.X) + (this[2, 1] * point.Y) + (this[2, 2] * point.Z);

            return new Point3(x, y, z);
        }

        public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b)
        {
            var newMatrix = new Matrix3x3();

            for (int y = 0; y < a.Height; y++)
            {
                for (int x = 0; x < a.Width; x++)
                {
                    newMatrix[x, y] = a[x, y] + b[x, y];
                }
            }

            return newMatrix;
        }
    }
}
