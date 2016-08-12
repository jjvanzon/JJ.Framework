using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.Names
{
    internal static class DiagnosticsIDs
    {
        public const string FieldNamesAreUnderscoredCamelCase = "FieldNamesStartWithUnderscore";
        public const string FieldNameAbbreviationCasing = "FieldNameAbbreviationCasing";
        public const string PropertyNamesStartWithUpperCase = "PropertyNamesStartWithUpperCase";
        public const string PropertyNameAbbreviationCasing = "PropertyNameAbbreviationCasing";
        public const string TypeNamesStartWithUpperCase = "TypeNamesStartWithUpperCase";
        public const string MethodNameAbbreviationCasing = "MethodNameAbbreviationCasing";
        public const string MethodNamesStartWithUpperCase = "MethodNamesStartWithUpperCase";
        public const string PublicMethodParameterRequiresNullCheck = "PublicMethodParameterRequiresNullCheck";
    }
}
