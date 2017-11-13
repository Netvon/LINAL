using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Triangle : Shape2D
    {
        public Triangle()
        {
            AddPoints();
        }

        void AddPoints()
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

        public Triangle(double x, double y, double width, double height)
            : base(x, y, width, height)
        {
            AddPoints();
        }
    }
}
