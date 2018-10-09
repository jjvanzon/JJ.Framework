using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class AspectTargetNode : NodeBase
    {
        public AspectTargetNode(AspectTarget target) : base(target.Signature)
        {
            this.target = target;
            this.ImageIndex = 8;
            this.SelectedImageIndex = 8;
        }

        private AspectTarget target;
        public virtual AspectTarget Target
        {
            get { return target; }
            set { target = value; }
        }

        public override object Object
        {
            get { return this.target; }
        }

        public override void Refresh()
        {
            this.Text = this.target.Signature;

            base.Refresh();
        }
    }
}
