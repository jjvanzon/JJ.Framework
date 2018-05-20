using JJ.Framework.Configuration.Tests.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable

namespace JJ.Framework.Configuration.Tests
{
	[TestClass]
	public class AppSettingsTest
	{
		[TestMethod]
		public void Test_AppSettings()
		{
			int value = AppSettingsReader<IMySettings>.Get(x => x.MySetting);
		}
	}
}
