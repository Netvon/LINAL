using LINAL.Types.Matrices;
using LINAL.Types.Vectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Transforms
{
    public class Rotate3D: Transform3D
    {
        double rotX, rotY, rotZ;

        public override double X
        {
            get => rotX;
            set
            {
                rotX = value;
                Update();
            }
        }

        public override double Y
        {
            get => rotY;
            set
            {
                rotY = value;
                Update();
            }
        }

        public override double Z
        {
            get => rotZ;
            set
            {
                rotZ = value;
                Update();
            }
        }

        void Update()
        {
            Reset();

            var a = X * (Math.PI / 180.0d);

            var t1 = Math.Atan2(Z, X);
            var t2 = Math.Atan2(Y, Math.Sqrt((X * X) + (Z * Z)));

            var rot = new Vector3(X, Y, Z);

            var seven = rot.ToIdentity();
            var six = new Matrix(new double[,]
            {
                { Math.Cos(t1), 0, -Math.Sin(t1), 0 },
                { 0, 1, 0, 0 },
                { Math.Sin(t1), 0, Math.Cos(t1), 0 },
                { 0, 0, 0, 1 },
            });
            var five = new Matrix(new double[,]
            {
                { Math.Cos(t2), -Math.Sin(t2), 0, 0 },
                { Math.Sin(t2), Math.Cos(t2), 0,0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            });

            var four = new Matrix(new double[,]
            {
                { 0, Math.Cos(a), -Math.Sin(a), 0 },
                { 0, Math.Sin(a), Math.Cos(a), 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            });

            var three = new Matrix(new double[,]
            {
                { Math.Cos(t2), Math.Sin(t2), 0, 0 },
                { -Math.Sin(t2), Math.Cos(t2), 0,0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 },
            });

            var tow = new Matrix(new double[,]
            {
                { Math.Cos(t1), 0, Math.Sin(t1), 0 },
                { 0, 1, 0, 0 },
                { -Math.Sin(t1), 0, Math.Cos(t1), 0 },
                { 0, 0, 0, 1 },
            });
        }
    }
}
