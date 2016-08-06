using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class PropertyNamesStartWithUpperCaseAnalyzer : DiagnosticAnalyzer
    {
        private static DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.PropertyNamesStartWithUpperCase,
            title: DiagnosticsIDs.PropertyNamesStartWithUpperCase,
            messageFormat: "Property name '{0}' does not start with an upper case letter.",
            category: CategoryNames.Naming,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Property);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            var castedSymbol = (IPropertySymbol)context.Symbol;

            string name = castedSymbol.Name;

            if (String.IsNullOrEmpty(name))
            {
                return;
            }

            char firstChar = name[0];
            char firstCharToUpper = firstChar.ToString().ToUpper()[0];

            if (firstChar == firstCharToUpper)
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
