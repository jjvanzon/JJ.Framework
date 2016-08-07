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
    public class PublicMethodParameterRequiresNullCheckAnalyzer : DiagnosticAnalyzer
    {
        public PublicMethodParameterRequiresNullCheckAnalyzer()
        {

        }

        private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
            DiagnosticsIDs.PublicMethodParameterRequiresNullCheck,
            "Parameter '{0}' requires checking for null.",
            CategoryNames.Naming,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSyntax, SyntaxKind.MethodDeclaration);
        }

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
                AnalyseParameter(context, baseMethodDeclarationSyntax, parameterSyntax);
            }
        }

        private static bool IsApplicableType(BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            if (baseMethodDeclarationSyntax is MethodDeclarationSyntax)
            {
                return true;
            }

            if (baseMethodDeclarationSyntax is ConstructorDeclarationSyntax)
            {
                return true;
            }

            // TODO: Contemplate whether we need to handle more types,
            // or if BaseMethodDeclarationSyntax could ever be of a non-applicable type at all.

            return false;
        }

        private static bool HasApplicableAccessLevel(BaseMethodDeclarationSyntax baseMethodDeclarationSyntax)
        {
            // TODO: Maybe this could be done faster.
            bool isPrivate = baseMethodDeclarationSyntax.ChildTokens()
                                                        .Where(x => x.IsKind(SyntaxKind.PrivateKeyword))
                                                        .Any();
            if (isPrivate)
            {
                return false;
            }

            return true;
        }

        private static void AnalyseParameter(
            SyntaxNodeAnalysisContext context,
            BaseMethodDeclarationSyntax baseMethodDeclarationSyntax,
            ParameterSyntax parameterSyntax)
        {
            //throw new NotImplementedException();

            if (!HasApplicableParameterType(context, parameterSyntax))
            {
                return;
            }

            // TODO: Check if it parameter is referenced and members of it are acessed.
            // TODO: Check if parameter has some sort of null comparison before it is accessed.
            // or otherwise passes it to another method that asserts the value for it.

            return;
            throw new NotImplementedException();

            Diagnostic diagnostic = Diagnostic.Create(_rule, parameterSyntax.GetLocation(), parameterSyntax.Identifier);
            context.ReportDiagnostic(diagnostic);
        }

        private static bool HasApplicableParameterType(
            SyntaxNodeAnalysisContext context,
            ParameterSyntax parameterSyntax)
        {
            //ITypeSymbol parameterType = parameterSymbol.Type;
            //TypeSyntax typeSyntax = parameterSyntax.Type;

            IParameterSymbol parameterSymbol = context.SemanticModel.GetDeclaredSymbol(parameterSyntax);
            ITypeSymbol parameterTypeSymbol = parameterSymbol.Type;

            if (!parameterTypeSymbol.IsReferenceType)
            {
                return false;
            }

            //string parameterTypeName = parameterTypeSymbol.ToDisplayString();
            //string stringTypeName = typeof(string).AssemblyQualifiedName;

            // TODO: This is probably not going to work, or even the way to go.
            //bool isString = String.Equals(parameterTypeName, stringTypeName);

            bool isString = IsString(parameterTypeSymbol);
            if (isString)
            {
                return false;
            }

            //context.SemanticModel.Compilation.GetTypeByMetadataName(stringTypeName);
            //parameterTypeSymbol.
            //bool parameterIsApplicableType = parameterType.IsReferenceType &&
            //                                 parameterType.Name

            return false;
            throw new NotImplementedException();
        }

        private static bool IsString(ITypeSymbol typeSymbol)
        {
            var namedTypeSymbol = typeSymbol as INamedTypeSymbol;
            if (namedTypeSymbol == null)
            {
                return false;
            }

            if (String.Equals(namedTypeSymbol.MetadataName, "string"))
            {
                return true;
            }

            if (String.Equals(namedTypeSymbol.MetadataName, "String"))
            {
                return true;
            }

            if (String.Equals(namedTypeSymbol.MetadataName, "System.String"))
            {
                return true;
            }

            return false;
        }
    }
}
