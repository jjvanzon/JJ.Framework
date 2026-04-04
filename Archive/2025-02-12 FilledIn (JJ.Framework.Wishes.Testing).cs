using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Testing
{
    public static class FilledInTestExtensions
    {
        public static bool IsNully <T>(this NullyPair<T> nullyPair) where T : struct => FilledInTestHelper.IsNully(nullyPair);
        public static bool FilledIn<T>(this NullyPair<T> nullyPair) where T : struct => FilledInTestHelper.FilledIn(nullyPair);
        
        public static bool IsNully <T,U>(this NullyPair<T,U> nullyPair) where T : struct => FilledInTestHelper.IsNully(nullyPair);
        public static bool FilledIn<T,U>(this NullyPair<T,U> nullyPair) where T : struct => FilledInTestHelper.FilledIn(nullyPair);
    }
    
    public class FilledInTestHelper
    {
        public static bool IsNully <T>(NullyPair<T> nullyPair) where T : struct => !FilledIn(nullyPair);
        public static bool Has     <T>(NullyPair<T> nullyPair) where T : struct => FilledIn(nullyPair);
        public static bool FilledIn<T>(NullyPair<T> nullyPair) where T : struct 
            => nullyPair != null && !nullyPair.Equals(default) && !nullyPair.Nully.Equals(default(T));

        public static bool IsNully <T,U>(NullyPair<T,U> nullyPair) where T : struct => !FilledIn(nullyPair);
        public static bool Has     <T,U>(NullyPair<T,U> nullyPair) where T : struct => FilledIn(nullyPair);
        public static bool FilledIn<T,U>(NullyPair<T,U> nullyPair) where T : struct 
            => nullyPair != null && !nullyPair.Equals(default) && !nullyPair.Nully.Equals(default(T));
    }
}
