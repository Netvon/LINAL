using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Skew : Transform
    {
        public override double X
        {
            get => matrix[0, 1];
            set
            {
                matrix[0, 1] = value;
            }
        }

        public override double Y
        {
            get => matrix[1, 0];
            set
            {
                matrix[1, 0] = value;
            }
        }

        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
