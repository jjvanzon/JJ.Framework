using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class MixinNode : NodeBase
    {
        public MixinNode(PresentationMixin mixin)
            : base(mixin.TypeName)
        {
            this.mixin = mixin;

            this.ImageIndex = 5;
            this.SelectedImageIndex = 5;
        }

        private PresentationMixin mixin;
        public virtual PresentationMixin Mixin
        {
            get { return mixin; }
            set { mixin = value; }
        }

        public override object Object
        {
            get { return this.mixin; }
        }

        public override void Refresh()
        {
            this.Text = mixin.TypeName;

            base.Refresh();
        }
    }
}
