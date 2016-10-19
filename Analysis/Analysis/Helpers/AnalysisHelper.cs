using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace JJ.Analysis.Helpers
{
    internal static class AnalysisHelper
    {
        public const string ABBREVIATION_CASING_EXPLANATION =
            "Abbreviations with 2 letters should be in capitals, " +
            "abbreviations with 3 letters or more should only start with a capital.";

        public static bool IsNormalMethod(IMethodSymbol methodSymbol)
        {
            switch (methodSymbol.MethodKind)
            {
                case MethodKind.DeclareMethod:
                case MethodKind.Ordinary:
                case MethodKind.ReducedExtension:
                    return true;
            }

            return false;
        }
    }
}
