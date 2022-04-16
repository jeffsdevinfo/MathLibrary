// Copyright (c) 2021 Jeff Simon
// Distributed under the MIT/X11 software license, see the accompanying
// file license.txt or http://www.opensource.org/licenses/mit-license.php.

using System;
using Helpers = MathLibrary.Helpers;

namespace MathLibrary
{
    public class Matrix3
    {
        float mXx, mXy, mXz;
        float mYx, mYy, mYz;
        float mZx, mZy, mZz;

        #region aie properties        
        public float m00 { get { return mXx; } set { mXx = value; } }  public float m01 { get { return mXy; } set { mXy = value; } }  public float m02 { get { return mXz; } set { mXz = value; } }
        public float m10 { get { return mYx; } set { mYx = value; } }  public float m11 { get { return mYy; } set { mYy = value; } }  public float m12 { get { return mYz; } set { mYz = value; } }
        public float m20 { get { return mZx; } set { mZx = value; } }  public float m21 { get { return mZy; } set { mZy = value; } }  public float m22 { get { return mZz; } set { mZz = value; } }
        #endregion aie properties

        /// <summary>
        /// Default Constructor - initialize to zero matrix
        /// </summary>
        public Matrix3()
        {
            Set(0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Copy Constructor - copy each element from copyMat to each element of new current new mat
        /// </summary>
        /// <param name="copyMat"></param>
        public Matrix3(Matrix3 copyMat)
        {
            mXx = copyMat.m00; mXy = copyMat.m01; mXz = copyMat.m02; mYx = copyMat.m10; mYy = copyMat.m11; mYz = copyMat.m12; mZx = copyMat.m20; mZy = copyMat.m21; mZz = copyMat.m22;
        }

        /// <summary>
        /// Parameter driven constructor - initialze the matrix, column order, and each column is an axis
        /// </summary>
        /// <param name="Xx"></param>
        /// <param name="Xy"></param>
        /// <param name="Xz"></param>
        /// <param name="Yx"></param>
        /// <param name="Yy"></param>
        /// <param name="Yz"></param>
        /// <param name="Zx"></param>
        /// <param name="Zy"></param>
        /// <param name="Zz"></param>
        public Matrix3( float Xx, float Xy, float Xz,
                        float Yx, float Yy, float Yz,
                        float Zx, float Zy, float Zz)
        {
            //m00     m01       m02       m10       m11      m12        m20       m21       m22
            mXx = Xx; mXy = Xy; mXz = Xz; mYx = Yx; mYy = Yy; mYz = Yz; mZx = Zx; mZy = Zy; mZz = Zz;
        }

        /// <summary>
        /// Scale constructor - create a scaled matrix
        /// </summary>
        /// <param name="scale"></param>
        public Matrix3(float scale)
        {
            Set(scale, 0, 0, 0, scale, 0, 0, 0, scale);
        }
        
        /// <summary>
        /// Set the translation elements of the matrix
        /// </summary>
        /// <param name="Tx"></param>
        /// <param name="Ty"></param>
        public void SetTranslation(float Tx, float Ty)
        {
            mZx = Tx;
            mZy = Ty;
            mZz = 1;        
        }

        /// <summary>
        /// Parameter constructor - initialize the matrix with vectors for each axis
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Matrix3(Vector3 X, Vector3 Y, Vector3 Z)
        {
            mXx = X.X; mXy = X.Y; mXz = X.Z;
            mYx = Y.X; mYy = Y.Y; mYz = Y.Z;
            mZx = Z.X; mZy = Z.Y; mZz = Z.Z;
        }

        /// <summary>
        /// Parameter constructor - if true create identity matrix (redundant with scale matrix constructor)
        /// </summary>
        /// <param name="bIdentityMatrix"></param>
        public Matrix3(bool bIdentityMatrix)
        {
            if (bIdentityMatrix)
            {
                Set(1, 0, 0, 0, 1, 0, 0, 0, 1);
            }
            else
            {
                Set(0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Method to set individual components of matrix, column wise, each column is an axis
        /// </summary>
        /// <param name="Xx"></param>
        /// <param name="Xy"></param>
        /// <param name="Xz"></param>
        /// <param name="Yx"></param>
        /// <param name="Yy"></param>
        /// <param name="Yz"></param>
        /// <param name="Zx"></param>
        /// <param name="Zy"></param>
        /// <param name="Zz"></param>
        public void Set(float Xx, float Xy, float Xz,
                        float Yx, float Yy, float Yz,
                        float Zx, float Zy, float Zz)
        {
            mXx = Xx; mXy = Xy; mXz = Xz;
            mYx = Yx; mYy = Yy; mYz = Yz;
            mZx = Zx; mZy = Zy; mZz = Zz;
        }

        #region operator overloads
        /// <summary>
        /// Matrix transformation
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.mXx * rhs.X) + (lhs.mYx * rhs.Y) + (lhs.mZx * rhs.Z),
                (lhs.mXy * rhs.X) + (lhs.mYy * rhs.Y) + (lhs.mZy * rhs.Z),
                (lhs.mXz * rhs.X) + (lhs.mYz * rhs.Y) + (lhs.mZz * rhs.Z));
        }

        /// <summary>
        /// Matrix concatenation
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {            
            return new Matrix3(
            (lhs.mXx * rhs.mXx) + (lhs.mYx * rhs.mXy) + (lhs.mZx * rhs.mXz),
            (lhs.mXy * rhs.mXx) + (lhs.mYy * rhs.mXy) + (lhs.mZy * rhs.mXz),
            (lhs.mXz * rhs.mXx) + (lhs.mYz * rhs.mXy) + (lhs.mZz * rhs.mXz),
                                                                           
            (lhs.mXx * rhs.mYx) + (lhs.mYx * rhs.mYy) + (lhs.mZx * rhs.mYz),
            (lhs.mXy * rhs.mYx) + (lhs.mYy * rhs.mYy) + (lhs.mZy * rhs.mYz),
            (lhs.mXz * rhs.mYx) + (lhs.mYz * rhs.mYy) + (lhs.mZz * rhs.mYz),
                                                                           
            (lhs.mXx * rhs.mZx) + (lhs.mYx * rhs.mZy) + (lhs.mZx * rhs.mZz),
            (lhs.mXy * rhs.mZx) + (lhs.mYy * rhs.mZy) + (lhs.mZy * rhs.mZz),
            (lhs.mXz * rhs.mZx) + (lhs.mYz * rhs.mZy) + (lhs.mZz * rhs.mZz));
        }

        /// <summary>
        /// Operator == compares each of the components between both matrices and deteremines if the
        ///  difference is greater than the tolerance.  
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Matrix3 lhs, Matrix3 rhs)
        {
            if (Math.Abs(lhs.mXx - rhs.mXx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mXy - rhs.mXy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mXz - rhs.mXz) > Helpers.DEFAULT_TOLERANCE)
                return false;

            if (Math.Abs(lhs.mYx - rhs.mYx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mYy - rhs.mYy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mYz - rhs.mYz) > Helpers.DEFAULT_TOLERANCE)
                return false;

            if (Math.Abs(lhs.mZx - rhs.mZx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mZy - rhs.mZy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mZz - rhs.mZz) > Helpers.DEFAULT_TOLERANCE)
                return false;

            return true;
        }

        /// <summary>
        /// Operator != performs the opposite of operator ==
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Matrix3 lhs, Matrix3 rhs)
        {
            if (Math.Abs(lhs.mXx - rhs.mXx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mXy - rhs.mXy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mXz - rhs.mXz) > Helpers.DEFAULT_TOLERANCE)
                return true;

            if (Math.Abs(lhs.mYx - rhs.mYx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mYy - rhs.mYy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mYz - rhs.mYz) > Helpers.DEFAULT_TOLERANCE)
                return true;

            if (Math.Abs(lhs.mZx - rhs.mZx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mZy - rhs.mZy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mZz - rhs.mZz) > Helpers.DEFAULT_TOLERANCE)
                return true;

            return false;
        }
        #endregion operator overloads

        /// <summary>
        /// Rotate the Matrix X Axis by rotationRadians 
        /// </summary>
        /// <param name="rotationRadians"></param>
        public void SetRotateX(float rotationRadians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(rotationRadians), (float)Math.Sin(rotationRadians),
                0, (float)-Math.Sin(rotationRadians), (float)Math.Cos(rotationRadians));
        }

        /// <summary>
        /// Rotate the Matrix Y Axis by rotationRadians 
        /// </summary>
        /// <param name="rotationRadians"></param>
        public void SetRotateY(float rotationRadians)
        {
            Set((float)Math.Cos(rotationRadians), 0, (float)-Math.Sin(rotationRadians),
                0, 1, 0,
                (float)Math.Sin(rotationRadians), 0, (float)Math.Cos(rotationRadians));
        }

        /// <summary>
        /// Rotate the Matrix Z Axis by rotationRadians 
        /// </summary>
        /// <param name="rotationRadians"></param>
        public void SetRotateZ(float rotationRadians)
        {
            Set((float)Math.Cos(rotationRadians), (float)Math.Sin(rotationRadians), 0,
                (float)-Math.Sin(rotationRadians), (float)Math.Cos(rotationRadians), 0,
                0, 0, 1);                
        }
    }
}
