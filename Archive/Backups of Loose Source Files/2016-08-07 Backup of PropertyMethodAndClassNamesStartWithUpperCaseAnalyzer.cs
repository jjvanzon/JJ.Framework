//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using JJ.Analysis.Names;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace JJ.Analysis.Analysers
//{
//    [DiagnosticAnalyzer(LanguageNames.CSharp)]
//    public class PropertyMethodAndClassNamesStartWithUpperCaseAnalyzer : DiagnosticAnalyzer
//    {
//        private static DiagnosticDescriptor _rule = new DiagnosticDescriptor(
//            DiagnosticsIDs.PropertyMethodAndClassNamesStartWithUpperCase,
//            title: DiagnosticsIDs.PropertyMethodAndClassNamesStartWithUpperCase,
//            messageFormat: "Member name '{0}' does not start with an upper case letter.",
//            category: CategoryNames.Naming,
//            defaultSeverity: DiagnosticSeverity.Warning,
//            isEnabledByDefault: true);

//        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(_rule);

//        public override void Initialize(AnalysisContext context)
//        {
//            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Property, SymbolKind.Method, SymbolKind.NamedType);
//        }

//        private static void AnalyzeSymbol(SymbolAnalysisContext context)
//        {
//            string name = context.Symbol.Name;

//            Microsoft.CodeAnalysis.IMethodSymbol
//            SourcePropertyAccessorSymbol

//            if (String.IsNullOrEmpty(name))
//            {
//                return;
//            }

//            char firstChar = name[0];
//            char firstCharToUpper = firstChar.ToString().ToUpper()[0];

//            if (firstChar == firstCharToUpper)
//            {
//                return;
//            }

//            Diagnostic diagnostic = Diagnostic.Create(_rule, context.Symbol.Locations[0], name);
//            context.ReportDiagnostic(diagnostic);
//        }
//    }
//}
