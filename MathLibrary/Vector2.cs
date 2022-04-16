// Copyright (c) 2021 Jeff Simon
// Distributed under the MIT/X11 software license, see the accompanying
// file license.txt or http://www.opensource.org/licenses/mit-license.php.

using System;

namespace MathLibrary
{
    public class Vector2
    {
        private float x, y;

        #region AIE properties
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        #endregion AIE properties

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vector2() { x = y = 0; }

        /// <summary>
        /// Parameter constructor with components
        /// </summary>
        /// <param name="inpX"></param>
        /// <param name="inpY"></param>
        public Vector2(float inpX, float inpY) => (x, y) = (inpX, inpY);

        /// <summary>
        /// Parameter constructor copy
        /// </summary>
        /// <param name="inpVec"></param>
        public Vector2(Vector2 inpVec) => (x, y) = (inpVec.x, inpVec.y);

        /// <summary>
        /// Operator + adds two vector2s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        /// <summary>
        /// Operator - subtracts two vector2s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        /// <summary>
        /// Operator == compares two vector2s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            if (lhs.x != rhs.x)
                return false;
            if (lhs.y != rhs.y)
                return false;
            return true;
        }

        /// <summary>
        /// Operator != compares if two vector2s are different
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            if (lhs.x != rhs.x)
                return true;
            if (lhs.y != rhs.y)
                return true;
            return false;
        }

        /// <summary>
        /// Magnitude, gets the length of the vector2
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Normalized - normalizes the vector2
        /// </summary>
        /// <returns></returns>
        public void Normalized()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
        }

        /// <summary>
        /// normalized - returns a new vector2 with normalized components
        /// </summary>
        public Vector2 normalized
        {
            get
            {
                float mag = Magnitude();
                return new Vector2(x / mag, y / mag);
            }
        }
    }
}

