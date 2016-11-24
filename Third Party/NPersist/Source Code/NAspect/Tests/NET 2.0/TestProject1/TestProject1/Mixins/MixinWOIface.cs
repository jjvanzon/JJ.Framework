using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;

namespace KumoUnitTests
{
    public class MixinWOIface : IProxyAware
    {
        IAopProxy proxy;

        public void SetProxy(IAopProxy target)
        {
            proxy = target;
        }
    }
}
