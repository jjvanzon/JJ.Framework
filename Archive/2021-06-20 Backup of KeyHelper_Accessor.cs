using JJ.Framework.Reflection;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.Common.Tests
{
    internal static class KeyHelper_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(KeyHelper));

        public static string SEPARATOR => _accessor.GetFieldValue(() => SEPARATOR);
    }
}
