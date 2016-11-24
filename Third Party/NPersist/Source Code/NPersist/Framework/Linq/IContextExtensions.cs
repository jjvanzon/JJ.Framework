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
using Puzzle.NPersist.Framework.Linq;

namespace Puzzle.NPersist.Framework
{
    public static class IContextExtensions
    {
        public static ITable<T> Repository<T> (this IContext context)
        {
            Table<T> list = new Table<T>();
            ITable ilinqList = (ITable)list;
            ilinqList.Init (context,null);

            return list;
        }

        public static ITable<T> Repository<T>(this IContext context,LoadSpan<T> loadSpan)
        {            
            Table<T> list = new Table<T>();
            ITable ilinqList = (ITable)list;
            ilinqList.Init(context,loadSpan);

            return list;
        }
    }
}
