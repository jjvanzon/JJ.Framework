using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Puzzle.NAspect.Standard
{
    public class DirtyTrackedMixin : IDirtyTracked
    {
        private Dictionary<string, bool> propertyStatus = new Dictionary<string, bool>();

        public bool IsDirty
        {
            get
            {
                foreach (bool dirtyProp in propertyStatus.Values)
                {
                    if (dirtyProp)
                        return true;
                }

                return false;
            }
        }

        public void ClearDirty()
        {
            propertyStatus.Clear();
        }

        public void SetPropertyDirtyStatus(string propertyName, bool dirty)
        {
            propertyStatus[propertyName] = dirty;
        }

        public bool GetPropertyDirtyStatus(string propertyName)
        {
            bool dirty = false;
            propertyStatus.TryGetValue(propertyName, out dirty);
            return dirty;
        }
    }
}
