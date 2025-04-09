using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Testing.Core
{
    internal static class TestHelperLegacy
    {
        private const string TESTED_PROPERTY_MESSAGE = "Tested member: '{0}'.";
        
        public static string FormatTestedPropertyMessage(string propertyDescription)
            => string.Format(TESTED_PROPERTY_MESSAGE, propertyDescription);
    }
}