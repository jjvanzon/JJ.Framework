using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Visualization.Presentation;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class PointcutNode : NodeBase
    {
        public PointcutNode(IPointcut pointcut)
            : base(pointcut.Name)
        {
            this.pointcut = pointcut;

            this.ImageIndex = 6;
            this.SelectedImageIndex = 6;

            foreach (PointcutTarget target in pointcut.Targets)
            {
                PointcutTargetNode targetNode = new PointcutTargetNode(target);
                this.Nodes.Add(targetNode);
            }

            foreach (PresentationInterceptor interceptor in pointcut.Interceptors)
            {
                InterceptorNode interceptorNode = new InterceptorNode(interceptor);
                this.Nodes.Add(interceptorNode);
            }
        }

        private IPointcut pointcut;
        public virtual IPointcut Pointcut
        {
            get { return pointcut; }
            set { pointcut = value; }
        }

        public override object Object
        {
            get { return this.pointcut ; }
        }

        public override void Refresh()
        {
            this.Text = this.pointcut.Name;


            #region Prune Targets

            IList prune = new ArrayList();
            Hashtable existing = new Hashtable();
            foreach (PointcutTarget target in pointcut.Targets)
                existing[target] = target;

            foreach (TreeNode node in this.Nodes)
            {
                PointcutTargetNode targetNode = node as PointcutTargetNode;
                if (targetNode != null)
                {
                    if (!existing.Contains(targetNode.Target))
                        prune.Add(targetNode);
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
                PointcutTargetNode targetNode = node as PointcutTargetNode;
                if (targetNode != null)
                    existing[targetNode.Target] = targetNode.Target;

                if (insertAt == -1)
                {
                    InterceptorNode interceptorNode = node as InterceptorNode;
                    if (interceptorNode != null)
                        insertAt = i;
                }
                i++;
            }

            foreach (PointcutTarget target in pointcut.Targets)
                if (!existing.Contains(target))
                    insert.Add(target);

            foreach (PointcutTarget target in insert)
            {
                PointcutTargetNode insertNode = new PointcutTargetNode(target);
                this.Nodes.Insert(insertAt, insertNode);
            }

            #endregion

            base.Refresh();
        }

    }	
}
