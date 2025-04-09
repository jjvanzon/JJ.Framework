using System.Collections.Generic;
using JJ.Framework.Reflection;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.Common.Core.Tests
{
    internal static class ConfigurationHelper_Accessor_Core
    {
        private static readonly Accessor _accessor = new Accessor(typeof(ConfigurationHelper));

        public static IDictionary<Type, object> _sections => _accessor.GetFieldValue(() => _sections);
    }
}
