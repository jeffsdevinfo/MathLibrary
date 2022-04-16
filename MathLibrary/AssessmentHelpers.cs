// Copyright (c) 2021 Jeff Simon
// Distributed under the MIT/X11 software license, see the accompanying
// file license.txt or http://www.opensource.org/licenses/mit-license.php.

using System;

namespace MathLibrary
{
    public class Helpers
    {
        static int MathPrecision = 6;
        
        /// <summary>
        /// Cos - helper cos method using MathPrecision
        /// </summary>
        /// <param name="rotationRadians"></param>
        /// <returns></returns>
        public static float Cos(float rotationRadians)
        {
            return (float)Math.Round(Math.Cos(rotationRadians), MathPrecision);
        }

        /// <summary>
        /// Sin - helper sin method using MathPrecision
        /// </summary>
        /// <param name="rotationRadians"></param>
        /// <returns></returns>
        public static float Sin(float rotationRadians)
        {
            return (float)Math.Round(Math.Sin(rotationRadians), MathPrecision);
        }

        /// <summary>
        /// DegToRad - returns input degrees converted to radians
        /// </summary>
        /// <param name="degrees"></param>
        /// <returns></returns>
        public static float DegToRad(float degrees)
        {
            return (float)Math.Round(degrees / (180.0f / Math.PI), MathPrecision);
        }

        /// <summary>
        /// RadtoDeg - returns input radians converted to degrees
        /// </summary>
        /// <param name="radians"></param>
        /// <returns></returns>
        public static float RadToDeg(float radians)
        {
            return (float)(180.0f / Math.PI) * radians;
        }

        //Added tolerance to resolve close precision difference calculations
        // this is used in operator== and operator!= of Vector and Matrix classes
        // to prevent very close comparisons from failing
        public static float DEFAULT_TOLERANCE = 0.0001f;
    }
}
