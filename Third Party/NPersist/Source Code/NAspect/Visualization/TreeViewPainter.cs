using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Puzzle.NAspect.Visualization
{
    public static class TreeViewPainter
    {
        public static void AttachTreeView(TreeView treeView,int selectionDepth)
        {
            treeView.Tag = selectionDepth; //yes this sucks, change it
            treeView.DrawNode += new DrawTreeNodeEventHandler(treeView_DrawNode);
            treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
            treeView.BeforeSelect += new TreeViewCancelEventHandler(treeView_BeforeSelect);
            treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
        }

        



        private static void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Graphics g = e.Graphics;
            TreeView tv = (TreeView)sender;
            if (e.Node.IsVisible == false)
                return;

            int indent = tv.Indent;
            int depth = e.Node.Level +1;
            int selectedDepth = 1;
            if (e.Node.TreeView.SelectedNode != null)
                selectedDepth = e.Node.TreeView.SelectedNode.Level +1 ;

            int nodeIndent = indent * depth;

            Font font = tv.Font;
            if (e.Node.NodeFont != null)
                font = e.Node.NodeFont;

            Brush fgBrush = null;
            Brush bgBrush = null;
            if (IsSelected(e.Node))
            {
                bgBrush = SystemBrushes.Highlight;
                fgBrush = SystemBrushes.HighlightText;
            }
            else if (IsChildOfSelection(e.Node) && selectedDepth > SelectionDepth(tv))
            {
                int red = (SystemColors.Highlight.R + 255 * 3) / 4;
                int green = (SystemColors.Highlight.G + 255 * 3) / 4;
                int blue = (SystemColors.Highlight.B + 255 * 3) / 4;
                Color overlayColor = Color.FromArgb(red, green, blue);

                bgBrush = new SolidBrush(overlayColor);
                fgBrush = Brushes.Black;
            }
            else
            {
                bgBrush = Brushes.White;
                fgBrush = Brushes.Black;
            }

            g.FillRectangle(bgBrush, e.Bounds);
            int imageWidth = 0;
            if (tv.ImageList != null)
                imageWidth = tv.ImageList.ImageSize.Width;

            g.DrawString(e.Node.Text, font, fgBrush, e.Bounds.Left + nodeIndent + imageWidth, e.Bounds.Top + 1);

            int expanderSize = 9;

            Rectangle expanderBounds = new Rectangle(e.Bounds.Left + nodeIndent - indent / 2 - expanderSize / 2, e.Bounds.Top + tv.ItemHeight / 2 - expanderSize / 2, expanderSize, expanderSize);
            if (e.Node.Nodes.Count > 0)
            {
                Rectangle penBounds = new Rectangle(expanderBounds.X, expanderBounds.Y, expanderBounds.Width - 1, expanderBounds.Height - 1);
                if (e.Node.IsExpanded)
                {
                    g.FillRectangle(Brushes.White, expanderBounds);
                    g.DrawRectangle(Pens.Black, penBounds);
                    g.FillRectangle(Brushes.Black, expanderBounds.Left + 2, expanderBounds.Top + expanderSize / 2, expanderSize - 4, 1);
                }
                else
                {
                    g.FillRectangle(Brushes.White, expanderBounds);
                    g.DrawRectangle(Pens.Black, penBounds);
                    g.FillRectangle(Brushes.Black, expanderBounds.Left + 2, expanderBounds.Top + expanderSize / 2, expanderSize - 4, 1);
                    g.FillRectangle(Brushes.Black, expanderBounds.Left + expanderSize / 2, expanderBounds.Top + 2, 1, expanderSize - 4);
                }
            }

            if (IsChildOfSelection(e.Node) && selectedDepth > SelectionDepth(tv))
            {
                g.FillRectangle(SystemBrushes.Highlight, e.Bounds.Left, e.Bounds.Top, 1, e.Bounds.Height);
                g.FillRectangle(SystemBrushes.Highlight, e.Bounds.Right - 1, e.Bounds.Top, 1, e.Bounds.Height);
                if (IsLastChildOfSelection(e.Node))
                {
                    g.FillRectangle(SystemBrushes.Highlight, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Width, 1);
                }
            }

            if (tv.ImageList != null)
            {
                Image img = null;
                int imageIndex = tv.ImageIndex;
                if (e.Node.ImageIndex != -1)
                    imageIndex = e.Node.ImageIndex;

                img = tv.ImageList.Images[imageIndex];
                g.DrawImageUnscaled(img, e.Bounds.Left + nodeIndent, e.Bounds.Top + e.Bounds.Height / 2 - img.Height / 2);
            }



        }

        private static int SelectionDepth(TreeView tv)
        {
            return ((int)tv.Tag);
        }

        private static bool IsLastChildOfSelection(TreeNode node)
        {
            TreeNode tmp = node.TreeView.SelectedNode;
            if (tmp == null)
                return false;

            while (tmp.LastNode != null && tmp.IsExpanded)
            {
                tmp = tmp.LastNode;
            }

            if (tmp == node)
                return true;
            else
                return false;
        }

        private static bool IsChildOfSelection(TreeNode node)
        {
            if (node.Parent == null)
                return false;

            if (node.Parent.IsSelected)
                return true;

            return IsChildOfSelection(node.Parent);
        }

        private static bool IsSelected(TreeNode node)
        {
            if (node.IsSelected)
                return true;
            else
                return false;
        }


        private static void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            if (tv.SelectedNode == null)
                return;

            Rectangle bounds = GetAllBounds(tv.SelectedNode);
            tv.Invalidate(bounds);
        }

        private static Rectangle GetAllBounds(TreeNode treeNode)
        {
            if (!treeNode.IsExpanded || treeNode.LastNode == null)
                return new Rectangle(0, treeNode.Bounds.Top, treeNode.TreeView.Width, treeNode.Bounds.Height);

            Rectangle lastBounds = GetAllBounds(treeNode.LastNode);
            int height = lastBounds.Bottom - treeNode.Bounds.Top;
            Rectangle allBounds = new Rectangle(0, treeNode.Bounds.Top, treeNode.TreeView.Width, height);
            return allBounds;
        }

        private static void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            TreeView tv = (TreeView)sender;
            Rectangle bounds = GetAllBounds(e.Node);
            tv.Invalidate(bounds);
        }
    }
}
