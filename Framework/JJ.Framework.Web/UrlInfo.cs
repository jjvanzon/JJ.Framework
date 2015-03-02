using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Web
{
    public class UrlInfo
    {
        public string Protocol { get; set; }

        private IList<string> _pathElements = new List<string>();
        public IList<string> PathElements { get { return _pathElements; } }

        private IList<UrlParameterInfo> _parameters = new List<UrlParameterInfo>();
        public IList<UrlParameterInfo> Parameters { get { return _parameters; } }
    }
}