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
using System.Collections;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NCore.Framework.Exceptions;
using Puzzle.NPersist.Framework.Exceptions;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.Aop
{
    /// <summary>
    /// Summary description for NPersistAspect.
    /// </summary>
    public class DatabindingAspect : IGenericAspect
    {
        private IContext context;
        public DatabindingAspect(IContext context) => this.context = context;

        public string Name
        {
            get => "DatabindingAspect";
            set => throw new IAmOpenSourcePleaseImplementMeException();
        }

        public bool IsMatch(Type type) => (context.DomainMap.GetClassMap(type) != null);

        public IList Mixins
        {
            get
            {
                IList arr = new ArrayList();

                arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.PropertyChangedHelperMixin));
                arr.Add(typeof(Puzzle.NPersist.Framework.Aop.Mixins.EditableObjectMixin));

                return arr;
            }
        }

        public IList Pointcuts
        {
            get
            {
                IList arr = new ArrayList();
                arr.Add(new DatabindingPropertySetPointcut(context));
                return arr;
            }
        }

        private IList targets = new ArrayList();
        public IList Targets => targets;
    }
}
