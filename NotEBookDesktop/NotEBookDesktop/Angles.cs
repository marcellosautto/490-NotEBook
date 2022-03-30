<<<<<<< HEAD
﻿using System;
=======
using System;
>>>>>>> Desktop
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotEBookDesktop
{
    class Angles
    {
        public enum units
        {
            RADIANS,  // Default unit
            DEGREES
        }

        public class Converter
        {
            /// Converts the given angle to degrees
            
            public static double degrees(double angle, units angleUnit)
            {
                if (angleUnit == units.RADIANS)
                    return angle * 180 / Math.PI;

                else if (angleUnit == units.DEGREES)
                    return angle;
                else
                {
                    Exception error = new Exception("Invalid parameters");
                    throw error;
                }
            }

            /// Converts the given angle to radians
            public static double radians(double angle, units angleUnit)
            {
                // Avoid extra computation
                if (angleUnit == units.RADIANS)
                    return angle;

                return degrees(angle, angleUnit) * Math.PI / 180;
            }



        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> Desktop
