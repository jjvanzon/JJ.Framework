using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;

namespace JJ.Framework.Text.Core
{
    public static class StringExtensionsLegacy
    {
        /// <summary>
        /// Will trim off repetitions of the same value from the given string.
        /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
        /// </summary>
        public static string TrimEnd(this string input, string end)
        {
            if (string.IsNullOrEmpty(end)) throw new Exception($"{nameof(end)} is null or empty.");
            
            string temp = input;
            
            while (temp.EndsWith(end))
            {
                temp = temp.TrimEnd(end.Length);
            }
            
            return temp;
        }
        
        /// <summary>
        /// Will trim off repetitions of the same value from the given string.
        /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
        /// </summary>
        public static string TrimEnd(this string input, int length) => input.Left(input.Length - length);
        
        /// <summary>
        /// Will trim off repetitions of the same value from the given string.
        /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
        /// </summary>
        public static string TrimStart(this string input, string start)
        {
            if (string.IsNullOrEmpty(start)) throw new Exception($"{nameof(start)} is null or empty.");
            
            string temp = input;
            
            while (temp.StartsWith(start))
            {
                temp = temp.TrimStart(start.Length);
            }
            
            return temp;
        }
        
        /// <summary>
        /// Will trim off repetitions of the same value from the given string.
        /// These are variations of the standard .NET methods that instead of just taking char[] can take a string or a length.
        /// </summary>
        public static string TrimStart(this string input, int length) => input.Right(input.Length - length);
        
        /// <summary>
        /// Repeat a string a number of times, returning a single string.
        /// </summary>
        public static string Repeat(this string stringToRepeat, int repeatCount)
        {
            if (stringToRepeat == null) throw new ArgumentNullException(nameof(stringToRepeat));
            
            char[] sourceChars  = stringToRepeat.ToCharArray();
            int    sourceLength = sourceChars.Length;
            
            int destLength = sourceLength * repeatCount;
            var destChars  = new char[destLength];
            
            for (var i = 0; i < destLength; i += sourceLength)
            {
                Array.Copy(sourceChars, 0, destChars, i, sourceLength);
            }
            
            var destString = new string(destChars);
            return destString;
        }
        
        /// <summary>
        /// Takes the part of a string until the specified delimiter. Excludes the delimiter itself.
        /// </summary>
        public static string TakeEndUntil(this string input, string until)
        {
            if (until == null) throw new ArgumentNullException(nameof(until));
            int index = input.LastIndexOf(until, StringComparison.Ordinal);
            if (index == -1) return "";
            int    length = input.Length - index - 1;
            string output = input.Right(length);
            return output;
        }
        
        /// <summary>
        /// Returns the left part of a string.
        /// Can return less characters than the length provided if string is shorter.
        /// </summary>
        public static string TakeStart(this string input, int length)
        {
            if (length > input.Length) length = input.Length;
            
            return input.Left(length);
        }
    }
}