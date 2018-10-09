using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class InterceptorProperties
    {
        public InterceptorProperties(PresentationInterceptor interceptor)
        {
            this.interceptor = interceptor;
        }

        private PresentationInterceptor interceptor = null;

        public PresentationInterceptor GetInterceptor()
        {
            return interceptor;
        }

        public string Type
        {
            get { return interceptor.TypeName; }
            set { interceptor.TypeName = value; }
        }
    }
}
