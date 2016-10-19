using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JJ.Analysis.Helpers;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TypeName_StartWithUpperCase_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.TypeNameStartWithUpperCase,
            DiagnosticsIDs.TypeNameStartWithUpperCase,
            "Type name '{0}' does not start with an upper case letter.",
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            string name = context.Symbol.Name;

            if (CaseHelper.StartsWithUpperCase(name))
            {
                return;
            }

            foreach (Location location in context.Symbol.Locations)
            {
                Diagnostic diagnostic = Diagnostic.Create(_rule, location, name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
