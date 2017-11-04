using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Rotate : Transform
    {
        double zRot;

        public override double Z
        {
            get => zRot;
            set
            {
                zRot = value;

                const double convert = Math.PI / 180.0;
                var rad = value * convert;

                matrix[0, 0] = Math.Cos(rad);
                matrix[1, 0] = Math.Sin(rad);
                matrix[2, 0] = 0;

                matrix[0, 1] = -Math.Sin(rad);
                matrix[1, 1] = Math.Cos(rad);
                matrix[2, 1] = 0;

                matrix[0, 2] = 0;
                matrix[1, 2] = 0;
                matrix[2, 2] = 1;
            }
        }

        public override double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
