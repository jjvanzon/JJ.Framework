// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;

namespace Puzzle.NCore.Framework.Collections
{

    #region EventArgs and Delegate

    public class CollectionEventArgs : EventArgs
    {
        public CollectionEventArgs()
        {
        }

        public CollectionEventArgs(object item, int index)
        {
            Index = index;
            Item = item;
        }

        private object item;

        public object Item
        {
            get => item;
            set => item = value;
        }

        private int index;

        public int Index
        {
            get => index;
            set => index = value;
        }
    }

    public delegate void CollectionEventHandler(object sender, CollectionEventArgs e);

    #endregion
}