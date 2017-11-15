using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Skew2D : Transform2D
    {
        double skewX, skewY;

        public override double X
        {
            get => skewX;
            set
            {
                const double convert = Math.PI / 180.0;
                skewX = value;

                this[0, 1] = value * convert;
            }
        }

        public override double Y
        {
            get => skewY;
            set
            {
                const double convert = Math.PI / 180.0;
                skewY = value;

                this[1, 0] = value * convert;
            }
        }

        [NotImplemented]
        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
