using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace LINAL.Types.Transforms
{
    public class Scale2D : Transform2D
    {
        public override double X
        {
            get => this[0, 0];
            set
            {
                this[0, 0] = value;
            }
        }

        public override double Y
        {
            get => this[1, 1];
            set
            {
                this[1, 1] = value;
            }
        }

        [NotImplemented]
        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
