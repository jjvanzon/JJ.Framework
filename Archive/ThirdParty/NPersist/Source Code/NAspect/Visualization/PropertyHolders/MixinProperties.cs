using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.PropertyHolders
{
    public class MixinProperties
    {
        public MixinProperties(PresentationMixin mixin)
        {
            this.mixin = mixin;
        }

        private PresentationMixin mixin = null;

        public PresentationMixin GetMixin()
        {
            return mixin;
        }

        public string Type
        {
            get { return mixin.TypeName; }
            set { mixin.TypeName = value; }
        }

    }
}
