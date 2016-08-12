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

//        public static bool IsPascalCase_WithNoMoreThan3CapsInARow(string name)
//        {
//            if (String.IsNullOrEmpty(name))
//            {
//                return false;
//            }

//            if (IsLower(name, index: 0))
//            {
//                return false;
//            }

//            if (HasTooManyUpperCharsInARow(name, firstIndex: 1, max: 3))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool IsCamelCase_WithNoMoreThan3CapsInARow(string name)
//        {
//            if (String.IsNullOrEmpty(name))
//            {
//                return false;
//            }

//            if (IsUpper(name, index: 0))
//            {
//                return false;
//            }

//            if (HasTooManyUpperCharsInARow(name, firstIndex: 1, max: 3))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool IsUnderscoredCamelCase_WithNoMoreThan3CapsInARow(string name)
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
//                char chr = name[1];
//                if (char.IsUpper(chr))
//                {
//                    return false;
//                }
//            }

//            if (HasTooManyUpperCharsInARow(name, firstIndex: 2, max: 3))
//            {
//                return false;
//            }

//            return true;
//        }

//        public static bool HasTooManyUpperCharsInARow(string name, int max)
//        {
//            return HasTooManyUpperCharsInARow(name, 0, max);
//        }

//        private static bool HasTooManyUpperCharsInARow(string name, int firstIndex, int max)
//        {
//            int upperCharsInARow = 0;

//            for (int i = firstIndex; i < name.Length; i++)
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