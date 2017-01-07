using System.Collections.Immutable;
using JJ.Framework.CodeAnalysis.Helpers;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ParameterNames_AbbreviationCasing_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.ParameterNameAbbreviationCasing,
            DiagnosticsIDs.ParameterNameAbbreviationCasing,
            "Parameter name '{0}': Parameter names should be camel case. " + AnalysisHelper.ABBREVIATION_CASING_EXPLANATION,
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.Parameter);
        }

        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var castedSyntaxNode = (ParameterSyntax)context.Node;

            string name = castedSyntaxNode.Identifier.Text;

            if (CaseHelper.ExceedsMaxCapitalizedAbbreviationLength(name, 2))
            {
                Diagnostic diagnostic = Diagnostic.Create(_rule, castedSyntaxNode.GetLocation(), name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}