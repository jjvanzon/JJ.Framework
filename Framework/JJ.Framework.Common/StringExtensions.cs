using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Common
{
    public static partial class StringExtensions
    {
        public static string Left(this string str, int length)
        {
            return str.Substring(0, length);
        }

        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string CutRight(this string str, char chr)
        {
            return CutRight(str, chr.ToString());
        }

        public static string CutRight(this string str, string end)
        {
            if (str.EndsWith(end)) return str.CutRight(end.Length);
            return str;
        }

        public static string CutRight(this string str, int length)
        {
            return str.Left(str.Length - length);
        }

        public static string CutLeft(this string str, char chr)
        {
            return CutLeft(str, chr.ToString());
        }

        public static string CutLeft(this string str, string start)
        {
            if (str.StartsWith(start)) return str.CutLeft(start.Length);
            return str;
        }

        public static string CutLeft(this string str, int length)
        {
            return str.Right(str.Length - length);
        }

        public static string FromTill(this string str, int startIndex, int endIndex)
        {
            return str.Substring(startIndex, endIndex - startIndex + 1);
        }
    }
}
