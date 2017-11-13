using LINAL.Types.Matrices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public abstract class Transform2D : Matrix3x3
    {
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Z { get; set; }

        //public static Matrix3x3 operator *(Transform2D a, Transform2D b)
        //{
        //    return a * b;
        //}
    }
}
