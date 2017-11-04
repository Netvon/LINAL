using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Box : Shape
    {
        public Box(double x, double y, double width, double height)
            : base(x, y, width, height)
        {
            Points.AddRange(new[]
            {
                // TopLeft
                new Point3(-1, 1, 1 ),

                // TopRight
                new Point3(1, 1, 1 ),

                // BottomRight
                new Point3(1, -1, 1 ),

                // BottomLeft
                new Point3(-1, -1, 1 )
            });
        }
    }
}
