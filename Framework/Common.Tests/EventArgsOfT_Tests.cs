using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EventArgsOfT_Tests 
    {

        [TestMethod]
        public void Test_EventArgsOfT()
        {
            EventArgs<int> eventArgs = new EventArgs<int>(123);
            AssertHelper.AreEqual(123, () => eventArgs.Value);
            AssertHelper.IsInstanceOfType(() => eventArgs, typeof(EventArgs));
        }
    }
}
