using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Puzzle.NAspect.Framework;
using System.Collections;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Visualization.Nodes;
using Puzzle.NAspect.Visualization.Sorting;
using Puzzle.NAspect.Visualization.Presentation;

namespace Puzzle.NAspect.Visualization
{
    public class TreeViewManager
    {

        public static void SetupProjectTreeView(TreeView treeView, IList assemblies, PresentationModel model, AspectMatcher aspectMatcher, PointcutMatcher pointcutMatcher)
        {
            treeView.Nodes.Clear();

            AssemblyListNode node = new AssemblyListNode(assemblies, model, aspectMatcher, pointcutMatcher);
            treeView.Nodes.Add(node);
        }

        public static void SetupAspectTreeView(TreeView treeView, IList assemblies, PresentationModel model, AspectMatcher aspectMatcher, PointcutMatcher pointcutMatcher)
        {
            treeView.Nodes.Clear();

            treeView.Nodes.Add(new ConfigurationNode(model));
        }

        public static void RefreshTreeView(TreeView treeView)
        {
            treeView.BeginUpdate(); 
            foreach (NodeBase node in treeView.Nodes)
                node.Refresh();
            treeView.EndUpdate();
        }

        internal static NodeBase FindNodeByObject(TreeNodeCollection treeNodeCollection, object obj)
        {
            foreach (NodeBase node in treeNodeCollection)
                if (node.Object == obj)
                    return node;
            return null;
        }
    }
}
