//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace JJ.Analysis.Helpers
//{
//    internal class CaseHelper
//    {
//        /// <summary>
//        /// Because only abbreviations of 2 letters are in caps,
//        /// and abbreviations of 3 or more letters are pascal case,
//        /// so that makes max 3 in a row, except if there are multiple 2-letter abbreviations
//        /// in a row... hmmm...
//        /// TODO: Investigate that last bit.
//        /// </summary>
//        private const int MAX_UPPER_CHARS_IN_A_ROW = 3;

//        public static bool StartsWithUpperCase(string value)
//        {
//            bool isUpper = IsUpper(value, 0);
//            return isUpper;
//        }

//        public static bool IsPascalCase(string name)
//        {
//            if (String.IsNullOrEmpty(name))
//            {
//                return false;
//            }

//            if (IsLower(name, index: 0))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool IsCamelCase(string name)
//        {
//            if (String.IsNullOrEmpty(name))
//            {
//                return false;
//            }

//            if (IsUpper(name, index: 0))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool IsUnderscoredCamelCase(string name)
//        {
//            if (String.IsNullOrEmpty(name))
//            {
//                return false;
//            }

//            if (!name.StartsWith('_'))
//            {
//                return false;
//            }

//            if (IsUpper(name, 1))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool HasTooManyUpperCharsInARow(string name, int max)
//        {
//            int upperCharsInARow = 0;

//            for (int i = 0; i < name.Length; i++)
//            {
//                char chr = name[i];

//                if (char.IsUpper(chr))
//                {
//                    upperCharsInARow++;
//                }
//                else
//                {
//                    upperCharsInARow = 0;
//                }

//                if (upperCharsInARow > max)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }

//        private static bool IsUpper(string name, int index)
//        {
//            if (index >= name.Length)
//            {
//                return false;
//            }

//            char chr = name[index];

//            bool isUpper = char.IsUpper(chr);

//            return isUpper;
//        }

//        private static bool IsLower(string name, int index)
//        {
//            if (index >= name.Length)
//            {
//                return false;
//            }

//            char chr = name[index];

//            bool isLower = char.IsLower(chr);

//            return isLower;
//        }
//    }
//}