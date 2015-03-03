using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Resources
{
    public static class CommonTitlesFormatter
    {
        public static string EntityCount(string entityNamePlural)
        {
            return String.Format(CommonTitles.EntityCount, entityNamePlural);
        }
    }
}
