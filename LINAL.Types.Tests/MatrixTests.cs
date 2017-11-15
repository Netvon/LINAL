using LINAL.Types.Matrices;
using LINAL.Types.Points;
using LINAL.Types.Transforms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestMutiplication()
        {
            var a = new Matrix(new double[,]
            {
                { 1, 4, 6, 10 },
                { 2, 7, 5, 3 }
            });

            var b = new Matrix(new double[,]
            {
                { 1, 4, 6 },
                { 2, 7, 5 },
                { 9, 0, 11 },
                { 3, 1, 0 }
            });

            var c = a * b;

            Assert.AreEqual(c, new Matrix(new double[,]
            {
                { 93, 42, 92 },
                { 70, 60, 102 }
            }));
        }

        [TestMethod]
        public void TestMutiplication2()
        {
            var a = new Matrix(new double[,]
            {
                { -3, -2, -1 },
                { 2, 3, 0 },
                { 1, 4, 5 },
                { 6, 7, 8 }
            });

            var b = new Matrix(new double[,]
            {
                { 9, -3, -1 },
                { -4, 10, 11 },
                { -2, 0, 2 }
            });

            var c = a * b;

            Assert.AreEqual(c, new Matrix(new double[,]
            {
                { -17, -11, -21 },
                { 6, 24, 31 },
                { -17, 37, 53 },
                { 10, 52, 87 }
            }));
        }

        [TestMethod]
        public void School()
        {
            var a = new Matrix(new double[,]
            {
                { 2, -1 },
                { 1, 2 }
            });

            var b = new Matrix(new double[,]
            {
                { 1, 1 },
                { 0, 2 }
            });

            var c = a * b;

            Assert.AreEqual(c, new Matrix(new double[,]
            {
                { 2, 0 },
                { 1, 5 }
            }));
        }

        [TestMethod]
        public void TestConversion()
        {
            double[,] h1 =
            {
                {1,1,1 }
            };

            var b = h1.IsFixedSize;

            Matrix matrix = new Point2(1, 2);
            Point backToPoint = matrix;

            Point result = new Matrix(new double[,]
            {
                { 0.1, 0 },
                { 0, 0.1 },
            }) * backToPoint;

            var h = 'h';
        }

        [TestMethod]
        public void TranslateTest()
        {
            var point = new Point3(0, 0, 1);

            var translate2d = new Translate2D
            {
                X = 0.4
            };

            var translate = new Matrix(new double[,]
            {
                { 1.0, 0.0, 0.4 },
                { 0.0, 1.0, 0.0 },
                { 0.0, 0.0, 1.0 }
            });

            var point2 = new Point2(12, 10);
            var pi = point2.ToIdentity();
            var npi = point2.ToNegatedIdentity();


            var matrix = new Matrix(2, 2, true);
            var matWithP2 = matrix.Concat(point2);

            Point resultFromTranslate = translate2d * point;
            Point resultFromMatrix = translate * point;

            Assert.IsTrue(resultFromMatrix == resultFromTranslate);
        }
    }
}
