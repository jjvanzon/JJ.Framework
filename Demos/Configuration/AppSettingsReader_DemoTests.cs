using JJ.Framework.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeModifiers

namespace JJ.Demos.Configuration
{
    [TestClass]
    public class AppSettingsReader_DemoTests
    {
        [TestMethod]
        public void Demo_AppSettingsReader()
        {
            int value = AppSettingsReader<IMySettings>.Get(x => x.MySetting);
            Assert.AreEqual(20, value);
        }
    }

    interface IMySettings
    {
        int MySetting { get; }
    }
}
