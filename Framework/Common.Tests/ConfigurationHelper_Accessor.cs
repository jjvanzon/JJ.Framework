using System.Collections.Generic;
using JJ.Framework.Reflection;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.Common.Tests
{
    internal static class ConfigurationHelper_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(typeof(ConfigurationHelper));

        public static IDictionary<string, object> _sections => _accessor.GetFieldValue(() => _sections);
    }
}
