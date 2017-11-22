using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Items
{
	[DebuggerDisplay("Item {Name} [{Index}] = {Value}")]
	public class ComplexItem
	{
		public string Name;
		public int Index;

		public string Field = "FieldResult";

		public ComplexItem Property
		{
			get { return new ComplexItem { Name = "PropertyResult" }; }
		}

		public ComplexItem Method(int parameter)
		{
			return new ComplexItem { Name = "MethodResult" };
		}

		public ComplexItem MethodWithParams(params int[] array)
		{
			return new ComplexItem { Name = "MethodWithParamsResult" };
		}

		[IndexerName("Indexer")]
		public ComplexItem this[int index]
		{
			get { return new ComplexItem { Name = "IndexerResult" }; }
		}
	}
}
