using System;
using System.Collections.Generic;
using System.Text;

namespace Puzzle.NAspect.Standard
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DirtyTrackedAttribute : Attribute
    {
    }
}
