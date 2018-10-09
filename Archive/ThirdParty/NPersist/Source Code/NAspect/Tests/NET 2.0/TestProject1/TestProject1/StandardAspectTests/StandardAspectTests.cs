using System;
using System.Collections;
using System.Collections.Generic;
using KumoUnitTests.Interceptors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using TestProject1.Aspects;
using Puzzle.NAspect.Standard;

namespace KumoUnitTests
{
    [TestClass()]
    public class StandardAspectTests
    {
        [TestMethod()]
        public void DirtyTrackingTest()
        {
            Engine c = new Engine("DirtyTrackingTest");
            c.Configuration.Aspects.Add(new DirtyTrackedAspect());

            DirtyTrackedClass d = c.CreateProxy<DirtyTrackedClass>();


            IDirtyTracked dt = d as IDirtyTracked;
            Assert.IsFalse(dt.IsDirty, "object was dirty");
            d.SomeProp = "Hello";
            Assert.IsTrue(dt.IsDirty, "object not was dirty");

            Assert.IsTrue(dt.GetPropertyDirtyStatus("SomeProp"),"SomeProp was not dirty");
            dt.ClearDirty();

            Assert.IsFalse(dt.GetPropertyDirtyStatus("SomeProp"), "SomeProp was dirty");
        }

        public void LogTest()
        {
            Engine c = new Engine("LogTest");
            LogTarget t = c.CreateProxy<LogTarget>();
            t.MyLoggedMethod(123, "abc", 456.678);
            
        }
    }
}
