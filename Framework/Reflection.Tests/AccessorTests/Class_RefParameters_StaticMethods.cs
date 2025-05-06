using System;
using JJ.Framework.Reflection.Tests.Helpers;

// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantBoolCompare
// ReSharper disable CompareOfFloatsByEqualityOperator
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CS0078 // The 'l' suffix is easily confused with the digit '1'

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal static class Class_RefParameters_StaticMethods
    {
        // 1 Parameter

        private static bool StaticMethod_WithOneParameter(out int arg)
        {
            arg = 1;
            return true;
        }

        // 2 Parameters

        private static long StaticMethod_WithTwoParameters(ref float arg1, double arg2)
        {
            AreEqual(2f, arg1, nameof(arg1));
            arg1 = 3;
            AreEqual(4, () => arg2);
            return 5;
        }

        private static DateTime StaticMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            AreEqual(ParseHelper.ParseTimeSpan("00:06"), () => arg1);
            arg2 = "7";
            return ParseHelper.ParseDateTime("2008-01-01");
        }

        private static Guid StaticMethod_WithTwoParameters(ref string arg1, out TimeSpan arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = ParseHelper.ParseTimeSpan("00:11");
            return new Guid("00000000-0000-0000-0000-000000000012");
        }

        // 3 Parameters

        private static DateTime StaticMethod_WithThreeParameters(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13d, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15, () => arg2);
            AreEqual(16, () => arg3);
            return ParseHelper.ParseDateTime("2017-01-01");
        }

        private static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 18;
            AreEqual(19, () => arg3);
            return 20;
        }

        private static float StaticMethod_WithThreeParameters(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            AreEqual(21d, arg1, nameof(arg1));
            arg1 = 22;
            arg2 = ParseHelper.ParseDateTime("2023-01-01");
            AreEqual(ParseHelper.ParseTimeSpan("00:24"), () => arg3);
            return 25;
        }

        private static string StaticMethod_WithThreeParameters(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(ParseHelper.ParseTimeSpan("00:28"), arg3, nameof(arg3));
            arg3 = ParseHelper.ParseTimeSpan("00:29");
            return "30";
        }

        private static DateTime StaticMethod_WithThreeParameters(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32, () => arg2);
            AreEqual(33l, arg3, nameof(arg3));
            arg3 = 34;
            return ParseHelper.ParseDateTime("2035-01-01");
        }

        private static int StaticMethod_WithThreeParameters(bool arg1, out int arg2, ref long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 36;
            AreEqual(37l, arg3, nameof(arg3));
            arg3 = 38;
            return 39;
        }

        private static float StaticMethod_WithThreeParameters(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = 40;
            AreEqual(ParseHelper.ParseDateTime("2041-01-01"), arg2, nameof(arg2));
            arg2 = ParseHelper.ParseDateTime("2042-01-01");
            arg3 = ParseHelper.ParseTimeSpan("00:43");
            return 44;
        }

        // Misc

        private static void StaticMethod_WithReturnTypeVoid(ref DateTime arg)
        {
            AreEqual(ParseHelper.ParseDateTime("2045-01-01"), arg, nameof(arg));
            arg = ParseHelper.ParseDateTime("2046-01-01");
        }
    }
}
