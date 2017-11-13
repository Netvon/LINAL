using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LINAL.Types.Points;

namespace LINAL.Types.Matrices
{
    public class Matrix : IEnumerable<Matrix.Value>
    {
        public struct Value
        {
            public readonly int x, y;
            public readonly double value;

            public Value(int x, int y, double value)
            {
                this.x = x;
                this.y = y;
                this.value = value;
            }
        }

        readonly double[,] data;

        public uint Rows { get; }
        public uint Columns { get; }

        public Matrix() { }

        public Matrix(uint columns, uint rows, bool isIdentity = true)
        {
            Columns = columns;
            Rows = rows;

            data = new double[rows, columns];

            if(isIdentity)
            {
                for (var i = 0; i < columns; i++)
                {
                    data[i, i] = 1.0;
                }
            }
        }

        public Matrix(double[,] intializeList)
        {
            data = intializeList;

            Rows = (uint)data.GetLength(0);
            Columns = (uint)data.GetLength(1);
        }

        public double this[int y, int x]
        {
            get
            {
                if (y < 0 || x < 0)
                    throw new IndexOutOfRangeException();

                if (y > Rows - 1 || x > Columns - 1)
                    throw new IndexOutOfRangeException();

                return data[y, x];
            }

            set
            {
                if (y < 0 || x < 0)
                    throw new IndexOutOfRangeException();

                if (y > Rows - 1 || x > Columns - 1)
                    throw new IndexOutOfRangeException();

                data[y, x] = value;
            }
        }

        public IEnumerator<Value> GetEnumerator()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    yield return new Value ( x, y, this[y, x] );
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static Matrix operator*(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new NotSupportedException();

            var mat = new Matrix(b.Columns, a.Rows, false);

            for (int y = 0; y < mat.Rows; y++)
            {
                for (int x = 0; x < mat.Columns; x++)
                {
                    double sum = 0;

                    for (int acol = 0; acol < a.Columns; acol++)
                    {
                        sum += a[y, acol] * b[acol, x];
                    }

                    mat[y, x] = sum;
                }
            }

            return mat;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix mat && mat.Columns == Columns && mat.Rows == Rows)
            {
                for (int y = 0; y < mat.Rows; y++)
                {
                    for (int x = 0; x < mat.Columns; x++)
                    {
                        if (Math.Abs(mat[y, x] - this[y, x]) > Double.Epsilon)
                            return false;
                    }
                }

                return true;
            }

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }
    }
}
