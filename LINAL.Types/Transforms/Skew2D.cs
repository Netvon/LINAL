using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Skew2D : Transform2D
    {
        public override double X
        {
            get => this[0, 1];
            set
            {
                this[0, 1] = value;
            }
        }

        public override double Y
        {
            get => this[1, 0];
            set
            {
                this[1, 0] = value;
            }
        }

        [NotImplemented]
        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
