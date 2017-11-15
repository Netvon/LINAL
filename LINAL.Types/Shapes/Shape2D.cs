using LINAL.Types.Matrices;
using LINAL.Types.Points;
using LINAL.Types.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINAL.Types.Shapes
{
    public abstract class Shape2D : Shape<Point3>
    {
        protected Shape2D() : this(0,0,0,0)
        {
        }

        protected Shape2D(double x, double y, double width, double height)
        {
            transforms.AddRange(new Matrix3x3[]
            {
                new Translate2D
                {
                    X = x,
                    Y = y
                },

                new Rotate2D(),

                new Size2D // size
                {
                    X = width,
                    Y = height
                },

                

                new Scale2D(),

                
                new Skew2D(),
            });
        }

        public double Rotation
        {
            get
            {
                var rotate = transforms.Find(t => t is Rotate2D) as Rotate2D;
                return rotate?.Z ?? 0;
            }

            set
            {
                var rotate = transforms.Find(t => t is Rotate2D) as Rotate2D;
                rotate.Z = value % 360;
            }
        }

        public Size2D Size
        {
            get => transforms.Find(t => t is Size2D) as Size2D;
        }

        public Scale2D Scale
        {
            get => transforms.Last(t => t is Scale2D) as Scale2D;
        }

        public Rotate2D Rotate
        {
            get => transforms.Find(t => t is Rotate2D) as Rotate2D;
        }

        public Skew2D Skew
        {
            get => transforms.Find(t => t is Skew2D) as Skew2D;
        }

        public Translate2D Translate
        {
            get => transforms.Find(t => t is Translate2D) as Translate2D;
        }

        //protected override Point3 ApplyTransforms(Point3 point)
        //{
        //    return transforms.Aggregate(new Matrix3x3(), (a, b) => a * b).Transform(point);
        //}
    }
}
