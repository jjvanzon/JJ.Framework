using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Configuration.Tests
{
    [TestClass]
    public class AppSettingsTest
    {
        [TestMethod]
        public void Test_AppSettings()
        {
            int value = AppSettings<IMySettings>.Get(x => x.MySetting);
        }
    }
}
