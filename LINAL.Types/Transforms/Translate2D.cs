using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Translate2D : Transform2D
    {
        public override double X
        {
            get => this[0, 2];
            set
            {
                this[0, 2] = value;
            }
        }

        public override double Y
        {
            get => this[1, 2];
            set
            {
                this[1, 2] = value;
            }
        }

        [NotImplemented]
        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
