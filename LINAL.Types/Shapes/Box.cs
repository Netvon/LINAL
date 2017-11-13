using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Box : Shape2D
    {
        public Box()
        {
            AddPoints();
        }

        public Box(double x, double y, double width, double height)
            : base(x, y, width, height)
        {
            AddPoints();
        }

        void AddPoints()
        {
            Points.AddRange(new[] {
                // BottomRight
                new Point3(-1, 1, 1 ),

                // BottomLeft
                new Point3(1, 1, 1 ),

                // TopRight
                new Point3(1, -1, 1 ),

                // TopLeft
                new Point3(-1, -1, 1 )
            });
        }
    }
}
