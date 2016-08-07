using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.Names
{
    internal static class DiagnosticsIDs
    {
        public const string FieldNamesStartWithUnderscore = "FieldNamesStartWithUnderscore";
        public const string PropertyNamesStartWithUpperCase = "PropertyNamesStartWithUpperCase";
        public const string TypeNamesStartWithUpperCase = "TypeNamesStartWithUpperCase";
        public const string MethodNamesStartWithUpperCase = "MethodNamesStartWithUpperCase";
        public const string PublicMethodParameterRequiresNullCheck = "PublicMethodParameterRequiresNullCheck";
    }
}
