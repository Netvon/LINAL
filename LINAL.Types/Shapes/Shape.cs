using LINAL.Types.Transforms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;
using LINAL.Types.Matrices;
using LINAL.Types.Points;

namespace LINAL.Types.Shapes
{
    public abstract class Shape<TPoint> : IEnumerable<TPoint>
        where TPoint : Point, new()
    {
        protected List<TPoint> Points { get; }
        protected List<Matrix> transforms { get; }

        protected Shape()
        {
            Points = new List<TPoint>();
            transforms = new List<Matrix>();
        }

        public IEnumerable<Matrix> Transforms => transforms;
        public Matrix MultipliedMatrix => transforms.Skip(1).Aggregate(transforms[0], (a, b) => a * b);

        public IEnumerator<TPoint> GetEnumerator()
        {
            return Points.Select(p => ApplyTransforms(p)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<TPoint> OriginalPoints => Points;

        public void AddPoint(TPoint point)
        {
            Points.Add(point);
        }

        protected TPoint ApplyTransforms(TPoint point)
        {
            Point newPoint = MultipliedMatrix * point;
            return Activator.CreateInstance(typeof(TPoint), new[] { newPoint }) as TPoint;
        }
        //{
        //    return transforms.Aggregate(new Matrix3x3(), (a, b) => a * b).Transform(point);
        //}
    }
}
