using System;
using System.Collections.Immutable;
using System.Linq;
using JJ.Analysis.Helpers;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TypeName_AbbreviationCasing_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.TypeNameAbreviationCasing,
            DiagnosticsIDs.TypeNameAbreviationCasing,
            "Type name '{0}': Type names should be pascal case. " + AnalysisHelper.ABBREVIATION_CASING_EXPLANATION,
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

            // TODO: Any other way to detect, that it is an interface?
            int firstIndex = 0;
            if (name.StartsWith("I"))
            {
                firstIndex = 1;
            }

            if (CaseHelper.ExceedsMaxCapitalizedAbbreviationLength(name, 2, firstIndex))
            {
                Diagnostic diagnostic = Diagnostic.Create(_rule, context.Symbol.Locations[0], name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
