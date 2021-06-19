using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EventArgsOfT_Tests 
    {

        [TestMethod]
        public void Test_EventArgsOfT()
        {
            var eventArgs = new EventArgs<int>(123);
            AssertHelper.IsOfType<EventArgs>(() => eventArgs);
            AssertHelper.AreEqual(123, () => eventArgs.Value);
        }
    }
}
