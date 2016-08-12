using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Analysis.Names
{
    internal static class DiagnosticsIDs
    {
        public const string FieldNamesAreUnderscoredCamelCase = "FieldNamesStartWithUnderscore";
        public const string FieldNameAbbreviationCasing = "FieldNameAbbreviationCasing";
        public const string MethodNameAbbreviationCasing = "MethodNameAbbreviationCasing";
        public const string MethodNamesStartWithUpperCase = "MethodNamesStartWithUpperCase";
        public const string PropertyNamesStartWithUpperCase = "PropertyNamesStartWithUpperCase";
        public const string PropertyNameAbbreviationCasing = "PropertyNameAbbreviationCasing";
        public const string PublicMethodParameterRequiresNullCheck = "PublicMethodParameterRequiresNullCheck";
        public const string TypeNameAbreviationCasing = "TypeNameAbreviationCasing";
        public const string TypeNamesStartWithUpperCase = "TypeNamesStartWithUpperCase";
    }
}
