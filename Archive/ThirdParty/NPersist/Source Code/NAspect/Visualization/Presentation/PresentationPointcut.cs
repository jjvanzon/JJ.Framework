using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;
using System.Reflection;
using Puzzle.NAspect.Framework.Utils;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationPointcut : Pointcut
    {
        public PresentationPointcut(PresentationAspect aspect) 
        {
            this.aspect = aspect;
        }

        public PresentationPointcut(PresentationAspect aspect, IPointcut pointcut)
        {
            this.aspect = aspect;

            this.Name = pointcut.Name;

            foreach (PointcutTarget target in pointcut.Targets)
            {
                PresentationPointcutTarget presTarget = new PresentationPointcutTarget(this, target);
                this.Targets.Add(presTarget);
            }

            foreach (object interceptor in pointcut.Interceptors)
            {
                string typeName = "";
                if (interceptor is Type)
                    typeName = ((Type)interceptor).FullName;
                else
                    typeName = (string)interceptor;

                PresentationInterceptor presInterceptor = new PresentationInterceptor(this, typeName);
                this.Interceptors.Add(presInterceptor);
            }

        }

        private PresentationAspect aspect;
        public virtual PresentationAspect Aspect
        {
            get { return aspect; }
            set { aspect = value; }
        }

        private IList appliedOnMethods = new ArrayList();
        public virtual IList AppliedOnMethods
        {
            get { return appliedOnMethods; }
        }

        internal PresentationInterceptor GetInterceptor(string typeName)
        {
            foreach (PresentationInterceptor interceptor in Interceptors)
            {
                if (typeName == interceptor.TypeName)
                    return interceptor;
            }
            return null;
        }

        public PresentationPointcutTarget AddTypeTarget(Type type)
        {
            string fullSignature = type.FullName + ".*";
            return AddFullSignatureTarget(type, fullSignature);
        }

        public PresentationPointcutTarget AddMethodTarget(MethodBase method, Type type)
        {
            string fullSignature = type.FullName + "." + AopTools.GetMethodSignature(method);
            return AddFullSignatureTarget(type, fullSignature);
        }

        private PresentationPointcutTarget AddFullSignatureTarget(Type type, string fullSignature)
        {
            PresentationAspect aspect = this.Aspect;
            aspect.AddTypeTarget(type);

            foreach (PresentationPointcutTarget target in this.Targets)
            {
                if (target.TargetType == PointcutTargetType.FullSignature)
                    if (target.Signature == fullSignature)
                        return target;
            }

            PresentationPointcutTarget newTarget = new PresentationPointcutTarget(this);
            newTarget.TargetType = PointcutTargetType.FullSignature;
            newTarget.Signature = fullSignature;
            this.Targets.Add(newTarget);
            return newTarget;
        }

    }
}
