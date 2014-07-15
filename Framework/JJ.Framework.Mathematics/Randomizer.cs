using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Mathematics
{
    public static class Randomizer
    {
        private static Random _random = new Random();

        /// <summary>
        /// Gets a random Int32 between Int32.MinValue and Int32.MaxValue - 1.
        /// </summary>
        public static int GetInt32()
        {
            // Int32.MaxValue without the - 1 can produce an overflow error.
            return GetInt32(Int32.MinValue, Int32.MaxValue - 1);
        }

        /// <summary>
        /// Gets a random Int32 between 0 and the specified value.
        /// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
        /// </summary>
        public static int GetInt32(int max)
        {
            return GetInt32(0, max);
        }

        /// <summary>
        /// Gets a random Int32 between between a minimum and a maximum.
        /// Both the minimum and the maximum are included.
        /// max must at most be Int32.MaxValue - 1 or an overflow exception could occur.
        /// </summary>
        public static int GetInt32(int min, int max)
        {
            checked
            {
                int result = _random.Next(min, max + 1);
                return result;
            }
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
