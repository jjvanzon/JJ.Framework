using static JJ.Framework.Reflection.Tests.Helpers.ParseHelper;

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
            AreEqual(2f, arg1, nameof(arg1));
            arg1 = 3;
            AreEqual(4d, () => arg2);
            return 5;
        }

        private DateTime InstanceMethod_WithTwoParameters(TimeSpan arg1, out string arg2)
        {
            AreEqual(ParseTimeSpan("00:06"), () => arg1);
            arg2 = "7";
            return ParseDateTime("2008-01-01");
        }

        private Guid InstanceMethod_WithTwoParameters(ref string arg1, out TimeSpan arg2)
        {
            AreEqual("9", arg1, nameof(arg1));
            arg1 = "10";
            arg2 = ParseTimeSpan("00:11");
            return new Guid("00000000-0000-0000-0000-000000000012");
        }

        // 3 Parameters

        private DateTime InstanceMethod_WithThreeParameters(ref double arg1, float arg2, long arg3)
        {
            AreEqual(13d, arg1, nameof(arg1));
            arg1 = 14;
            AreEqual(15f, () => arg2);
            AreEqual(16, () => arg3);
            return ParseDateTime("2017-01-01");
        }

        private int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 18;
            AreEqual(19, () => arg3);
            return 20;
        }

        private float InstanceMethod_WithThreeParameters(ref double arg1, out DateTime arg2, TimeSpan arg3)
        {
            AreEqual(21d, arg1, nameof(arg1));
            arg1 = 22;
            arg2 = ParseDateTime("2023-01-01");
            AreEqual(ParseTimeSpan("00:24"), () => arg3);
            return 25;
        }

        private string InstanceMethod_WithThreeParameters(Guid arg1, string arg2, ref TimeSpan arg3)
        {
            AreEqual(new Guid("00000000-0000-0000-0000-000000000026"), () => arg1);
            AreEqual("27", () => arg2);
            AreEqual(ParseTimeSpan("00:28"), arg3, nameof(arg3));
            arg3 = ParseTimeSpan("00:29");
            return "30";
        }

        private DateTime InstanceMethod_WithThreeParameters(out double arg1, float arg2, ref long arg3)
        {
            arg1 = 31;
            AreEqual(32f, () => arg2);
            AreEqual(33l, arg3, nameof(arg3));
            arg3 = 34;
            return ParseDateTime("2035-01-01");
        }

        private int InstanceMethod_WithThreeParameters(bool arg1, out int arg2, ref long arg3)
        {
            IsTrue(() => arg1);
            arg2 = 36;
            AreEqual(37l, arg3, nameof(arg3));
            arg3 = 38;
            return 39;
        }

        private float InstanceMethod_WithThreeParameters(out double arg1, ref DateTime arg2, out TimeSpan arg3)
        {
            arg1 = 40;
            AreEqual(ParseDateTime("2041-01-01"), arg2, nameof(arg2));
            arg2 = ParseDateTime("2042-01-01");
            arg3 = ParseTimeSpan("00:43");
            return 44;
        }

        // Misc

        private void InstanceMethod_WithReturnTypeVoid(ref DateTime arg)
        {
            AreEqual(ParseDateTime("2045-01-01"), arg, nameof(arg));
            arg = ParseDateTime("2046-01-01");
        }
    }
}
