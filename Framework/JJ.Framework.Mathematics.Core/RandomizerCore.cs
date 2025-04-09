using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics.Core
{
    public static class RandomizerCore
    {
        public static T GetRandomItem<T>(params T[] collection)
            => RandomizerLegacy.GetRandomItem(collection);
    }
}