//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using JJ.Analysis.Helpers;
//using JJ.Analysis.Names;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace JJ.Analysis.Analysers
//{
//    [DiagnosticAnalyzer(LanguageNames.CSharp)]
//    public class PublicMethodParameterRequiresNullCheckAnalyzer : DiagnosticAnalyzer
//    {
//        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
//            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
//            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
//            "Parameter '{0}' requires checking for null.",
//            CategoryNames.Naming,
//            DiagnosticSeverity.Warning,
//            isEnabledByDefault: true);

//        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

//        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

//        public override void Initialize(AnalysisContext context)
//        {
//            context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
//        }

//        private static void AnalyzeSymbol(SymbolAnalysisContext context)
//        {
//            var methodSymbol = (IMethodSymbol)context.Symbol;

//            if (!IsApplicableMethodKind(methodSymbol.MethodKind))
//            {
//                return;
//            }

//            if (!HasApplicableAccessLevel(methodSymbol))
//            {
//                return;
//            }

//            foreach (IParameterSymbol parameterSymbol in methodSymbol.Parameters)
//            {
//                AnalyseParameter(context, methodSymbol, parameterSymbol);
//            }
//        }

//        private static void AnalyseParameter(
//            SymbolAnalysisContext context,
//            IMethodSymbol methodSymbol,
//            IParameterSymbol parameterSymbol)
//        {
//            if (!HasApplicableParameterType(parameterSymbol))
//            {
//                return;
//            }

//            // TODO: Check if it parameter is referenced and members of it are acessed.
//            // TODO: Check if parameter has some sort of null comparison before it is accessed.

//            return;
//            throw new NotImplementedException();

//            Diagnostic diagnostic = Diagnostic.Create(_rule, parameterSymbol.Locations[0], parameterSymbol.Name);
//            context.ReportDiagnostic(diagnostic);
//        }

//        private static bool IsApplicableMethodKind(MethodKind methodKind)
//        {
//            switch (methodKind)
//            {
//                case MethodKind.Constructor:
//                case MethodKind.Conversion:
//                case MethodKind.DeclareMethod:
//                case MethodKind.Ordinary:
//                case MethodKind.ReducedExtension:
//                    // TODO: I suspect I forgot a few.
//                    return true;
//            }

//            return false;
//        }

//        private static bool HasApplicableAccessLevel(IMethodSymbol methodSymbol)
//        {
//            switch (methodSymbol.DeclaredAccessibility)
//            {
//                case Accessibility.Private:
//                    return false;

//                case Accessibility.Internal:
//                case Accessibility.Protected:
//                case Accessibility.ProtectedAndInternal:
//                case Accessibility.ProtectedOrInternal:
//                case Accessibility.Public:
//                    return true;

//                default:
//                    throw new Exception(String.Format(
//                        "methodSymbol.DeclaredAccessibility '{0}' not supported.",
//                        methodSymbol.DeclaredAccessibility));
//            }
//        }

//        private static bool HasApplicableParameterType(IParameterSymbol parameterSymbol)
//        {
//            ITypeSymbol parameterType = parameterSymbol.Type;

//            //bool parameterIsApplicableType = parameterType.IsReferenceType &&
//            //                                 parameterType.Name

//            return false;
//            throw new NotImplementedException();
//        }
//    }
//}
