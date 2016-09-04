//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using System.Linq;
//using JJ.Analysis.Helpers;
//using JJ.Analysis.Names;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace JJ.Analysis.Analysers
//{
//    [DiagnosticAnalyzer(LanguageNames.CSharp)]
//    public class ConstantNames_AreUpperCaseOrSameAsValue_Analyzer : DiagnosticAnalyzer
//    {
//        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
//            DiagnosticsIDs.ConstantNamesAreUpperCaseOrSameAsValue,
//            DiagnosticsIDs.ConstantNamesAreUpperCaseOrSameAsValue,
//            "Constant name '{0}' is not all capitals and or exactly equal to its value.",
//            CategoryNames.Naming,
//            DiagnosticSeverity.Warning,
//            isEnabledByDefault: true);

//        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

//        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

//        public override void Initialize(AnalysisContext context)
//        {
//            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.ConstKeyword);
//        }

//        public const string Naming = "Naming";

//        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
//        {
//            VariableDeclaratorSyntax variableDeclaratorSyntax = context.Node.Parent.DescendantNodes()
//                                                                       .OfType<VariableDeclaratorSyntax>()
//                                                                       .First();

//            SyntaxToken identifierSyntaxToken = variableDeclaratorSyntax.DescendantNodes()
//                                                                        .OfType<SyntaxToken>()
//                                                                        .Where(x => x.Kind() == SyntaxKind.IdentifierToken)
//                                                                        .First();


//            SyntaxToken stringLiteralSyntaxToken = variableDeclaratorSyntax.DescendantNodes()
//                                                                           .OfType<SyntaxToken>()
//                                                                           .Where(x => x.Kind() == SyntaxKind.StringLiteralToken)
//                                                                           .First();
//            string name = identifierSyntaxToken.Text;
//            string value = stringLiteralSyntaxToken.Text;

//            bool valueEqualsName = String.Equals(value, name);
//            if (valueEqualsName)
//            {
//                return;
//            }

//            bool isUpperCase = String.Equals(name, name.ToUpper());
//            if (isUpperCase)
//            {
//                return;
//            }

//            Diagnostic diagnostic = Diagnostic.Create(_rule, context.Node.GetLocation(), name);
//            context.ReportDiagnostic(diagnostic);
//        }
//    }
//}
