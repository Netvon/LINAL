using LINAL.Types.Matrices;
using LINAL.Types.Points;
using LINAL.Types.Vectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Projection
{
    public class Camera3
    {
        public Point3 Eye { get; set; }
        public Point3 LookAt { get; set; }

        Vector4 Eye4 => new Vector4(Eye.X, Eye.Y, Eye.Z, 1);
        Vector4 LookAt4 => new Vector4(LookAt.X, LookAt.Y, LookAt.Z, 1);
        Vector4 Up => new Vector4(0, 1, 0, 1);

        public double Far { get; set; }
        public double Near { get; set; }
        public double FieldOfView { get; set; }
        public double Size { get; set; }

        public Matrix Camera
        {
            get
            {
                var z = Eye4 - LookAt4;
                z = z.Normalize;

                var y = Up.Normalize;
                var x = y.Cross(z);
                x = x.Normalize;

                y = z.Cross(x);
                y = y.Normalize;

                return new Matrix(new double[,]
                {
                    { x.X, x.Y, x.Z, -(x.Dot(Eye4)) },
                    { y.X, y.Y, y.Z, -(y.Dot(Eye4)) },
                    { z.X, z.Y, z.Z, -(z.Dot(Eye4)) },
                    { 0, 0, 0, 1 },
                });
            }
        }

        public Matrix Projection
        {
            get
            {
                var a = FieldOfView * (Math.PI / 180.0d);
                var scale = Near * Math.Tan(a * 0.5);

                return new Matrix(new double[,]
                {
                    { scale, 0, 0, 0 },
                    { 0, scale, 0, 0 },
                    { 0, 0, (-Far) / (Far-Near), -1 },
                    { 0, 0, ((-Far) * Near) / (Far-Near), 0 },
                });
            }
        }

        public Point4 Transform(Point3 point)
        {
            var v4 = new Vector4(point.X, point.Y, point.Z, 1);
            Point view = Projection * Camera * v4;
            var viewAsv4 = new Vector4(view[0], view[1], view[2], view[3]);

            return Fix(viewAsv4);
        }

        public Point4 Transform(Point4 point)
        {
            Point view = Projection * Camera * point;
            var viewAsv4 = new Vector4(view[0], view[1], view[2], view[3]);

            return Fix(viewAsv4);
        }

        private Point4 Fix(Vector4 vector)
        {
            var x = (Size / 2) + (((vector.X + 1) / vector.W) * Size * 0.5);
            var y = (Size / 2) + (((vector.Y + 1) / vector.W) * Size * 0.5);
            var z = -vector.Z;

            return new Point4(x, y, z, vector.W);
        }
    }
}
