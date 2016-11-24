using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class NodeBase : TreeNode
    {
        public NodeBase(string text)
            : base(text)
        { 
            ;
        }

        public virtual void Refresh()
        {
            foreach (NodeBase node in this.Nodes)
                node.Refresh();
        }
            
        public virtual object Object
        {
            get { return null; }
        }
    }
}
