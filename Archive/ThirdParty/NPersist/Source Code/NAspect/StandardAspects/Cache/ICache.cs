using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NAspect.Standard
{
    public interface ICache
    {
        object GetCachedValue(string cacheName);
        bool HasCachedValue(string cacheName);
        void SetCachedValue(string cacheName, object value);
    }
}
