using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class PointcutTargetNode : NodeBase
    {
        public PointcutTargetNode(PointcutTarget target)
            : base(target.Signature)
        {
            this.target = target;
            this.ImageIndex = 8;
            this.SelectedImageIndex = 8;
        }

        private PointcutTarget target;
        public virtual PointcutTarget Target
        {
            get { return target; }
            set { target = value; }
        }

        public override object Object
        {
            get { return this.target ; }
        }

    }
}
