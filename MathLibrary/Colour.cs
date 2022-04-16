// Copyright (c) 2021 Jeff Simon
// Distributed under the MIT/X11 software license, see the accompanying
// file license.txt or http://www.opensource.org/licenses/mit-license.php.

using System;

namespace MathLibrary
{
    public struct Colour
    {
        public UInt32 colour; // holds individual bytes of rgba

        /// <summary>
        /// Parameter constructor - each component of main colour 
        /// Calling this() on constructor declaration lets the base ValueType initalize 
        ///     all backing fields
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public Colour(byte r, byte g, byte b, byte a) : this()
        {
            red = r;
            green = g;
            blue = b;
            alpha = a;
        }

        #region properties         
        public byte red
        {            
            get { return (byte)(colour >> 24); }             // creating a temporary color by shifting right 24 converting result to byte
            set { colour = colour ^ ((UInt32)value << 24); } // alternative using bitwise xor for preserving and setting bytes
        }

        public byte green
        {
            get { return (byte)(colour >> 16); }

            // instructor provided method of setting colour - same technique used with blue and alpha properties
            //  (colour & 0xff00ffff) //create temp Uint32 value by bitwise & original color with a value that zeros out specific color position
            //  (UInt32)value << 16)  //next generate another Uint32 value by left shifting the input byte value by the offset position in the rgba scheme.  
            //  colour = (colour & 0xff00ffff) | ((UInt32)value << 16); //finally assign the color value to the bitwise or of the two temp values
            //  The result is a colour value that has preserved the components of the original colour and has assigned the targeted input component 
            //   of the colour value to the provided input value.
            set { colour = (colour & 0xff00ffff) | ((UInt32)value << 16); } 
        }

        public byte blue
        {
            get { return (byte)(colour >> 8); }
            set { colour = (colour & 0xffff00ff) | ((UInt32)value << 8); }
        }

        public byte alpha
        {
            get { return (byte)(colour >> 0); }
            set { colour = (colour & 0xffffff00) | ((UInt32)value << 0); }
        }

        #endregion
    }
}
