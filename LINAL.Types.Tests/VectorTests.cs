using LINAL.Types.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LINAL.Types.Tests
{
    [TestClass]
    public class VectorTests
    {
        const double one = 1.0;
        const double two = 2.0;
        const double three = 3.0;

        Vector3 OneTwoThree => new Vector3(one, two, three);

        [TestMethod]
        public void BasicComponentsTest()
        {
            var vec = new Vector3(one, two, three);

            Assert.AreEqual(vec.X, one);
            Assert.AreEqual(vec.Y, two);
            Assert.AreEqual(vec.Z, three);
        }

        [TestMethod]
        public void MultiplyByScalar()
        {
            var vec = new Vector3(one, two, three);
            vec *= two;

            Assert.AreEqual(vec.X, one * two);
            Assert.AreEqual(vec.Y, two * two);
            Assert.AreEqual(vec.Z, three * two);
        }

        [TestMethod]
        public void NormalizeLengthIsOne()
        {
            Assert.AreEqual(OneTwoThree.Normalize.Length, 1);
        }

        [TestMethod]
        public void NormalizeComponents()
        {
            double expectedLength = Math.Sqrt(one * one + two * two + three * three);

            Assert.AreEqual(OneTwoThree.Length, expectedLength);
        }

        [TestMethod]
        public void OperatorAdd()
        {
            var twoThreeFour = OneTwoThree + new Vector3(1, 1, 1);

            Assert.AreEqual(twoThreeFour.X, one + 1 );
            Assert.AreEqual(twoThreeFour.Y, two + 1);
            Assert.AreEqual(twoThreeFour.Z, three + 1);
        }

        [TestMethod]
        public void OperatorSubtract()
        {
            var twoThreeFour = OneTwoThree - new Vector3(1, 1, 1);

            Assert.AreEqual(twoThreeFour.X, one - 1);
            Assert.AreEqual(twoThreeFour.Y, two - 1);
            Assert.AreEqual(twoThreeFour.Z, three - 1);
        }
    }
}
