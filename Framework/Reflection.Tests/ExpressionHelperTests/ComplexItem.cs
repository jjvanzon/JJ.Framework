using System.Diagnostics;
using System.Runtime.CompilerServices;
// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable 649

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
	[DebuggerDisplay("Item {Name} [{Index}]")]
	internal class ComplexItem
	{
		public string Name;
		public int Index;

		public string _field = "FieldResult";

		public ComplexItem Property => new ComplexItem { Name = "PropertyResult" };

		public ComplexItem MethodWithParameter(int parameter) => new ComplexItem { Name = "MethodWithParameterResult" };

		public ComplexItem MethodWithParams(params int[] array) => new ComplexItem { Name = "MethodWithParamsResult" };

		[IndexerName("Indexer")]
		public ComplexItem this[int index] => new ComplexItem { Name = "IndexerResult" };
	}
}
