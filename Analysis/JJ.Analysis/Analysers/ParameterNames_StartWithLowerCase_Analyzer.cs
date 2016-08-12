using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using JJ.Analysis.Helpers;
using JJ.Analysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Analysis.Analysers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ParameterNames_StartWithLowerCase_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.ParameterNamesStartWithLowerCase,
            DiagnosticsIDs.ParameterNamesStartWithLowerCase,
            "Parameter name '{0}' does not start with a lower case letter.",
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

            if (!CaseHelper.StartsWithLowerCase(name))
            {
                Diagnostic diagnostic = Diagnostic.Create(_rule, castedSyntaxNode.GetLocation(), name);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}
