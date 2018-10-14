using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Framework.Interception;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class InterceptorNode : NodeBase
    {
        public InterceptorNode(PresentationInterceptor interceptor)
            : base(interceptor.TypeName)
        {
            this.interceptor = interceptor;

            this.ImageIndex = 7;
            this.SelectedImageIndex = 7;
        }

        private PresentationInterceptor interceptor;
        public virtual PresentationInterceptor Interceptor
        {
            get { return interceptor; }
            set { interceptor = value; }
        }

        public override object Object
        {
            get { return this.interceptor ; }
        }

        public override void Refresh()
        {
            this.Text = interceptor.TypeName;

            base.Refresh();
        }

    }
}
