// Copyright (c) 2021 Jeff Simon
// Distributed under the MIT/X11 software license, see the accompanying
// file license.txt or http://www.opensource.org/licenses/mit-license.php.

using System;
using Helpers = MathLibrary.Helpers;

namespace MathLibrary
{
    public class Matrix4
    {        
        private float mXx, mXy, mXz, mXw;
        private float mYx, mYy, mYz, mYw;
        private float mZx, mZy, mZz, mZw;
        private float mTx, mTy, mTz, mTw;

        //AIE properties
        #region AIE properties
        public float m00 { get { return mXx; } set { mXx = value; } }  public float m01 { get { return mXy; } set { mXy = value; } }  public float m02 { get { return mXz; } set { mXz = value; } } public float m03 { get { return mXw; } set { mXw = value; } }
        public float m10 { get { return mYx; } set { mYx = value; } }  public float m11 { get { return mYy; } set { mYy = value; } }  public float m12 { get { return mYz; } set { mYz = value; } } public float m13 { get { return mYw; } set { mYw = value; } }
        public float m20 { get { return mZx; } set { mZx = value; } }  public float m21 { get { return mZy; } set { mZy = value; } }  public float m22 { get { return mZz; } set { mZz = value; } } public float m23 { get { return mZw; } set { mZw = value; } }
        public float m30 { get { return mTx; } set { mTx = value; } }  public float m31 { get { return mTy; } set { mTy = value; } }  public float m32 { get { return mTz; } set { mTz = value; } } public float m33 { get { return mTw; } set { mTw = value; } }
        #endregion AIE properties

        /// <summary>
        /// Default constructor - set to zero matrix
        /// </summary>
        public Matrix4()
        {
            Set(0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0);
        }

        /// <summary>
        /// Parameter constructor - assign the members of the matrix, column order, each column is an axis
        /// </summary>      
        public Matrix4( float Xx, float Xy, float Xz, float Xw,
                        float Yx, float Yy, float Yz, float Yw,
                        float Zx, float Zy, float Zz, float Zw,
                        float Tx, float Ty, float Tz, float Tw)
        { 
            mXx = Xx; mXy = Xy; mXz = Xz; mXw = Xw;
            mYx = Yx; mYy = Yy; mYz = Yz; mYw = Yw;
            mZx = Zx; mZy = Zy; mZz = Zz; mZw = Zw;
            mTx = Tx; mTy = Ty; mTz = Tz; mTw = Tw;
        }

        /// <summary>
        /// Paramter constructor - use vectors for each axis in the mat and assign accordingly
        /// </summary>        
        public Matrix4(Vector3 X, Vector3 Y, Vector3 Z)
        {
            mXx = X.X; mXy = X.Y; mXz = X.Z;
            mYx = Y.X; mYy = Y.Y; mYz = Y.Z;
            mZx = Z.X; mZy = Z.Y; mZz = Z.Z;
        }

        /// <summary>
        /// Paramter constructor - set identity matrix (possibly redundant)
        /// </summary>
        /// <param name="bIdentityMatrix"></param>
        public Matrix4(bool bIdentityMatrix)
        {
            if (bIdentityMatrix)
            {
                Set(1, 0, 0, 0,
                    0, 1, 0, 0, 
                    0, 0, 1, 0,
                    0, 0, 0, 1);
            }
            else
            {
                Set(0, 0, 0, 0, 
                    0, 0, 0, 0, 
                    0, 0, 0, 0,
                    0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Paramter constructor - initialize and scale matrix
        /// </summary>
        /// <param name="scale"></param>
        public Matrix4(float scale)
        {
            Set(scale, 0, 0, 0, 
                0, scale, 0, 0, 
                0, 0, scale, 0,
                0,0,0,scale);
        }

        /// <summary>
        /// Set the components of the matrix, column order, each column is an axis
        /// </summary>        
        public void Set (float Xx, float Xy, float Xz, float Xw,
                         float Yx, float Yy, float Yz, float Yw,
                         float Zx, float Zy, float Zz, float Zw,
                         float Tx, float Ty, float Tz, float Tw)
        {
            mXx = Xx; mXy = Xy; mXz = Xz; mXw = Xw;
            mYx = Yx; mYy = Yy; mYz = Yz; mYw = Yw;
            mZx = Zx; mZy = Zy; mZz = Zz; mZw = Zw;
            mTx = Tx; mTy = Ty; mTz = Tz; mTw = Tw;
        }

        #region operator overloads
        /// <summary>
        /// Matrix transformation
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                (lhs.mXx * rhs.X) + (lhs.mYx * rhs.Y) + (lhs.mZx * rhs.Z) + (lhs.mTx * rhs.w),
                (lhs.mXy * rhs.X) + (lhs.mYy * rhs.Y) + (lhs.mZy * rhs.Z) + (lhs.mTy * rhs.w),
                (lhs.mXz * rhs.X) + (lhs.mYz * rhs.Y) + (lhs.mZz * rhs.Z) + (lhs.mTz * rhs.w),
                (lhs.mXw * rhs.X) + (lhs.mYw * rhs.Y) + (lhs.mZw * rhs.Z) + (lhs.mTw * rhs.w));
        }

        /// <summary>
        /// Matrix concatenation
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                (lhs.mXx * rhs.mXx) + (lhs.mYx * rhs.mXy) + (lhs.mZx * rhs.mXz) + (lhs.mTx * rhs.mXw),
                (lhs.mXy * rhs.mXx) + (lhs.mYy * rhs.mXy) + (lhs.mZy * rhs.mXz) + (lhs.mTy * rhs.mXw),
                (lhs.mXz * rhs.mXx) + (lhs.mYz * rhs.mXy) + (lhs.mZz * rhs.mXz) + (lhs.mTz * rhs.mXw),
                (lhs.mXw * rhs.mXx) + (lhs.mYw * rhs.mXy) + (lhs.mZw * rhs.mXz) + (lhs.mTw * rhs.mXw),
                                                                                                     
                (lhs.mXx * rhs.mYx) + (lhs.mYx * rhs.mYy) + (lhs.mZx * rhs.mYz) + (lhs.mTx * rhs.mYw),
                (lhs.mXy * rhs.mYx) + (lhs.mYy * rhs.mYy) + (lhs.mZy * rhs.mYz) + (lhs.mTy * rhs.mYw),
                (lhs.mXz * rhs.mYx) + (lhs.mYz * rhs.mYy) + (lhs.mZz * rhs.mYz) + (lhs.mTz * rhs.mYw),
                (lhs.mXw * rhs.mYx) + (lhs.mYw * rhs.mYy) + (lhs.mZw * rhs.mYz) + (lhs.mTw * rhs.mYw),
                                                                                                     
                (lhs.mXx * rhs.mZx) + (lhs.mYx * rhs.mZy) + (lhs.mZx * rhs.mZz) + (lhs.mTx * rhs.mZw),
                (lhs.mXy * rhs.mZx) + (lhs.mYy * rhs.mZy) + (lhs.mZy * rhs.mZz) + (lhs.mTy * rhs.mZw),
                (lhs.mXz * rhs.mZx) + (lhs.mYz * rhs.mZy) + (lhs.mZz * rhs.mZz) + (lhs.mTz * rhs.mZw),
                (lhs.mXw * rhs.mZx) + (lhs.mYw * rhs.mZy) + (lhs.mZw * rhs.mZz) + (lhs.mTw * rhs.mZw),
                                                                                                     
                (lhs.mXx * rhs.mTx) + (lhs.mYx * rhs.mTy) + (lhs.mZx * rhs.mTz) + (lhs.mTx * rhs.mTw),
                (lhs.mXy * rhs.mTx) + (lhs.mYy * rhs.mTy) + (lhs.mZy * rhs.mTz) + (lhs.mTy * rhs.mTw),
                (lhs.mXz * rhs.mTx) + (lhs.mYz * rhs.mTy) + (lhs.mZz * rhs.mTz) + (lhs.mTz * rhs.mTw),
                (lhs.mXw * rhs.mTx) + (lhs.mYw * rhs.mTy) + (lhs.mZw * rhs.mTz) + (lhs.mTw * rhs.mTw));
        }

        /// <summary>
        /// Operator == checks each component difference against tolerance
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Matrix4 lhs, Matrix4 rhs)
        { 
            if (Math.Abs(lhs.mXx - rhs.mXx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mXy - rhs.mXy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mXz - rhs.mXz) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mXz - rhs.mXw) > Helpers.DEFAULT_TOLERANCE)
                return false;

            if (Math.Abs(lhs.mYx - rhs.mYx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mYy - rhs.mYy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mYz - rhs.mYz) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mYz - rhs.mYw) > Helpers.DEFAULT_TOLERANCE)
                return false;

            if (Math.Abs(lhs.mZx - rhs.mZx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mZy - rhs.mZy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mZz - rhs.mZz) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mZz - rhs.mZw) > Helpers.DEFAULT_TOLERANCE)
                return false;

            if (Math.Abs(lhs.mTx - rhs.mTx) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mTy - rhs.mTy) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mTz - rhs.mTz) > Helpers.DEFAULT_TOLERANCE)
                return false;
            if (Math.Abs(lhs.mTz - rhs.mTw) > Helpers.DEFAULT_TOLERANCE)
                return false;

            return true;
        }

        /// <summary>
        /// Operator == checks each component difference against tolerance
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Matrix4 lhs, Matrix4 rhs)
        {                                                                                    
            if (Math.Abs(lhs.mXx - rhs.mXx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mXy - rhs.mXy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mXz - rhs.mXz) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mXz - rhs.mXw) > Helpers.DEFAULT_TOLERANCE)
                return true;

            if (Math.Abs(lhs.mYx - rhs.mYx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mYy - rhs.mYy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mYz - rhs.mYz) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mYz - rhs.mYw) > Helpers.DEFAULT_TOLERANCE)
                return true;

            if (Math.Abs(lhs.mZx - rhs.mZx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mZy - rhs.mZy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mZz - rhs.mZz) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mZz - rhs.mZw) > Helpers.DEFAULT_TOLERANCE)
                return true;

            if (Math.Abs(lhs.mTx - rhs.mTx) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mTy - rhs.mTy) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mTz - rhs.mTz) > Helpers.DEFAULT_TOLERANCE)
                return true;
            if (Math.Abs(lhs.mTz - rhs.mTw) > Helpers.DEFAULT_TOLERANCE)
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
            Set(1,0,0,0,                                                        //xaxis
                0, (float)Math.Cos(rotationRadians), (float)(Math.Sin(rotationRadians)), 0, //yaxis
                0, (float)-Math.Sin(rotationRadians), (float)Math.Cos(rotationRadians), 0,  //zxis
                0,0,0,1);                                                       //taxis
        }

        /// <summary>
        /// Rotate the Matrix Y Axis by rotationRadians 
        /// </summary>
        /// <param name="rotationRadians"></param>
        public void SetRotateY(float rotationRadians)
        {
            Set((float)Math.Cos(rotationRadians), 0, (float)(-Math.Sin(rotationRadians)), 0,  //xaxis
                0, 1, 0, 0,                                                       //yaxis
                (float)Math.Sin(rotationRadians),0, (float)Math.Cos(rotationRadians),0,       //zaxis
                0,0,0,1);                                                         //taxis

        }

        /// <summary>
        /// Rotate the Matrix Z Axis by rotationRadians 
        /// </summary>
        /// <param name="rotationRadians"></param>
        public void SetRotateZ(float rotationRadians)
        {            
            Set((float)Math.Cos(rotationRadians), (float)Math.Sin(rotationRadians), 0, 0,       //x axis which is a column
                (float)-Math.Sin(rotationRadians), (float)Math.Cos(rotationRadians), 0, 0,      //y axis
                0, 0, 1, 0,                                                         //z axis
                0, 0, 0, 1);                                                        //t axis            
        }
    }
}
