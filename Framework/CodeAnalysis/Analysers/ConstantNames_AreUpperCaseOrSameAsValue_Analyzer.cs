using System;
using System.Collections.Immutable;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ConstantNames_AreUpperCaseOrSameAsValue_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.ConstantNameUpperCaseOrSameAsValue,
            DiagnosticsIDs.ConstantNameUpperCaseOrSameAsValue,
            "Constant name '{0}' is not all capitals and also the name does not exactly match its value.",
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

            if (!castedSymbol.IsConst)
            {
                return;
            }

            string name = castedSymbol.Name;
            string value = Convert.ToString(castedSymbol.ConstantValue);

            bool valueEqualsName = string.Equals(value, name);
            if (valueEqualsName)
            {
                return;
            }

            bool isUpperCase = string.Equals(name, name.ToUpper());
            if (isUpperCase)
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
