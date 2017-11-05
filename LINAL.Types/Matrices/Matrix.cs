using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Matrices
{
    public abstract class Matrix
    {
        readonly double[,] data;

        public uint Height { get; }
        public uint Width { get; }

        protected Matrix(uint width, uint height, bool isIdentity = true)
        {
            Width = width;
            Height = height;

            data = new double[height, width];

            uint identityX = 0;
            uint identityY = 0;

            for (uint y = 0; y < height; y++)
            {
                for (uint x = 0; x < width; x++)
                {
                    if(x == identityX && y == identityY && isIdentity)
                    {
                        data[y, x] = 1.0;
                        identityX++;
                        identityY++;
                    }
                    else
                    {
                        data[y, x] = 0.0;
                    }
                }
            }

            //data = new double[3, 3]
            //{
            //    { 1.0, 0.0, 0.0 },
            //    { 0.0, 1.0, 0.0 },
            //    { 0.0, 0.0, 1.0 },
            //};
        }

        public double this[int x, int y]
        {
            get => data[y, x];
            set
            {
                if (y < 0 || x < 0)
                    return;

                if (y > Height || x > Width)
                    return;

                data[y, x] = value;
            }
        }
    }
}
