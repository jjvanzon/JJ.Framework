using System.Collections.Immutable;
using JetBrains.Annotations;
using JJ.Framework.CodeAnalysis.Helpers;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	[UsedImplicitly]
	public class MethodName_AbbreviationCasing_Analyzer : DiagnosticAnalyzer
	{
		private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
			DiagnosticsIDs.MethodNameAbbreviationCasing,
			DiagnosticsIDs.MethodNameAbbreviationCasing,
			"Method name '{0}': Method names should be pascal case. " + AnalysisHelper.ABBREVIATION_CASING_EXPLANATION,
			CategoryNames.Naming,
			DiagnosticSeverity.Warning,
			isEnabledByDefault: true);

		private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

		public override void Initialize(AnalysisContext context)
		{
			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Method);
		}

		private static void AnalyzeSymbol(SymbolAnalysisContext context)
		{
			var methodSymbol = (IMethodSymbol)context.Symbol;

			if (!AnalysisHelper.IsNormalMethod(methodSymbol))
			{
				return;
			}

			string name = methodSymbol.Name;

			if (CaseHelper.ExceedsMaxCapitalizedAbbreviationLength(name, 2))
			{
				Diagnostic diagnostic = Diagnostic.Create(_rule, methodSymbol.Locations[0], name);
				context.ReportDiagnostic(diagnostic);
			}
		}
	}
}
