using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using Puzzle.NAspect.Framework;

namespace Puzzle.NAspect.Standard
{
    [Mixin(typeof(DirtyTrackedMixin))]
    [AspectTarget(TargetAttribute=typeof(DirtyTrackedAttribute))]
    public class DirtyTrackedAspect : ITypedAspect
    {
        [Interceptor(Index = 1, TargetAttribute = typeof(MakeDirtyAttribute))]
        public void MakeDirty(BeforeMethodInvocation call)
        {
            IDirtyTracked target = call.Target as IDirtyTracked;
            string method = call.Method.Name;
            method = method.Replace("set_", "");
            target.SetPropertyDirtyStatus(method, true);          
        }

        [Interceptor(Index = 1, TargetAttribute = typeof(ClearDirtyAttribute))]
        public void ClearDirty(BeforeMethodInvocation call)
        {
            IDirtyTracked target = call.Target as IDirtyTracked;
            target.ClearDirty();
        }
    }
}
