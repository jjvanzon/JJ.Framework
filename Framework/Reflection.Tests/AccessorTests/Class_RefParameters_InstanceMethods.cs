using System;
using JJ.Framework.Exceptions.Comparative;

// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantBoolCompare
// ReSharper disable CompareOfFloatsByEqualityOperator
#pragma warning disable IDE0051 // Remove unused private members

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class Class_RefParameters_InstanceMethods
    {
        // 1 Parameter

        private bool InstanceMethod_WithOneParameter(out int arg)
        {
            arg = 1;
            return true;
        }

        // 2 Parameters

        private long InstanceMethod_WithTwoParameters(ref float arg1, double arg2)
        {
            if (arg1 != 2) throw new NotEqualException(nameof(arg1), 2);
            arg1 = 3;
            if (arg2 != 4) throw new NotEqualException(() => arg2, 4);
            return 5;
        }

        private DateTime InstanceMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            if (arg1 != ParseHelper.ParseTimeSpan("00:06")) throw new NotEqualException(() => arg1, ParseHelper.ParseTimeSpan("00:06"));
            arg2 = "7";
            return ParseHelper.ParseDateTime("2008-01-01");
        }

        private Guid InstanceMethod_WithTwoParameters(ref string arg1, out TimeSpan arg2)
        {
            if (!string.Equals(arg1, "9")) throw new NotEqualException(nameof(arg1), "9");
            arg1 = "10";
            arg2 = ParseHelper.ParseTimeSpan("00:11");
            return new Guid("00000000-0000-0000-0000-000000000012");
        }

        // 3 Parameters

        private DateTime InstanceMethod_WithThreeParameters(ref double arg1, float arg2, long arg3)
        {
            if (arg1 != 13) throw new NotEqualException(nameof(arg1), 13);
            arg1 = 14;
            if (arg2 != 15) throw new NotEqualException(() => arg2, 15);
            if (arg3 != 16) throw new NotEqualException(() => arg3, 16);
            return ParseHelper.ParseDateTime("2017-01-01");
        }

        private int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            if (arg1 != true) throw new NotEqualException(() => arg1, true);
            arg2 = 18;
            if (arg3 != 19) throw new NotEqualException(() => arg3, 19);
            return 20;
        }

        private float InstanceMethod_WithThreeParameters(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            if (arg1 != 21) throw new NotEqualException(nameof(arg1), 21);
            arg1 = 22;
            arg2 = ParseHelper.ParseDateTime("2023-01-01");
            if (arg3 != ParseHelper.ParseTimeSpan("00:24")) throw new NotEqualException(() => arg3, () => ParseHelper.ParseTimeSpan("00:24"));
            return 25;
        }

        private string InstanceMethod_WithThreeParameters(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            if (arg1 != new Guid("00000000-0000-0000-0000-000000000026")) throw new NotEqualException(() => arg1, new Guid("00000000-0000-0000-0000-000000000026"));
            if (!string.Equals(arg2, "27")) throw new NotEqualException(() => arg2, "27");
            if (arg3 != ParseHelper.ParseTimeSpan("00:28")) throw new NotEqualException(nameof(arg3), () => ParseHelper.ParseTimeSpan("00:28"));
            arg3 = ParseHelper.ParseTimeSpan("00:29");
            return "30";
        }

        private DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            if (arg2 != 32) throw new NotEqualException(() => arg2, 32);
            if (arg3 != 33) throw new NotEqualException(nameof(arg3), 33);
            arg3 = 34;
            return ParseHelper.ParseDateTime("2035-01-01");
        }

        private int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, ref long arg3)
        {
            if (arg1 != true) throw new NotEqualException(() => arg1, true);
            arg2 = 36;
            if (arg3 != 37) throw new NotEqualException(nameof(arg3), 37);
            arg3 = 38;
            return 39;
        }

        private float InstanceMethod_WithThreeParameters(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = 40;
            if (arg2 != ParseHelper.ParseDateTime("2041-01-01")) throw new NotEqualException(arg2, () => ParseHelper.ParseDateTime("2041-01-01"));
            arg2 = ParseHelper.ParseDateTime("2042-01-01");
            arg3 = ParseHelper.ParseTimeSpan("00:43");
            return 44;
        }

        // Misc

        private void InstanceMethod_WithReturnTypeVoid(ref DateTime arg)
        {
            if (arg != ParseHelper.ParseDateTime("2045-01-01")) throw new NotEqualException(arg, () => ParseHelper.ParseDateTime("2045-01-01"));
            arg = ParseHelper.ParseDateTime("2046-01-01");
        }
    }
}
