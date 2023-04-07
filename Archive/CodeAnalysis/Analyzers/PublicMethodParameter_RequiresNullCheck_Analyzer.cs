using System;
using System.Collections.Immutable;
using System.Linq;
using JetBrains.Annotations;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

// ReSharper disable HeuristicUnreachableCode

namespace JJ.Framework.CodeAnalysis.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    [UsedImplicitly]
    public class PublicMethodParameter_RequiresNullCheck_Analyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
            "Parameter '{0}' requires checking for null.",
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
            true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
            => context.RegisterSyntaxNodeAction(AnalyzeSyntax, SyntaxKind.MethodDeclaration);

        private static void AnalyzeSyntax(SyntaxNodeAnalysisContext context)
        {
            var baseMethodDeclarationSyntax = (BaseMethodDeclarationSyntax)context.Node;

            if (!IsApplicableType(baseMethodDeclarationSyntax))
            {
                return;
            }

            if (!HasApplicableAccessLevel(baseMethodDeclarationSyntax))
            {
                return;
            }

            foreach (ParameterSyntax parameterSyntax in baseMethodDeclarationSyntax.ParameterList.Parameters)
            {
                AnalyzeParameter(context, parameterSyntax);
            }
        }

        private static bool IsApplicableType(BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            switch (baseMethodDeclarationSyntax)
            {
                case MethodDeclarationSyntax _:
                case ConstructorDeclarationSyntax _:
                    return true;

                // TODO: Contemplate whether we need to handle more types,
                // or if BaseMethodDeclarationSyntax could ever be of a non-applicable type at all.

                default:
                    return false;
            }
        }

        private static bool HasApplicableAccessLevel(BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            // TODO: Maybe this could be done faster.
            bool isPrivate = baseMethodDeclarationSyntax.ChildTokens().Any(x => x.IsKind(SyntaxKind.PrivateKeyword));

            if (isPrivate)
            {
                return false;
            }

            return true;
        }

        private static void AnalyzeParameter(SyntaxNodeAnalysisContext context, ParameterSyntax parameterSyntax)
        {
            if (!HasApplicableType(context, parameterSyntax))
            {
                return;
            }

            // TODO: Check if it parameter is referenced and members of it are accessed.
            // TODO: Check if parameter has some sort of null comparison before it is accessed.
            // or otherwise passes it to another method that asserts the value for it.

            return;
            throw new NotImplementedException();

            Diagnostic diagnostic = Diagnostic.Create(_rule, parameterSyntax.GetLocation(), parameterSyntax.Identifier);
            context.ReportDiagnostic(diagnostic);
        }

        private static bool HasApplicableType(
            SyntaxNodeAnalysisContext context,
            ParameterSyntax parameterSyntax)
        {
            IParameterSymbol parameterSymbol = context.SemanticModel.GetDeclaredSymbol(parameterSyntax);
            ITypeSymbol parameterTypeSymbol = parameterSymbol.Type;

            if (!parameterTypeSymbol.IsReferenceType)
            {
                return false;
            }

            bool isString = IsString(parameterTypeSymbol);

            if (isString)
            {
                return false;
            }

            return true;
        }

        private static bool IsString(ITypeSymbol typeSymbol)
        {
            if (!(typeSymbol is INamedTypeSymbol namedTypeSymbol))
            {
                return false;
            }

            // TODO: I feel strange about this. How canonical is this name? What if I declare a type String of my own?
            if (string.Equals(namedTypeSymbol.MetadataName, "String"))
            {
                return true;
            }

            return false;
        }
    }
}