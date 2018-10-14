using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Standard;

namespace KumoUnitTests
{
    [DirtyTracked]
    public class DirtyTrackedClass
    {
        #region Property SomeProp 
        private string someProp;
        public virtual string SomeProp
        {
            get
            {
                return this.someProp;
            }
            [MakeDirty]
            set
            {
                this.someProp = value;
            }
        }                        
        #endregion

        #region Property SomeIntProp 
        private int someIntProp;
        public virtual int SomeIntProp
        {
            get
            {
                return this.someIntProp;
            }
            [MakeDirty]
            set
            {
                this.someIntProp = value;
            }
        }                        
        #endregion

        [ClearDirty]
        public virtual void Save()
        { 
        }
    }
}
