using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Mathematics.Tests
{
	[TestClass]
	public class TextPlotterTests
    {
        [TestMethod]
        public void Debug_TextPlotter()
        {
            IList<string> plot = TextPlotter.Plot(new[] { 0.0, 0.7, 1.0, 0.7, 0.0, -0.7, -1.0, -0.7, 0.0 }, columnCount: 10, lineCount: 7);
        }
	}
}
