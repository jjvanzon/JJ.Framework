//using System;
//using System.Collections.Generic;
//using System.Collections.Immutable;
//using JJ.Framework.CodeAnalysis.Helpers;
//using JJ.Framework.CodeAnalysis.Names;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.Diagnostics;

//namespace JJ.Framework.CodeAnalysis.Analysers
//{
//	[DiagnosticAnalyzer(LanguageNames.CSharp)]
//	public class PublicMethodParameter_RequiresStringIsNullOrEmptyCheck_Analyzer : DiagnosticAnalyzer
//	{
//		private static readonly DiagnosticDescriptor _rule = new DiagnosticDescriptor(
//			DiagnosticsIDs.PropertyNamesStartWithUpperCase,
//			DiagnosticsIDs.PropertyNamesStartWithUpperCase,
//			"Property name '{0}' does not start with an upper case letter.",
//			CategoryNames.Naming,
//			DiagnosticSeverity.Hidden,
//			isEnabledByDefault: true);

//		private static readonly ImmutableArray<DiagnosticDescriptor> _supportedDiagnostics = ImmutableArray.Create(_rule);

//		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => _supportedDiagnostics;

//		public override void Initialize(AnalysisContext context)
//		{
//			context.RegisterSymbolAction(AnalyzeSymbol, SymbolKind.Property);
//		}

//		private static void AnalyzeSymbol(SymbolAnalysisContext context)
//		{
//			string name = context.Symbol.Name;

//			if (StringHelper.StartsWithUpperCase(name))
//			{
//				return;
//			}

//			Diagnostic diagnostic = Diagnostic.Create(_rule, context.Symbol.Locations[0], name);
//			context.ReportDiagnostic(diagnostic);
//		}
//	}
//}
