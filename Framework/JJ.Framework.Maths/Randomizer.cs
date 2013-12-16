using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Maths
{
    public static class Randomizer
    {
        private static Random _random = new Random((int)(DateTime.Now.TimeOfDay.Ticks));

        public static int GetInt32(int max)
        {
            return GetInt32(0, max);
        }

        public static int GetInt32(int min, int max)
        {
            return min + _random.Next(max - min + 1);
        }

        public static T GetRandomItem<T>(IEnumerable<T> collection)
        {
            int count = collection.Count();
            if (count == 0)
            {
                throw new Exception("Collection is empty.");
            }

            int index = Randomizer.GetInt32(count - 1);
            return collection.ElementAt(index);
        }
    }
}
