using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Items
{
    [DebuggerDisplay("Item {Name} [{Index}] = {Value}")]
    public class Item //: IItem
    {
        public string Name;
        public int Index;

        public Item Parent;

        public int Field;
        public int Property { get; set; }

        [IndexerName("Indexer")]
        public string this[int index]
        {
            get { return "IndexerResult"; }
        }

        public string Method(int parameter)
        {
            return "MethodResult";
        }

        public string MethodWithParams(params int[] array)
        {
            return "MethodWithParamsResult";
        }
    }
}
