//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using System.Linq;
//using System.Threading;
//using JJ.Demos.Analysers.Names;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace JJ.Demos.Analysers.Analysers
//{
//    [DiagnosticAnalyzer(LanguageNames.CSharp)]
//    public class FieldNameStartsWithUnderscoreAnalyzer : DiagnosticAnalyzer
//    {
//        private static DiagnosticDescriptor _rule = new DiagnosticDescriptor(
//            DiagnosticsIDs.FieldNameStartsWithUnderscore,
//            title: DiagnosticsIDs.FieldNameStartsWithUnderscore,
//            messageFormat: "Field name '{0}' does not start with underscore.",
//            category: CategoryNames.Naming,
//            defaultSeverity: DiagnosticSeverity.Warning,
//            isEnabledByDefault: true);

//        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

//        public override void Initialize(AnalysisContext context)
//        {
//            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Field);
//        }

//        private static void AnalyzeSymbol(SymbolAnalysisContext context)
//        {
//            var fieldSymbol = (IFieldSymbol)context.Symbol;

//            if (fieldSymbol.Name.StartsWith("_"))
//            {
//                return;
//            }

//            var diagnostic = Diagnostic.Create(_rule, fieldSymbol.Locations[0], fieldSymbol.Name);
//            context.ReportDiagnostic(diagnostic);
//        }
//    }
//}
