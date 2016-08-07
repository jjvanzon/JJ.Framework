using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace JJ.Analysis.Helpers
{
    internal static class AnalysisHelper
    {
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
