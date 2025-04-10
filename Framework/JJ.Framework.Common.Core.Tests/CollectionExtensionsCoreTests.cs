using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class CollectionExtensionsCoreTests
{
    [TestMethod]
    public void CollectionExtensions_ForEach_Core_Test()
    {
        List<int> list = new List<int> { 1, 2, 3 };
        IEnumerable<int> enumerable = list;

        int sum1 = 0;
        list.ForEach(x => sum1 += x);

        int sum2 = 0;
        enumerable.ForEach(x => sum2 += x);
        
        AreEqual(6, () => sum1);
        AreEqual(6, () => sum2);
    }

    [TestMethod]
    public void CollectionExtensions_ForEach_Exceptions_Core_Test()
    {
        {
            IEnumerable<int> enumerable = null;
            ThrowsExceptionContaining(() => enumerable.ForEach(x => x++), "Cannot be null", "enumerable");
        }
        {
            IEnumerable<int> enumerable = [ 1, 2, 3 ];
            ThrowsExceptionContaining(() => enumerable.ForEach(null), "Cannot be null", "action");
        }
    }
}