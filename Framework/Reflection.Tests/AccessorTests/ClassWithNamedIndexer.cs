using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class ClassWithNamedIndexer
    {
        private Dictionary<int, int> _intDictionary = new Dictionary<int, int>();

        [IndexerName("Indexer")]
        private int this[int index]
        {
            get { return _intDictionary[index]; }
            set { _intDictionary[index] = value; }
        }
    }
}
