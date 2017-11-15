using LINAL.Types.Points;
using LINAL.Types.Projection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Tests
{
    [TestClass]
    public class CameraTests
    {
        [TestMethod]
        public void TestCamera()
        {
            var camera = new Camera3()
            {
                Eye = new Point3(0, 0, 10),
                LookAt = new Point3(12, 12, 125),
                Near = 10,
                Far = 200,
                FieldOfView = 90,
                Size = 500
            };

            var point = new Point3(12, 12, 100);

            var throughCamera = camera.Transform(point);


            var h = 'h';
        }
    }
}
