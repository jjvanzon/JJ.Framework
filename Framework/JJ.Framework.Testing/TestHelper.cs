﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Testing.Legacy
{
    internal class TestHelper
    {
        private const string TESTED_PROPERTY_MESSAGE = "Tested property: '{0}'.";

        public static string FormatTestedPropertyMessage(string propertyDescription)
        {
            return String.Format(TESTED_PROPERTY_MESSAGE, propertyDescription);
        }
    }
}
