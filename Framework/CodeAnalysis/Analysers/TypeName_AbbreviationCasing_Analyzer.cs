using System.Collections.Immutable;
using JJ.Framework.CodeAnalysis.Helpers;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
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
            var castedSymbol = (INamedTypeSymbol)context.Symbol;

            string name = castedSymbol.Name;

            int firstIndex = 0;
            if (castedSymbol.TypeKind == TypeKind.Interface)
            {
                firstIndex = 1;
            }

            if (CaseHelper.ExceedsMaxCapitalizedAbbreviationLength(name, 2, firstIndex))
            {
                foreach (Location location in castedSymbol.Locations)
                {
                    Diagnostic diagnostic = Diagnostic.Create(_rule, location, name);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
}
