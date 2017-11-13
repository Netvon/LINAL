using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Matrices
{
    public class Matrix4x4 : Matrix
    {
        public Matrix4x4(bool isIdentity = true) : base(4, 4, isIdentity)
        { }

        //public Point4 Transform(Point4 point)
        //{
        //    var x = (this[0, 0] * point.X) + (this[0, 1] * point.Y) + (this[0, 2] * point.Z) + (this[0, 3] * point.W);
        //    var y = (this[1, 0] * point.X) + (this[1, 1] * point.Y) + (this[1, 2] * point.Z) + (this[1, 3] * point.W);
        //    var z = (this[2, 0] * point.X) + (this[2, 1] * point.Y) + (this[2, 2] * point.Z) + (this[2, 3] * point.W);
        //    var w = (this[3, 0] * point.X) + (this[3, 1] * point.Y) + (this[3, 2] * point.Z) + (this[3, 3] * point.W);

        //    return new Point4(x, y, z, w);
        //}

        public static Matrix4x4 operator +(Matrix4x4 a, Matrix4x4 b)
        {
            var newMatrix = new Matrix4x4();

            for (int y = 0; y < a.Rows; y++)
            {
                for (int x = 0; x < a.Columns; x++)
                {
                    newMatrix[y, x] = a[y, x] + b[y, x];
                }
            }

            return newMatrix;
        }

        //public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        //{
        //    var newMatrix = new Matrix4x4();

        //    for (int y = 0; y < a.Rows; y++)
        //    {
        //        for (int x = 0; x < a.Columns; x++)
        //        {
        //            newMatrix[x, y] = (a[0, y] * b[x, 0]) + (a[1, y] * b[x, 1]) + (a[2, y] * b[x, 2]) + (a[3, y] * b[x, 3]);
        //        }
        //    }

        //    return newMatrix;
        //}
    }
}
