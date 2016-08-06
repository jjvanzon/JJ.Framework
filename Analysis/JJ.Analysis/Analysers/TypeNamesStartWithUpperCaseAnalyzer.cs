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
    public class TypeNamesStartWithUpperCaseAnalyzer : DiagnosticAnalyzer
    {
        private static DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.TypeNamesStartWithUpperCase,
            title: DiagnosticsIDs.TypeNamesStartWithUpperCase,
            messageFormat: "Type name '{0}' does not start with an upper case letter.",
            category: CategoryNames.Naming,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
        }

        private static void AnalyzeSymbol(SymbolAnalysisContext context)
        {
            string name = context.Symbol.Name;

            if (StringHelper.StartsWithUpperCase(name))
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, context.Symbol.Locations[0], name);
            context.ReportDiagnostic(diagnostic);
        }
    }
}
