using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.ExpressionHelperTests
{
	[DebuggerDisplay("Item {Name} [{Index}]")]
	internal class Item : IItem
	{
		public string Name { get; set; }
		public int Index { get; set; }

		public Item Parent { get; set; }

		public int _field;

		public int Property { get; set; }

		[IndexerName("Indexer")]
		public string this[int index] => "IndexerResult";

		public string MethodWithoutParameter() => "MethodWithoutParameterResult";

		public string MethodWithParameter(int parameter) => "MethodWithParameterResult";

		public string MethodWithParams(params int[] array) => "MethodWithParamsResult";
	}
}