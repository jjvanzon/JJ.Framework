using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NAspect.Standard
{
    public interface IDirtyTracked
    {
        bool IsDirty
        {
            get;
        }

        void ClearDirty();
        void SetPropertyDirtyStatus(string propertyName,bool dirty);
        bool GetPropertyDirtyStatus(string propertyName);
    }
}
