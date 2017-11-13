using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Points
{
    public class Point4 : Point3
    {
        public double W { get; set; }

        public Point4(double x, double y, double z, double w = 1) : base(x, y, z)
        {
            W = w;
        }
    }
}
