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
using System.Collections.Generic;
using System.Text;
using Puzzle.NPersist.Framework;


namespace Puzzle.NPersist.Framework.Linq
{
    public interface ITable
    {
        void Init(IContext context,ILoadSpan loadSpan);       
    }
    
    public interface ITable<T> : IList<T> 
    {
        bool IsLoaded {get;set;}
        bool IsDirty {get;set;}
        LinqQuery<T> Query {get;}
        LinqToNPathConverter Converter { get; set; }

        ITable<T> Clone();
    }
}
