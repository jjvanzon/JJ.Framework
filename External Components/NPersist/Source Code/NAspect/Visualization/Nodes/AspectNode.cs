using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Windows.Forms;
using System.Collections;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class AspectNode : NodeBase
    {
        public AspectNode(IGenericAspect aspect) : base(aspect.Name)
        {
            this.aspect = aspect;

            this.ImageIndex = 4;
            this.SelectedImageIndex = 4;

            foreach (AspectTarget target in aspect.Targets)
            {
                AspectTargetNode targetNode = new AspectTargetNode(target);
                this.Nodes.Add(targetNode);
            }

            ArrayList mixins = (ArrayList) aspect.Mixins;
            mixins.Sort();
            foreach (PresentationMixin  mixin in mixins)
            {
                MixinNode mixinNode = new MixinNode(mixin);
                this.Nodes.Add(mixinNode);
            }

            foreach (IPointcut pointcut in aspect.Pointcuts)
            {
                PointcutNode pointcutNode = new PointcutNode(pointcut);
                this.Nodes.Add(pointcutNode);
            }

        }
	
        private IGenericAspect aspect;
        public virtual IGenericAspect Aspect
        {
            get { return aspect; }
            set { aspect = value; }
        }

        public override void Refresh()
        {
            this.Text = aspect.Name;

            int pointcutsStartAt = -1;

            #region Prune Targets

            IList prune = new ArrayList();
            Hashtable existing = new Hashtable();
            foreach (AspectTarget target in aspect.Targets)
                existing[target] = target;

            foreach (TreeNode node in this.Nodes)
            {
                AspectTargetNode targetNode = node as AspectTargetNode;
                if (targetNode != null)
                {
                    if (!existing.Contains(targetNode.Target))
                        prune.Add(targetNode);
                }
            }

            foreach (TreeNode pruneNode in prune)
                this.Nodes.Remove(pruneNode);

            #endregion

            #region Prune Mixins

            prune = new ArrayList();
            existing = new Hashtable();
            foreach (PresentationMixin mixin in aspect.Mixins)
                existing[mixin] = mixin;

            foreach (TreeNode node in this.Nodes)
            {
                MixinNode mixinNode = node as MixinNode;
                if (mixinNode != null)
                {
                    if (!existing.Contains(mixinNode.Mixin))
                        prune.Add(mixinNode);
                }
            }

            foreach (TreeNode mixinNode in prune)
                this.Nodes.Remove(mixinNode);

            #endregion

            #region Prune Pointcuts

            prune = new ArrayList();
            existing = new Hashtable();
            foreach (IPointcut pointcut in aspect.Pointcuts)
                existing[pointcut] = pointcut;

            foreach (TreeNode node in this.Nodes)
            {
                PointcutNode pointcutNode = node as PointcutNode;
                if (pointcutNode != null)
                {
                    if (!existing.Contains(pointcutNode.Pointcut))
                        prune.Add(pointcutNode);
                }
            }

            foreach (TreeNode pruneNode in prune)
                this.Nodes.Remove(pruneNode);

            #endregion

            #region Add Targets

            int insertAt = -1;
            int i = 0;
            IList insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                AspectTargetNode targetNode = node as AspectTargetNode;
                if (targetNode != null)
                    existing[targetNode.Target] = targetNode.Target;

                if (insertAt == -1)
                {
                    MixinNode mixinNode = node as MixinNode;
                    if (mixinNode != null)
                        insertAt = i;
                }
                i++;
            }

            foreach (AspectTarget target in aspect.Targets)
                if (!existing.Contains(target))
                    insert.Add(target);

            foreach (AspectTarget target in insert)
            {
                AspectTargetNode insertNode = new AspectTargetNode(target);
                this.Nodes.Insert(insertAt, insertNode);
            }

            #endregion

            #region Add Mixins

            insertAt = -1;
            i = 0;
            insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                MixinNode mixinNode = node as MixinNode;
                if (mixinNode != null)
                    existing[mixinNode.Mixin] = mixinNode.Mixin;

                if (insertAt == -1)
                {
                    PointcutNode pointcutNode = node as PointcutNode;
                    if (pointcutNode != null)
                    {
                        insertAt = i;
                        pointcutsStartAt = i;
                    }
                }
                i++;
            }

            foreach (PresentationMixin mixin in aspect.Mixins)
                if (!existing.Contains(mixin))
                    insert.Add(mixin);

            foreach (PresentationMixin mixin in insert)
            {
                MixinNode insertNode = new MixinNode(mixin);
                this.Nodes.Insert(insertAt, insertNode);
            }

            #endregion

            #region Add Pointcuts

            insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                PointcutNode pointcutNode = node as PointcutNode;
                if (pointcutNode != null)
                    existing[pointcutNode.Pointcut] = pointcutNode.Pointcut;
            }

            foreach (IPointcut pointcut in aspect.Pointcuts)
                if (!existing.Contains(pointcut))
                    insert.Add(pointcut);

            foreach (IPointcut pointcut in insert)
            {
                PointcutNode insertNode = new PointcutNode(pointcut);
                this.Nodes.Add(insertNode);
            }

            #endregion

            #region Order Pointcuts

            i = pointcutsStartAt;
            foreach (IPointcut pointcut in aspect.Pointcuts)
            {
                NodeBase node = TreeViewManager.FindNodeByObject(this.Nodes, pointcut);
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

        public override object Object
        {
            get { return this.aspect; }
        }

    }
}
