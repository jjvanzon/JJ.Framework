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
using System.Reflection;
using Puzzle.NPersist.Framework;

namespace Puzzle.NPersist.Framework.Linq
{
    public class DataContext
    {
        protected IContext context;

        public DataContext(string mappingPath)
        {
            this.context = new Context(mappingPath);
            Setup();
        }

        public DataContext(string mappingName,Assembly mappingAssembly)
        {
            this.context = new Context(mappingAssembly,mappingName);
            Setup();
        }

        protected virtual void Setup()
        {
            FieldInfo[] fields = this.GetType ().GetFields ();
            foreach(FieldInfo field in fields)
            {
                if (field.FieldType.Name.StartsWith ("Table"))
                {
                    Type genericType = field.FieldType.GetGenericArguments ()[0];

                    ITable instance = (ITable)Activator.CreateInstance(field.FieldType);
                    instance.Init (this.context,null);

                    field.SetValue (this,instance);                    
                }
            }
        }

        public virtual void SubmitChanges() => this.context.Commit ();
    }
}
