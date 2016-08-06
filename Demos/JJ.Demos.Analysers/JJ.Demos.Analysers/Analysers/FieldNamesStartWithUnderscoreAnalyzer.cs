using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JJ.Demos.Analysers.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Demos.Analysers.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FieldNamesStartWithUnderscoreAnalyzer : DiagnosticAnalyzer
    {
        private static DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.FieldNamesStartWithUnderscore,
            title: DiagnosticsIDs.FieldNamesStartWithUnderscore,
            messageFormat: "Field name '{0}' does not start with underscore.",
            category: CategoryNames.Naming,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

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
