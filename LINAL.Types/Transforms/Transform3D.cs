using LINAL.Types.Matrices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public abstract class Transform3D : Matrix4x4
    {
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Z { get; set; }
    }
}
