using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation
{
    public sealed class ActionInfo
    {
        public string PresenterName { get; set; }
        public string ActionName { get; set; }
        public IList<ActionParameterInfo> Parameters { get; set; }
    }
}
