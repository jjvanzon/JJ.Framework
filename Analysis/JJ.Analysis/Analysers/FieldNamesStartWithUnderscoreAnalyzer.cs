using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FieldNamesStartWithUnderscoreAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.FieldNamesStartWithUnderscore,
            title: DiagnosticsIDs.FieldNamesStartWithUnderscore,
            messageFormat: "Field name '{0}' does not start with underscore.",
            category: CategoryNames.Naming,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Field);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var castedSymbol = (IFieldSymbol)context.Symbol;

            if (castedSymbol.Name.StartsWith("_"))
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], castedSymbol.Name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
