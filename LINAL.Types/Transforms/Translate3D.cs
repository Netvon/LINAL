using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Translate3D : Transform3D
    {
        public override double X
        {
            get => this[0, 3];
            set => this[0, 3] = value;
        }

        public override double Y
        {
            get => this[1, 3];
            set => this[1, 3] = value;
        }

        public override double Z
        {
            get => this[2, 3];
            set => this[2, 3] = value;
        }
    }
}
