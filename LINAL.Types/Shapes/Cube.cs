using LINAL.Types.Points;
using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types.Shapes
{
    public class Cube : Shape3D
    {
        public Cube()
        {
            AddPoints();
        }

        public Cube(double x, double y, double z, double width, double height, double depth)
            :base(x, y, z, width, height, depth)
        {
            AddPoints();
        }

        void AddPoints()
        {
            Points.AddRange(new[] {

                // BottomLeft
                new Point4(1, 1, 1, 1 ),

                // BottomRight
                new Point4(-1, 1, 1, 1 ),

                // TopRight
                new Point4(-1, -1, 1, 1 ),

                // TopLeft
                new Point4(1, -1, 1, 1 ),
            });

            Points.AddRange(new[] {

                // TopRight
                new Point4(1, -1, -1, 1 ),

                // BottomLeft
                new Point4(1, 1, -1, 1 ),

                // BottomRight
                new Point4(-1, 1, -1, 1 ),

                // TopLeft
                new Point4(-1, -1, -1, 1 )
            });


            triangles = new uint[,]
            {
                { 0,1,2 },
                { 0,2,3 },

                //{ 0,3,4 },
                //{ 0,4,5 },

                //{ 0,5,6 },
                //{ 0,6,1 },

                //{ 1,6,7 },
                //{ 1,7,2 },

                //{ 7,4,3 },
                //{ 7,3,2 },

                //{ 4,6,7 },
                //{ 4,6,5 },
            };
        }
    }
}
