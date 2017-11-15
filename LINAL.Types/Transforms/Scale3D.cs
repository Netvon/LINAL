using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Scale3D : Transform3D
    {
        public override double X
        {
            get => this[0, 0];
            set => this[0, 0] = value;
        }

        public override double Y
        {
            get => this[1, 1];
            set => this[1, 1] = value;
        }

        public override double Z
        {
            get => this[2, 2];
            set => this[2, 2] = value;
        }
    }

    public class Size3D : Scale3D
    {
    }
}
