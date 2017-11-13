using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Matrices
{
    public class Matrix3x3 : Matrix
    {
        public Matrix3x3() : base(3,3,true)
        { }

        public Matrix3x3(bool isIdentity = true) : base(3, 3, isIdentity)
        { }

        //public Point3 Transform(Point3 point)
        //{
        //    var x = (this[0, 0] * point.X) + (this[0, 1] * point.Y) + (this[0, 2] * point.Z);
        //    var y = (this[1, 0] * point.X) + (this[1, 1] * point.Y) + (this[1, 2] * point.Z);
        //    var z = (this[2, 0] * point.X) + (this[2, 1] * point.Y) + (this[2, 2] * point.Z);

        //    return new Point3(x, y, z);
        //}

        public static Matrix3x3 operator +(Matrix3x3 a, Matrix3x3 b)
        {
            var newMatrix = new Matrix3x3();

            for (int y = 0; y < a.Rows; y++)
            {
                for (int x = 0; x < a.Columns; x++)
                {
                    newMatrix[y, x] = a[y, x] + b[y, x];
                }
            }

            return newMatrix;
        }

            //public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
            //{
            //    var newMatrix = new Matrix3x3();

            //    //newMatrix[0, 0] = (a[0, 0] * b[0, 0]) + (a[1, 0] * b[0, 1]) + (a[2, 0] * b[0, 2]);
            //    //newMatrix[0, 1] = (a[0, 1] * b[0, 0]) + (a[1, 1] * b[0, 1]) + (a[2, 1] * b[0, 2]);
            //    //newMatrix[0, 2] = (a[0, 2] * b[0, 0]) + (a[1, 2] * b[0, 1]) + (a[2, 2] * b[0, 2]);

            //    //newMatrix[1, 0] = (a[0, 0] * b[1, 0]) + (a[1, 0] * b[1, 1]) + (a[2, 0] * b[1, 2]);
            //    //newMatrix[1, 1] = (a[0, 1] * b[1, 0]) + (a[1, 1] * b[1, 1]) + (a[2, 1] * b[1, 2]);
            //    //newMatrix[1, 2] = (a[0, 2] * b[1, 0]) + (a[1, 2] * b[1, 1]) + (a[2, 2] * b[1, 2]);

            //    //newMatrix[2, 0] = (a[0, 0] * b[2, 0]) + (a[1, 0] * b[2, 1]) + (a[2, 0] * b[2, 2]);
            //    //newMatrix[2, 1] = (a[0, 1] * b[2, 0]) + (a[1, 1] * b[2, 1]) + (a[2, 1] * b[2, 2]);
            //    //newMatrix[2, 2] = (a[0, 2] * b[2, 0]) + (a[1, 2] * b[2, 1]) + (a[2, 2] * b[2, 2]);

            //    for (int y = 0; y < a.Rows; y++)
            //    {
            //        for (int x = 0; x < a.Columns; x++)
            //        {
            //            newMatrix[x, y] = (a[0, y] * b[x, 0]) + (a[1, y] * b[x, 1]) + (a[2, y] * b[x, 2]);
            //        }
            //    }

            //    return newMatrix;
            //}
        }
}
