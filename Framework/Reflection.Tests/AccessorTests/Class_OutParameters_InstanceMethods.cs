using System;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Comparative;

// ReSharper disable RedundantBoolCompare
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    /// <summary>
    /// NOTE: Members were made Obsolete to force it to be called through reflection.
    /// </summary>
    public class Class_OutParameters_InstanceMethods
    {
        // 1 Parameter

        [Obsolete("", true)]
        [UsedImplicitly]
        public bool InstanceMethod_WithOneParameter(out int arg)
        {
            arg = 1;
            return true;
        }

        // 2 Parameters

        [Obsolete("", true)]
        [UsedImplicitly]
        public long InstanceMethod_WithTwoParameters(out float arg1, double arg2)
        {
            arg1 = 2;
            if (arg2 != 3) throw new NotEqualException(() => arg2, 3);
            return 4;
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public DateTime InstanceMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            if (arg1 != ParseHelper.ParseTimeSpan("00:05")) throw new NotEqualException(() => arg1, ParseHelper.ParseTimeSpan("00:05"));
            arg2 = "6";
            return ParseHelper.ParseDateTime("2007-01-01");
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public Guid InstanceMethod_WithTwoParameters(out string arg1, out TimeSpan arg2)
        {
            arg1 = "8";
            arg2 = ParseHelper.ParseTimeSpan("00:09");
            return new Guid("00000000-0000-0000-0000-000000000010");
        }

        // 3 Parameters

        [Obsolete("", true)]
        [UsedImplicitly]
        public DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, long arg3)
        {
            arg1 = 11;
            if (arg2 != 12) throw new NotEqualException(() => arg2, 12);
            if (arg3 != 13) throw new NotEqualException(() => arg3, 13);
            return ParseHelper.ParseDateTime("2014-01-01");
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            if (arg1 != false) throw new NotEqualException(() => arg1, false);
            arg2 = 15;
            if (arg3 != 16) throw new NotEqualException(() => arg3, 16);
            return 17;
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public float InstanceMethod_WithThreeParameters(out double arg1, out DateTime arg2, TimeSpan arg3)
        {
            arg1 = 18;
            arg2 = ParseHelper.ParseDateTime("2019-01-01");
            if (arg3 != ParseHelper.ParseTimeSpan("00:20")) throw new NotEqualException(() => arg3, () => ParseHelper.ParseTimeSpan("00:20"));
            return 21;
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public string InstanceMethod_WithThreeParameters(Guid arg1, string arg2, out TimeSpan arg3)
        {
            if (arg1 != new Guid("00000000-0000-0000-0000-000000000022")) throw new NotEqualException(() => arg1, new Guid("00000000-0000-0000-0000-000000000022"));
            if (!string.Equals(arg2, "23")) throw new NotEqualException(() => arg2, "23");
            arg3 = ParseHelper.ParseTimeSpan("00:24");
            return "25";
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, out long arg3)
        {
            arg1 = 26;
            if (arg2 != 27) throw new NotEqualException(() => arg2, 27);
            arg3 = 28;
            return ParseHelper.ParseDateTime("2029-01-01");
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, out long arg3)
        {
            if (arg1 != true) throw new NotEqualException(() => arg1, true);
            arg2 = 30;
            arg3 = 31;
            return 32;
        }

        [Obsolete("", true)]
        [UsedImplicitly]
        public float InstanceMethod_WithThreeParameters(out double arg1, out DateTime arg2, out TimeSpan arg3)
        {
            arg1 = 33;
            arg2 = ParseHelper.ParseDateTime("2034-01-01");
            arg3 = ParseHelper.ParseTimeSpan("00:35");
            return 36;
        }
    }
}
