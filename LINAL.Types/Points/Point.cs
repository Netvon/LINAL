﻿using LINAL.Types.Matrices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINAL.Types.Points
{
    public class Point : IEnumerable<double>
    {
        public int AxisCount { get; }

        public double this[int index]
        {
            get => values[index];
            set => values[index] = value;
        }

        private double[] values;

        

        public Point(double[] init)
        {
            values = init;
            AxisCount = init.Length;
        }

        public Point(int axis)
        {
            values = new double[axis];
            AxisCount = axis;
        }

        public IEnumerator<double> GetEnumerator()
        {
            return Enumerable.Range(0, AxisCount).Select(i => this[i]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static implicit operator Matrix(Point point)
        {
            var matrix = new Matrix(1, (uint)point.AxisCount, false);

            for (int i = 0; i < point.AxisCount; i++)
            {
                matrix[i, 0] = point[i];
            }

            return matrix;
        }

        public static implicit operator Point(Matrix from)
        {
            if (from.Columns > 1)
                throw new NotSupportedException();

            var result = new Point((int)from.Rows);

            for (int i = 0; i < from.Rows; i++)
            {
                result[i] = from[i, 0];
            }

            return result;
        }
    }
}
