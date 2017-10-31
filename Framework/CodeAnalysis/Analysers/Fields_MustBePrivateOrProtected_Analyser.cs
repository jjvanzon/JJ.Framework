using System;
using System.Collections.Immutable;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class Fields_MustBePrivateOrProtected_Analyser : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.FieldsMustBePrivateOrProtected,
            DiagnosticsIDs.FieldsMustBePrivateOrProtected,
            "Fields must be private or protected. Or use a property instead. (Field name: '{0}')",
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

            if (AccessModifierIsAllowed(castedSymbol.DeclaredAccessibility))
            {
                return;
            }

            Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], castedSymbol.Name);
            context.ReportDiagnostic(diagnostic);
        }

        private static bool AccessModifierIsAllowed(Accessibility accessibility)
        {
            switch (accessibility)
            {
                case Accessibility.Private:
                case Accessibility.Protected:
                    return true;

                case Accessibility.Internal:
                case Accessibility.Public:
                case Accessibility.ProtectedOrInternal:
                    return false;

                default:
                    throw new Exception(string.Format("{0} {1} is not supported.", nameof(Accessibility), accessibility));
            }
        }
    }
}
