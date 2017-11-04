using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Translate : Transform
    {
        public override double X
        {
            get => matrix[0, 2];
            set
            {
                matrix[0, 2] = value;
            }
        }

        public override double Y
        {
            get => matrix[1, 2];
            set
            {
                matrix[1, 2] = value;
            }
        }

        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
