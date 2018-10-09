// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Globalization;

namespace Puzzle.NCore.Framework.Text
{
    //(c) WE WASTE MEMORY 2004
    public class CharUtils
    {
        private static bool[] isLetterOrDigitLookup = null;
        private static bool[] isLetterLookup = null;
        private static char[] lowerCharLookup = null;
        private static char[] upperCharLookup = null;
        private static bool[] separatorCharLookup = null;

        public static bool[] IsLetterOrDigitLookup
        {
            get
            {
                if (isLetterOrDigitLookup == null)
                {
                    isLetterOrDigitLookup = new bool[65536];
                    for (int i = 0; i < 65536; i++)
                    {
                        isLetterOrDigitLookup[i] = char.IsLetterOrDigit((char) i);
                    }
                }

                return isLetterOrDigitLookup;
            }
        }

        public static bool[] IsLetterLookup
        {
            get
            {
                if (isLetterLookup == null)
                {
                    isLetterLookup = new bool[65536];
                    for (int i = 0; i < 65536; i++)
                    {
                        isLetterLookup[i] = char.IsLetter((char) i);
                    }
                }

                return isLetterLookup;
            }
        }

        public static bool[] SeparatorCharLookup
        {
            get
            {
                if (separatorCharLookup == null)
                {
                    separatorCharLookup = new bool[65536];
                    for (int i = 0; i < 65536; i++)
                    {
                        separatorCharLookup[i] = char.IsSeparator((char) i);
                    }
                }

                return separatorCharLookup;
            }
        }

        public static char[] LowerCharLookup
        {
            get
            {
                if (lowerCharLookup == null)
                {
                    lowerCharLookup = new char[65536];
                    for (int i = 0; i < 65536; i++)
                    {
                        lowerCharLookup[i] = char.ToLower((char) i, CultureInfo.InvariantCulture);
                    }
                }

                return lowerCharLookup;
            }
        }

        public static char[] UpperCharLookup
        {
            get
            {
                if (upperCharLookup == null)
                {
                    upperCharLookup = new char[65536];
                    for (int i = 0; i < 65536; i++)
                    {
                        upperCharLookup[i] = char.ToUpper((char) i, CultureInfo.InvariantCulture);
                    }
                }

                return upperCharLookup;
            }
        }

        //This is 4.5 times faster than a standard char.ToUpper
        public static char ToUpper(char c) => UpperCharLookup[(int) c];

        //This is 4.5 times faster than a standard char.ToLower
        public static char ToLower(char c) => LowerCharLookup[(int) c];

        //This is 2.4 times faster than a standard char.IsSeparator
        public static bool IsSeparator(char c) => SeparatorCharLookup[(int) c];

        public static bool IsLetter(char c) => IsLetterLookup[(int) c];

        public static bool IsLetterOrDigit(char c) => IsLetterOrDigitLookup[(int) c];
    }
}