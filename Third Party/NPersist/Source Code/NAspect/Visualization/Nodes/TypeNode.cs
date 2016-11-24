using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Puzzle.NAspect.Framework.Aop;
using System.Reflection;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Visualization.Sorting;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class TypeNode : NodeBase
    {
        public TypeNode(Type type, PresentationModel model, AspectMatcher aspectMatcher, PointcutMatcher pointcutMatcher)
            : base(type.FullName)
        {
            this.type = type;
            this.model = model;
            this.aspectMatcher = aspectMatcher;
            this.pointcutMatcher = pointcutMatcher;

            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;

            ArrayList aspects = null;

            if (model != null)
            {
                aspects = (ArrayList)aspectMatcher.MatchAspectsForType(type, model.Aspects);

                foreach (PresentationAspect aspect in aspects)
                    aspect.AppliedOnTypes.Add(type);

                if (aspects.Count > 0)
                {
                    this.ImageIndex = 9;
                    this.SelectedImageIndex = 9;
                }

                //Order is important....
                //aspects.Sort(new AspectComparer());
                foreach (IGenericAspect aspect in aspects)
                {
                    TreeNode aspectNode = new AspectNode(aspect);
                    this.Nodes.Add(aspectNode);
                }
            }

            ArrayList ctors = new ArrayList(type.GetConstructors());
            ctors.Sort(new MethodComparer());
            foreach (MethodBase method in ctors)
            {
                TreeNode methodNode = new MethodNode(this.Type, method, aspects, model, pointcutMatcher);
                this.Nodes.Add(methodNode);
            }

            ArrayList methods = new ArrayList(type.GetMethods());
            methods.Sort(new MethodComparer());
            foreach (MethodBase method in methods)
            {
                if (!method.IsStatic)
                {
                    TreeNode methodNode = new MethodNode(this.Type, method, aspects, model, pointcutMatcher);
                    this.Nodes.Add(methodNode);
                }
            }


        }

        private Type type;
        public virtual Type Type
        {
            get { return type; }
            set { type = value; }
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
	
        public override object Object
        {
            get { return this.type; }
        }

        public override void Refresh()
        {
            if (model == null)
                return;

            ArrayList aspects = (ArrayList)aspectMatcher.MatchAspectsForType(type, model.Aspects);

            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;

            foreach (PresentationAspect aspect in aspects)
                aspect.AppliedOnTypes.Add(type);

            if (aspects.Count > 0)
            {
                this.ImageIndex = 9;
                this.SelectedImageIndex = 9;
            }

            //Order is important
            //aspects.Sort(new AspectComparer());

            #region Prune Aspects

            IList prune = new ArrayList();
            Hashtable existing = new Hashtable();
            foreach (IGenericAspect aspect in aspects)
                existing[aspect] = aspect;

            foreach (TreeNode node in this.Nodes)
            {
                AspectNode aspectNode = node as AspectNode;
                if (aspectNode != null)
                {
                    if (!existing.Contains(aspectNode.Aspect))
                        prune.Add(aspectNode);
                }
            }

            foreach (TreeNode pruneNode in prune)
                this.Nodes.Remove(pruneNode);

            #endregion

            #region Add Aspects

            int insertAt = -1;
            int i = 0;
            IList insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                AspectNode aspectNode = node as AspectNode;
                if (aspectNode != null)
                    existing[aspectNode.Aspect] = aspectNode.Aspect;

                MethodNode methodNode = node as MethodNode;
                if (methodNode != null)
                {
                    if (insertAt == -1)
                        insertAt = i;
                    methodNode.Aspects = aspects;
                }
                i++;
            }

            foreach (IGenericAspect aspect in aspects)
                if (!existing.Contains(aspect))
                    insert.Add(aspect);

            foreach (IGenericAspect aspect in insert)
            {
                AspectNode insertNode = new AspectNode(aspect);
                this.Nodes.Insert(insertAt, insertNode);
            }

            #endregion

            #region Order Aspects

            i = 0;
            foreach (IGenericAspect aspect in aspects)
            {
                NodeBase node = TreeViewManager.FindNodeByObject(this.Nodes, aspect);
                if (node.Index != i)
                {
                    this.Nodes.Remove(node);
                    this.Nodes.Insert(i, node);
                }
                i++;
            }

            #endregion

            base.Refresh();
        }

    }
}
