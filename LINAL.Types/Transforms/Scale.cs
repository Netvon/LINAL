using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Scale : Transform
    {
        public override double X
        {
            get => matrix[0, 0];
            set
            {
                matrix[0, 0] = value;
            }
        }

        public override double Y
        {
            get => matrix[1, 1];
            set
            {
                matrix[1, 1] = value;
            }
        }

        public override double Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
