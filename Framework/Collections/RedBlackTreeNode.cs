using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Collections
{
    internal class RedBlackTreeNode<TKey, TValue>
        where TKey : IComparable
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public RedBlackTreeColorEnum Color { get; set; }
        public RedBlackTreeNode<TKey, TValue> Left { get; set; }
        public RedBlackTreeNode<TKey, TValue> Right { get; set; }
        public RedBlackTreeNode<TKey, TValue> Parent { get; set; }

        public RedBlackTreeNode(TKey key, TValue value, RedBlackTreeColorEnum color)
        {
            Key = key;
            Value = value;
            Color = color;
        }
        public RedBlackTreeNode<TKey, TValue> GetGrandparent()
        {
            if (Parent == null) throw new NullException(() => Parent); // Not the root node
            if (Parent.Parent == null) throw new NullException(() => Parent.Parent);  // Not child of root

            return Parent.Parent;
        }

        public RedBlackTreeNode<TKey, TValue> TryGetSibling()
        {
            if (Parent == null) throw new NullException(() => Parent);

            if (this == Parent.Left)
            {
                return Parent.Right;
            }
            else
            {
                return Parent.Left;
            }
        }

        public RedBlackTreeNode<TKey, TValue> GetUncle()
        {
            if (Parent == null) throw new NullException(() => Parent); // Root node has no uncle
            if (Parent.Parent == null) throw new NullException(() => Parent.Parent); // Children of root have no uncle

            return Parent.TryGetSibling();
        }
    }
}