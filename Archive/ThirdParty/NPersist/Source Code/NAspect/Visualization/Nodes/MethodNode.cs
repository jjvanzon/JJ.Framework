using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;
using Puzzle.NAspect.Framework.Utils;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class MethodNode : NodeBase
    {
        public MethodNode(Type type, MethodBase method, IList aspects, PresentationModel model, PointcutMatcher pointcutMatcher)
            : base(AopTools.GetMethodSignature(method))
        {
            this.type = type;
            this.method = method;
            this.aspects = aspects;
            this.model = model;
            this.pointcutMatcher = pointcutMatcher;

            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;

            if (CanBeProxied())
            {
                if (aspects != null)
                    if (ShouldProxy())
                        AddInterceptorNodes();
            }
            else
            {
                this.ImageIndex = 13;
                this.SelectedImageIndex = 13;
            }
        }

        private Type type;
        public virtual Type Type
        {
            get { return type; }
            set { type = value; }
        }

        private IList aspects;
        public virtual IList Aspects
        {
            get { return aspects; }
            set { aspects = value; }
        }

        private PresentationModel model;
        public virtual PresentationModel Model
        {
            get { return model; }
            set { model = value; }
        }

        private PointcutMatcher pointcutMatcher;
        public virtual PointcutMatcher PointcutMatcher
        {
            get { return pointcutMatcher; }
            set { pointcutMatcher = value; }
        }

        private bool ShouldProxy()
        {
            if (CanBeProxied())
                if (pointcutMatcher.MethodShouldBeProxied(method, aspects, type))
                    return true;
            return false;
        }

        public bool CanBeProxied()
        {
            if (method.IsVirtual && !method.IsFinal)
            {
                return true;
            }
            else if (method.IsVirtual && method.IsFinal)
            {
                if (method.Name.IndexOf(".") >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        private MethodBase method;
        public virtual MethodBase MethodBase
        {
            get { return method; }
            set { method = value; }
        }

        public override object Object
        {
            get { return this.method; }
        }

        public override void Refresh()
        {
            if (aspects == null)
                return;

            if (CanBeProxied())
            {
                if (ShouldProxy())
                    RefreshInterceptorNodes();
                else
                {
                    this.ImageIndex = 2;
                    this.SelectedImageIndex = 2;
                }
            }
            else
            {
                this.ImageIndex = 13;
                this.SelectedImageIndex = 13;
            }
            base.Refresh();
        }

        private void AddInterceptorNodes()
        {
            this.ImageIndex = 10;
            this.SelectedImageIndex = 10;

            foreach (IGenericAspect aspect in aspects)
            {
                foreach (PresentationPointcut pointcut in aspect.Pointcuts)
                {
                    if (pointcut.IsMatch(method, this.Type))
                    {
                        pointcut.AppliedOnMethods.Add(this.method);

                        foreach (PresentationInterceptor interceptor in pointcut.Interceptors)
                        {
                            InterceptorNode interceptorNode = new InterceptorNode(interceptor);
                            this.Nodes.Add(interceptorNode);
                        }
                    }
                }
            }
        }

        private void RefreshInterceptorNodes()
        {
            this.ImageIndex = 10;
            this.SelectedImageIndex = 10;

            IList interceptors = new ArrayList();
            foreach (IGenericAspect aspect in aspects)
            {
                foreach (PresentationPointcut pointcut in aspect.Pointcuts)
                {
                    if (pointcut.IsMatch(method, this.Type))
                    {
                        pointcut.AppliedOnMethods.Add(this.method);

                        foreach (PresentationInterceptor interceptor in pointcut.Interceptors)
                        {
                            interceptors.Add(interceptor);
                        }
                    }
                }
            }

            #region Prune Interceptors

            IList prune = new ArrayList();
            Hashtable existing = new Hashtable();
            foreach (PresentationInterceptor interceptor in interceptors)
                existing[interceptor] = interceptor;

            foreach (TreeNode node in this.Nodes)
            {
                InterceptorNode interceptorNode = node as InterceptorNode;
                if (interceptorNode != null)
                {
                    if (!existing.Contains(interceptorNode.Interceptor))
                        prune.Add(interceptorNode);
                }
            }

            foreach (TreeNode pruneNode in prune)
                this.Nodes.Remove(pruneNode);

            #endregion

            #region Add Interceptors

            IList insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                InterceptorNode interceptorNode = node as InterceptorNode;
                if (interceptorNode != null)
                    existing[interceptorNode.Interceptor] = interceptorNode.Interceptor;
            }

            foreach (PresentationInterceptor interceptor in interceptors)
                if (!existing.Contains(interceptor))
                    insert.Add(interceptor);

            foreach (PresentationInterceptor interceptor in insert)
            {
                InterceptorNode insertNode = new InterceptorNode(interceptor);
                this.Nodes.Add(insertNode);
            }

            #endregion

            #region Order Interceptors

            int i = 0;
            foreach (PresentationInterceptor interceptor in interceptors)
            {
                NodeBase node = TreeViewManager.FindNodeByObject(this.Nodes, interceptor);
                if (node.Index != i)
                {
                    this.Nodes.Remove(node);
                    this.Nodes.Insert(i, node);
                }
                i++;
            }

            #endregion

        }
	
    }
}
