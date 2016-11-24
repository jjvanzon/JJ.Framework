using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;
using System.Reflection;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationInterceptor
    {
        public PresentationInterceptor(PresentationPointcut pointcut)
        {
            this.pointcut = pointcut;
        }

        public PresentationInterceptor(PresentationPointcut pointcut, string interceptor)
        {
            this.pointcut = pointcut;
            this.typeName = interceptor;
        }

        private PresentationPointcut pointcut;
        public virtual PresentationPointcut Pointcut
        {
            get { return pointcut; }
            set { pointcut = value; }
        }	

        private string typeName;
        public virtual string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public virtual IList AppliedOnMethods
        {
            get { return pointcut.AppliedOnMethods; }
        }


        public PresentationPointcutTarget AddTypeTarget(Type type)
        {
            return this.Pointcut.AddTypeTarget(type);
        }

        public PresentationPointcutTarget AddMethodTarget(MethodBase method, Type type)
        {
            return this.Pointcut.AddMethodTarget(method, type);
        }
    }
}
