using System.Diagnostics;
using System.Runtime.CompilerServices;
// ReSharper disable InconsistentNaming
// ReSharper disable UnassignedField.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace JJ.Framework.Reflection.PerformanceTests.Items
{
	[DebuggerDisplay("Item {Name} [{Index}]")]
	public class Item //: IItem
	{
		public string Name;
		public int Index;

		public Item Parent;

		public int Field;
		public int Property { get; set; }

		[IndexerName("Indexer")]
		public string this[int index] => "IndexerResult";

		public string Method(int parameter) => "MethodResult";

		public string MethodWithParams(params int[] array) => "MethodWithParamsResult";
	}
}
