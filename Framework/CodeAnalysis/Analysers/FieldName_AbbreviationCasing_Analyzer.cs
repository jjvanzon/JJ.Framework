using System.Collections.Immutable;
using JJ.Framework.CodeAnalysis.Helpers;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FieldName_AbbreviationCasing_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.FieldNameAbbreviationCasing,
            DiagnosticsIDs.FieldNameAbbreviationCasing,
            "Field name '{0}': Field names should be underscored camel case. " + AnalysisHelper.ABBREVIATION_CASING_EXPLANATION,
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
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

            if (castedSymbol.IsConst)
            {
                return;
            }

            string name = castedSymbol.Name;

            if (CaseHelper.ExceedsMaxCapitalizedAbbreviationLength(name, 2))
            {
                Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
