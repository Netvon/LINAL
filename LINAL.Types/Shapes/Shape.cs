using LINAL.Types.Transforms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace LINAL.Types.Shapes
{
    public abstract class Shape : IEnumerable<Point3>
    {
        protected List<Point3> Points { get; }
        readonly List<Transform> transforms;

        protected Shape(double x, double y, double width, double height)
        {
            transforms = new List<Transform>()
            {
                new Scale // size
                {
                    X = width,
                    Y = height
                },

                new Scale(),

                new Rotate(),
                new Skew(),
                new Translate
                {
                    X = x,
                    Y = y
                }

            };

            Points = new List<Point3>();
        }

        public double Rotation
        {
            get => transforms.Find(t => t is Rotate)?.Z ?? 0;

            set => transforms.Find(t => t is Rotate).Z = value % 360;
        }

        public Scale Size
        {
            get => transforms.Find(t => t is Scale) as Scale;
        }

        public Scale Scale
        {
            get => transforms.Last(t => t is Scale) as Scale;
        }

        public Rotate Rotate
        {
            get => transforms.Find(t => t is Rotate) as Rotate;
        }

        public Skew Skew
        {
            get => transforms.Find(t => t is Skew) as Skew;
        }

        public Translate Translate
        {
            get => transforms.Find(t => t is Translate) as Translate;
        }

        public IEnumerable<Transform> Transforms => transforms;

        public IEnumerator<Point3> GetEnumerator()
        {
            return Points.Select(p => ApplyTransforms(p)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        Point3 ApplyTransforms(Point3 point)
        {
            transforms.ForEach(t => point = t.Apply(point));
            return point;
        }
    }
}
