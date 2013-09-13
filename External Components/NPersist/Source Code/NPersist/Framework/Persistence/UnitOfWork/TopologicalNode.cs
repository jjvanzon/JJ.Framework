// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Persistence
{
	public class TopologicalNode
	{
        public TopologicalNode(object obj)
        {
            this.obj = obj;
        }

        private object obj;

        public object Obj
        {
            get { return obj; }
        }

        private IList waitFor = new ArrayList();

        public IList WaitFor 
        {
            get { return this.waitFor; }
        }

        private IList waiting = new ArrayList();

        public IList Waiting 
        {
            get { return this.waiting; }
        }


        public void AddWaitFor(TopologicalNode waitForNode)
        {
            this.waitFor.Add(waitForNode);
            waitForNode.Waiting.Add(this);
        }

        internal void RemoveWaiting()
        {
            foreach (TopologicalNode node in this.waiting)
            {
                node.WaitFor.Remove(this);
            }
            this.waiting.Clear();
        }
    }
}
