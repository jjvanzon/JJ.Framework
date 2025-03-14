using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Mathematics
{
    public static class RandomizerWishes
    {
        public static T GetRandomItem<T>(params T[] collection)
            => Randomizer_Copied.GetRandomItem(collection);
    }
}