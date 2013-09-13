using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Visualization.Sorting;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class AssemblyNode : NodeBase
    {
        public AssemblyNode(Assembly assembly, PresentationModel model, AspectMatcher aspectMatcher, PointcutMatcher pointcutMatcher)
            : base(assembly.GetName().Name)
        {
            this.Assembly = assembly;

            ArrayList types = new ArrayList(assembly.GetTypes());
            types.Sort(new TypeComparer());
            foreach (Type type in types)
            {
                if (type.IsClass)
                {
                    TreeNode node = new TypeNode(type, model, aspectMatcher, pointcutMatcher);
                    this.Nodes.Add(node);
                }
            }
        }

        private Assembly assembly;
        public virtual Assembly Assembly
        {
            get { return assembly; }
            set { assembly = value; }
        }

        public override object Object
        {
            get { return this.assembly; }
        }

    }
}
