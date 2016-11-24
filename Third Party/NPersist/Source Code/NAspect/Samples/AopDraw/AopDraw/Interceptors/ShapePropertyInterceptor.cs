using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Interception;
using AopDraw.Interfaces;

namespace AopDraw.Interceptors
{
    public class ShapePropertyInterceptor : IAroundInterceptor
    {
        public object HandleCall(Puzzle.NAspect.Framework.MethodInvocation call)
        {
            object res = call.Proceed();
            ICanvasAware canvasAware = call.Target as ICanvasAware;
            if (canvasAware != null && canvasAware.Canvas != null)
            {
                canvasAware.Canvas.IsDirty = true;
            }
            return res;
        }
    }
}
