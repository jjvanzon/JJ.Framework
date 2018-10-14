using System.Diagnostics;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using System.ComponentModel;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;
// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


namespace Puzzle.NPersist.Framework.Aop.Mixins
{
    public class PropertyChangedHelperMixin : IPropertyChangedHelper , IProxyAware 
    {
        private IAopProxy target;

        public event PropertyChangedEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(target, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(target, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SetProxy(Puzzle.NAspect.Framework.IAopProxy target) => this.target = target;
    }
}
