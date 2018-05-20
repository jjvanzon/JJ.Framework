using System.Collections.Generic;
using System.Runtime.CompilerServices;
// ReSharper disable UnusedMember.Local

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	internal class ClassWithNamedIndexer
	{
		private readonly Dictionary<int, int> _intDictionary = new Dictionary<int, int>();

		[IndexerName("Indexer")]
		private int this[int index]
		{
			get => _intDictionary[index];
			set => _intDictionary[index] = value;
		}
	}
}