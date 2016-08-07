using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JJ.Analysis.Helpers;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class MethodNamesStartWithUpperCaseAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.MethodNamesStartWithUpperCase,
            DiagnosticsIDs.MethodNamesStartWithUpperCase,
            "Method name '{0}' does not start with an upper case letter.",
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var methodSymbol = (IMethodSymbol)context.Symbol;

            if (!AnalysisHelper.IsNormalMethod(methodSymbol))
            {
                return;
            }

            string name = methodSymbol.Name;
            if (StringHelper.StartsWithUpperCase(name))
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, methodSymbol.Locations[0], name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
