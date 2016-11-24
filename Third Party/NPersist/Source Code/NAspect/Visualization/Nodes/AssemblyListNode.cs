using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Visualization.Presentation;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Visualization.Sorting;
using System.Windows.Forms;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class AssemblyListNode : NodeBase 
    {
        public AssemblyListNode(IList assemblies, PresentationModel model, AspectMatcher aspectMatcher, PointcutMatcher pointcutMatcher)
            : base("Assemblies")
        {
            this.assemblies = assemblies;
            this.model = model;
            this.aspectMatcher = aspectMatcher;
            this.pointcutMatcher = pointcutMatcher;

            this.ImageIndex = 12;
            this.SelectedImageIndex = 12;

            ArrayList sortedAssemblies = new ArrayList(assemblies);
            sortedAssemblies.Sort(new AssemblyComparer());
            foreach (Assembly asm in sortedAssemblies)
                this.Nodes.Add(new AssemblyNode(asm, model, aspectMatcher, pointcutMatcher));            
        }

        private IList assemblies;
        public virtual IList Assemblies
        {
            get { return assemblies; }
            set { assemblies = value; }
        }

        private PresentationModel model;
        public virtual PresentationModel Model
        {
            get { return model; }
            set { model = value; }
        }

        private AspectMatcher aspectMatcher;
        public virtual AspectMatcher AspectMatcher
        {
            get { return aspectMatcher; }
            set { aspectMatcher = value; }
        }

        private PointcutMatcher pointcutMatcher;
        public virtual PointcutMatcher PointcutMatcher
        {
            get { return pointcutMatcher; }
            set { pointcutMatcher = value; }
        }

        public override void Refresh()
        {
            #region Prune Assemblies

            IList prune = new ArrayList();
            Hashtable existing = new Hashtable();
            foreach (Assembly asm in assemblies)
                existing[asm] = asm;

            foreach (TreeNode node in this.Nodes)
            {
                AssemblyNode asmNode = node as AssemblyNode;
                if (asmNode != null)
                {
                    if (!existing.Contains(asmNode.Assembly))
                        prune.Add(asmNode);
                }
            }

            foreach (TreeNode pruneNode in prune)
                this.Nodes.Remove(pruneNode);

            #endregion

            #region Add Targets

            IList insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                AssemblyNode asmNode = node as AssemblyNode;
                if (asmNode != null)
                    existing[asmNode.Assembly] = asmNode.Assembly;
            }

            foreach (Assembly asm in assemblies)
                if (!existing.Contains(asm))
                    insert.Add(asm);

            foreach (Assembly asm in insert)
            {
                AssemblyNode insertNode = new AssemblyNode(asm, model, aspectMatcher, pointcutMatcher);
                this.Nodes.Add(insertNode);
            }

            #endregion

            base.Refresh();
        }
	
    }
}
