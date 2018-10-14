using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Standard;

namespace KumoUnitTests
{
    public class LogTarget
    {
        [Log]
        public virtual void MyLoggedMethod(int a, string b, double c)
        {
        }
    }
}
