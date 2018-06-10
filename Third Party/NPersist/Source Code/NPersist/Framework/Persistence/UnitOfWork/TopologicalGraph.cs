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
	public class TopologicalGraph
	{
        private Hashtable graph = new Hashtable();

        public Hashtable Graph => graph;

	    public void AddNode(object obj, object waitFor)
        {
            TopologicalNode node = GetNode(obj);
            TopologicalNode waitForNode = GetNode(waitFor);
            node.AddWaitFor(waitForNode);
        }

        public void RemoveNode(object obj)
        {
            TopologicalNode node = (TopologicalNode) graph[obj];
            if (node != null)
            {
                node.RemoveWaiting();
            }
        }

        public TopologicalNode GetNode(object obj)
        {
            TopologicalNode node = (TopologicalNode) graph[obj];
            if (node == null)
                node = new TopologicalNode(obj);
            graph[obj] = node;
            return node;
        }

        internal bool IsWaiting(object obj)
        {
            TopologicalNode node = (TopologicalNode) graph[obj];
            if (node != null)
            {
                if (node.WaitFor.Count > 0)
                    return true;
            }
            return false;
        }

        public virtual void Clear() => this.graph.Clear();
	}
}
