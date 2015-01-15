using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation
{
    public sealed class ActionDescriptor
    {
        public string PresenterName { get; set; }
        public string ActionName { get; set; }
        public IList<ParameterDescriptor> Parameters { get; set; }
    }
}
