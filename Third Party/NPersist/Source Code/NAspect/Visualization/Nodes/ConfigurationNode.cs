using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Visualization.Presentation;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Nodes
{
    public class ConfigurationNode : NodeBase
    {
        public ConfigurationNode(PresentationModel model)
            : base("Configuration")
        {
            this.model = model;

            this.ImageIndex = 11;
            this.SelectedImageIndex = 11;

            foreach (IGenericAspect aspect in model.Aspects)
                this.Nodes.Add(new AspectNode(aspect));
        }

        private PresentationModel model;
        public virtual PresentationModel Model
        {
            get { return model; }
            set { model = value; }
        }
	

        public override void Refresh()
        {
            ArrayList aspects = (ArrayList)model.Aspects;
 
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

            IList insert = new ArrayList();
            existing = new Hashtable();

            foreach (TreeNode node in this.Nodes)
            {
                AspectNode aspectNode = node as AspectNode;
                if (aspectNode != null)
                    existing[aspectNode.Aspect] = aspectNode.Aspect;
            }

            foreach (IGenericAspect aspect in aspects)
                if (!existing.Contains(aspect))
                    insert.Add(aspect);

            foreach (IGenericAspect aspect in insert)
            {
                AspectNode insertNode = new AspectNode(aspect);
                this.Nodes.Add(insertNode);
            }

            #endregion

            #region Order Aspects

            int i = 0;
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
