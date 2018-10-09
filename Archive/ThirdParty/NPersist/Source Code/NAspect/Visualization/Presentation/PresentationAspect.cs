using System;
using System.Collections.Generic;
using System.Text;
using Puzzle.NAspect.Framework.Aop;
using System.Collections;

namespace Puzzle.NAspect.Visualization.Presentation
{
    public class PresentationAspect : GenericAspectBase 
    {
        public PresentationAspect() { ; }

        public PresentationAspect(IGenericAspect aspect)
        {
            this.Name = aspect.Name;

            foreach (AspectTarget target in aspect.Targets)
            {
                PresentationAspectTarget presTarget = new PresentationAspectTarget(this, target);
                this.Targets.Add(presTarget);
            }

            foreach (IPointcut pointcut in aspect.Pointcuts)
            {
                PresentationPointcut presPointcut = new PresentationPointcut(this, pointcut);
                this.Pointcuts.Add(presPointcut);
            }

            foreach (object mixin in aspect.Mixins)
            {
                string typeName = "";
                if (mixin is Type)
                    typeName = ((Type)mixin).FullName;
                else
                    typeName = (string) mixin;

                PresentationMixin presMixin = new PresentationMixin(this, typeName);
                this.Mixins.Add(presMixin);
            }
        }

        private IList appliedOnTypes = new ArrayList();
        public virtual IList AppliedOnTypes
        {
            get { return appliedOnTypes; }
            set { appliedOnTypes = value; }
        }

        public PresentationAspectTarget AddTypeTarget(Type type)
        {
            string typeName = type.FullName;
            foreach (PresentationAspectTarget target in Targets)
            {
                if (target.TargetType == AspectTargetType.Signature)
                    if (target.Signature == typeName)
                        return target;
            }
            PresentationAspectTarget newTarget = new PresentationAspectTarget(this);
            newTarget.TargetType = AspectTargetType.Signature;
            newTarget.Signature = typeName;
            this.Targets.Add(newTarget);
            return newTarget;
        }

        internal PresentationPointcut GetPointcut(string name)
        {
            name = name.ToLower();
            foreach (PresentationPointcut pointcut in Pointcuts)
                if (name == pointcut.Name.ToLower())
                    return pointcut;
            return null;
        }

        internal PresentationPointcut GetPointcutWithNameAndInterceptor(string name, string typeName)
        {
            name = name.ToLower();
            foreach (PresentationPointcut pointcut in Pointcuts)
            {
                if (name == pointcut.Name.ToLower())
                {
                    foreach (PresentationInterceptor interceptor in pointcut.Interceptors)
                    {
                        if (typeName == interceptor.TypeName)
                            return pointcut;
                    }
                }
            }
            return null;
        }
    }
}
