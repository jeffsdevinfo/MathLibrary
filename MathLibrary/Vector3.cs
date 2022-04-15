using System;
using Helpers = MathLibrary.Helpers;

namespace MathLibrary
{
    public class Vector3
    {
        //Added tolerance to resolve close precision difference calculations
        // this is used in operator== and operator!= to prevent very close comparisons from failing
        //const float DEFAULT_TOLERANCE = 0.0001f;

        //AIE test use public members
        public float x, y, z;

        #region AIE properties
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public float Z { get { return z; } set { z = value; } }

        #endregion AIE properties

        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector3() { x = y = z = 0; }

        /// <summary>
        /// Parameter constructor
        /// </summary>
        /// <param name="inpX"></param>
        /// <param name="inpY"></param>
        /// <param name="inpZ"></param>
        public Vector3(float inpX, float inpY, float inpZ) => (x, y, z) = (inpX, inpY, inpZ);

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="vec"></param>
        public Vector3(Vector2 vec) => (x, y, z) = (vec.X, vec.Y, 0.0f);

        /// <summary>
        /// Conversion Constructor
        /// </summary>
        /// <param name="vec"></param>
        public Vector3(Vector3 vec) => (x, y, z) = (vec.x, vec.y, vec.z);

        /// <summary>
        /// Operator + adds two vector3s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        /// <summary>
        /// Operator - subtracts two vector3s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        /// <summary>
        /// Operator == compares two vector3s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            float xDiff = (float)Math.Abs(lhs.x - rhs.x);
            float yDiff = (float)Math.Abs(lhs.y - rhs.y);
            float zDiff = (float)Math.Abs(lhs.z - rhs.z);

            if (xDiff >  Helpers.DEFAULT_TOLERANCE)
                return false;
            if (yDiff > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (zDiff > Helpers.DEFAULT_TOLERANCE)
                return false;
            return true;
        }

        /// <summary>
        /// Operator != compares two vector3s
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            float xDiff = (float)Math.Abs(lhs.x - rhs.x);
            float yDiff = (float)Math.Abs(lhs.y - rhs.y);
            float zDiff = (float)Math.Abs(lhs.z - rhs.z);

            if (xDiff > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (yDiff > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (zDiff > Helpers.DEFAULT_TOLERANCE)
                return true;
            return false;
        }

        /// <summary>
        /// operator * multiplies two vector3s
        /// </summary>
        /// <param name="lhv"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator *(float lhv, Vector3 rhs)
        {            
            return new Vector3(lhv * rhs.x, lhv * rhs.y, lhv * rhs.z);
        }

        /// <summary>
        /// operator * multiplies a vector3 and a float
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhv"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 lhs, float rhv)
        {
            return new Vector3(lhs.x * rhv, lhs.y * rhv, lhs.z * rhv);            
        }

        /// <summary>
        /// Dot - computes the dot product of the vector3
        /// </summary>
        /// <param name="inpVec"></param>
        /// <returns></returns>
        public float Dot(Vector3 inpVec) // returns the dot
        {
            return x * inpVec.x + y * inpVec.y + z * inpVec.z;
        }

        /// <summary>
        /// SourceToDestVec - computes a vector from source to the destination 
        /// </summary>
        /// <param name="destVec"></param>
        /// <returns></returns>
        public Vector3 SourceToDestVec(Vector3 destVec)
        {
            return new Vector3(destVec.x - x, destVec.y - y, destVec.z - z);
        }

        /// <summary>
        /// Cross - computes the crossproduct of two vector3s
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(y * other.z - z * other.y, z * other.x - x * other.z, x * other.y - y * other.x);
        }

        /// <summary>
        /// Magnitude - computes the lenght of the vector3
        /// </summary>
        /// <returns></returns>
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Noramalize - normalizes the components of this vector3
        /// </summary>
        public void Normalize()
        {
            float mag = Magnitude();
            x /= mag;
            y /= mag;
            z /= mag;
        }

        /// <summary>
        /// normalize - property that returns a new normalized vector3 using this objects components
        /// </summary>
        public Vector3 normalized
        {
            get
            {
                float mag = Magnitude();
                return new Vector3(x / mag, y / mag, z / mag);
            }
        }

        /// <summary>
        /// AngleDegreesBetweenVector - returns the angle in degrees between this vector and other vector
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float AngleDegreesBetweenVector(Vector3 other)
        {
            return (float)Math.Acos(Dot(other.normalized) * 180.0f / (float)Math.PI);
        }
    }
}

