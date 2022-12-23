using System;
using System.Collections.Generic;
using JJ.Framework.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable CS0162

namespace JJ.Demos.Data
{
    [TestClass]
    public class RepositorySqlExecutorDemoTests
    {
        [TestMethod]
        public void Demo_RepositorySqlExecutor()
        {
            // Postponing this
            return;

            IContext context = ContextFactory.CreateContextFromConfiguration();
            IMyRepository repository = new MyRepository(context);
            IList<MyEntity> entities = repository.GetManyByCriteria(10, 20, DateTime.Parse("2022-01-01"));
        }
    }
}
