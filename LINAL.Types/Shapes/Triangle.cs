using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double x, double y, double width, double height)
            : base(x, y, width, height)
        {
            Points.AddRange(new[]
            {
                 // TopMiddle
                new Point3(0, 1, 1 ),

                // BottomRight
                new Point3(1, -1, 1 ),

                // BottomLeft
                new Point3(-1, -1, 1 )
            });
        }
    }
}
