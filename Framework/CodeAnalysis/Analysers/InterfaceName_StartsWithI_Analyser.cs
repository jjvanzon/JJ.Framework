using System.Collections.Immutable;
using JetBrains.Annotations;
using JJ.Framework.CodeAnalysis.Names;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace JJ.Framework.CodeAnalysis.Analysers
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	[UsedImplicitly]
	public class InterfaceName_StartsWithI_Analyser : DiagnosticAnalyzer
	{
		private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
			DiagnosticsIDs.TypeNameAbreviationCasing,
			DiagnosticsIDs.TypeNameAbreviationCasing,
			"Interface name '{0}' does not start with I.",
			CategoryNames.Naming,
			DiagnosticSeverity.Warning,
			isEnabledByDefault: true);

		private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

		public override void Initialize(AnalysisContext context)
		{
			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.NamedType);
		}

		private static void AnalyzeSymbol(SymbolAnalysisContext context)
		{
			var castedSymbol = (INamedTypeSymbol)context.Symbol;

			if (castedSymbol.TypeKind != TypeKind.Interface)
			{
				return;
			}

			string name = castedSymbol.Name;

			if (name.StartsWith("I"))
			{
				return;
			}

			Diagnostic diagnostic = Diagnostic.Create(_rule, castedSymbol.Locations[0], name);
			context.ReportDiagnostic(diagnostic);
		}
	}
}
