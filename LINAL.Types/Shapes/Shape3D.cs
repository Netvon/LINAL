using LINAL.Types.Matrices;
using LINAL.Types.Points;
using LINAL.Types.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Shape3D : Shape<Point4>
    {
        protected uint[,] triangles;

        protected Shape3D() : this(0,0,0,0,0,0)
        {
        }

        protected Shape3D(double x, double y, double z, double width, double height, double depth)
        {
            transforms.AddRange(new Matrix[]
            {
                new Translate3D
                {
                    X = x,
                    Y = y,
                    Z = z
                },

                new Size3D
                {
                    X = width,
                    Y = height,
                    Z = depth
                },

                new Scale3D()
            });
        }

        public Size3D Size
        {
            get => transforms.Find(t => t is Size3D) as Size3D;
        }

        public Scale3D Scale
        {
            get => transforms.Last(t => t is Scale3D) as Scale3D;
        }

        public Translate3D Translate
        {
            get => transforms.Find(t => t is Translate3D) as Translate3D;
        }

        public IEnumerable<uint[]> InnerShapesIndecies()
        {
            var columns = triangles.GetLength(0);
            var rows = triangles.GetLength(1);

            var result = new uint[columns];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    result[x] = triangles[x, y];
                }

                yield return result;
            }
        }
    }
}
