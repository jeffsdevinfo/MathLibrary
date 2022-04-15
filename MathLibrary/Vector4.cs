using System;
using Helpers = MathLibrary.Helpers;

namespace MathLibrary
{
    public class Vector4
    {              
        //AIE test use public members
        public float x, y, z, w;

        #region properties
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public float Z { get { return z; } set { z = value; } }
        public float W { get { return w; } set { w = value; } }
        #endregion AIE properties

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector4() { x = y = z = w = 0; }

        /// <summary>
        /// Parameter constructor
        /// </summary>
        /// <param name="inpX"></param>
        /// <param name="inpY"></param>
        /// <param name="inpZ"></param>
        /// <param name="inpW"></param>
        public Vector4(float inpX, float inpY, float inpZ, float inpW) => (x, y, z, w) = (inpX, inpY, inpZ, inpW);

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="inpVec"></param>
        public Vector4(Vector4 inpVec) => (x, y, z, w) = (inpVec.x, inpVec.y, inpVec.z, inpVec.w);

        /// <summary>
        /// Operator + adds two vector4s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        /// <summary>
        /// Operator - subtracts two vector4s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        /// <summary>
        /// Operator == compares two Vector4s, returns true if they are equal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            if (Math.Abs(lhs.x - rhs.x) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.y - rhs.y) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.z - rhs.z) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.z - rhs.w) > Helpers.DEFAULT_TOLERANCE)
                return false;
            return true;
        }

        /// <summary>
        /// Operator != compares two Vector4s, returns false if they are equal
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            if (Math.Abs(lhs.x - rhs.x) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.y - rhs.y) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.z - rhs.z) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.z - rhs.w) > Helpers.DEFAULT_TOLERANCE)
                return true;
            return false;
        }

        /// <summary>
        /// Operator * multiplies a float times a vector
        /// </summary>
        /// <param name="lhv"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector4 operator *(float lhv, Vector4 rhs)
        {
            return new Vector4(lhv * rhs.x, lhv * rhs.y, lhv * rhs.z, lhv * rhs.w);
        }

        /// <summary>
        /// Operator * multiples a Vector4 times a float
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhv"></param>
        /// <returns></returns>
        public static Vector4 operator *(Vector4 lhs, float rhv)
        {
            return new Vector4(lhs.x * rhv, lhs.y * rhv, lhs.z * rhv, lhs.w * rhv);
        }

        /// <summary>
        /// Dot - computes the dot product of this Vector4
        /// </summary>
        /// <param name="inpVec"></param>
        /// <returns></returns>
        public float Dot(Vector4 inpVec) // returns the dot
        {
            return x * inpVec.x + y * inpVec.y + z * inpVec.z + w * inpVec.w;
        }

        /// <summary>
        /// Cross - computes the cross product of this Vector4
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vector4 Cross(Vector4 other)
        {
            return new Vector4(y * other.z - z * other.y, z * other.x - x * other.z, x * other.y - y * other.x, 0);
        }

        /// <summary>
        /// Magnitude - computes the lenght of this Vector4
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        /// <summary>
        /// Normalize - normlizes the components of this Vector4
        /// </summary>
        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
            w /= mag;
        }

        /// <summary>
        /// normalize - property that returns a new normalized Vector4 using this objects components
        /// </summary>
        public Vector4 normalized
        {
            get
            {
                float mag = Magnitude();
                return new Vector4(x / mag, y / mag, z / mag, w / mag);
            }
        }
    }
}
