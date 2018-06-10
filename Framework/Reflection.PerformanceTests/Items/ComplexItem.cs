using System.Diagnostics;
using System.Runtime.CompilerServices;
// ReSharper disable InconsistentNaming

namespace JJ.Framework.Reflection.PerformanceTests.Items
{
	[DebuggerDisplay("Item {Name} [{Index}]")]
	public class ComplexItem
	{
		public string Name;
		public int Index;

		public string Field = "FieldResult";

		public ComplexItem Property => new ComplexItem { Name = "PropertyResult" };

        public ComplexItem Method(int parameter) => new ComplexItem { Name = "MethodResult" };

        public ComplexItem MethodWithParams(params int[] array) => new ComplexItem { Name = "MethodWithParamsResult" };

        [IndexerName("Indexer")]
		public ComplexItem this[int index] => new ComplexItem { Name = "IndexerResult" };
	}
}
