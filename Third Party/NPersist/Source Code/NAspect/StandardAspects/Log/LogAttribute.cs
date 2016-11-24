using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework;

namespace Puzzle.NAspect.Standard
{
    public class LogAttribute : FixedInterceptorAttribute
    {
        public LogAttribute()
            : base(typeof(LogInterceptor))
        {
        }
    }
}
