using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Rotate2D : Transform2D
    {
        double zRot, xRot, yRot;

        public override double Z
        {
            get => zRot;
            set
            {
                zRot = value;

                const double convert = Math.PI / 180.0;
                var rad = value * convert;

                this[0, 0] = Math.Cos(rad);
                this[0, 1] = Math.Sin(rad);
                this[0, 2] = 0;

                this[1, 0] = -Math.Sin(rad);
                this[1, 1] = Math.Cos(rad);
                this[1, 2] = 0;

                this[2, 0] = 0;
                this[2, 1] = 0;
                this[2, 2] = 1;
            }
        }

        public override double X
        {
            get => xRot;
            set
            {
                xRot = value;

                const double convert = Math.PI / 180.0;
                var rad = value * convert;

                this[0, 0] = 1;
                this[0, 1] = 0;
                this[0, 2] = 0;

                this[1, 0] = 0;
                this[1, 1] = Math.Cos(rad);
                this[1, 2] = -Math.Sin(rad);

                this[2, 0] = 0;
                this[2, 1] = Math.Sin(rad);
                this[2, 2] = Math.Cos(rad);
            }
        }

        public override double Y
        {
            get => xRot;
            set
            {
                yRot = value;

                const double convert = Math.PI / 180.0;
                var rad = value * convert;

                this[0, 0] = Math.Cos(rad);
                this[0, 1] = 0;
                this[0, 2] = -Math.Sin(rad);

                this[1, 0] = 0;
                this[1, 1] = 1;
                this[1, 2] = 0;

                this[2, 0] = Math.Sin(rad);
                this[2, 1] = 0;
                this[2, 2] = Math.Cos(rad);
            }
        }
    }
}
