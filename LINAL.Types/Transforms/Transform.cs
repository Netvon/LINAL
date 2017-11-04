using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public abstract class Transform
    {
        protected Matrix3x3 matrix;

        protected Transform()
        {
            matrix = new Matrix3x3();
        }

        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Z { get; set; }

        public Point3 Apply(Point3 point)
        {
            return matrix.Transform(point);
        }
    }
}
