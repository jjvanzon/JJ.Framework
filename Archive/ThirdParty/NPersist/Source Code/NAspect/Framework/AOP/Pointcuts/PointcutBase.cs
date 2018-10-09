using System.Collections;
using System.Reflection;
using System;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Base class for pointcuts
    /// </summary>
    public abstract class PointcutBase : IPointcut
    {
        private IList interceptors = new ArrayList();
        private IList targets = new ArrayList();

        /// <summary>
        /// Untyped list of <c>IInterceptor</c>s and <c>BeforeDelegate</c>, <c>AroundDelegate</c> and <c>AfterDelegate</c>
        /// </summary>
        public IList Interceptors
        {
            get => interceptors;
            set => interceptors = value;
        }

        /// <summary>
        /// Matches a method with the pointuct
        /// </summary>
        /// <param name="method">The method to match</param>
        /// <returns>True if the pointcut matched the method, otherwise false</returns>
        public virtual bool IsMatch(MethodBase method, Type type)
        {
            foreach (IPointcutTarget target in this.Targets)
            {
                if (target.Exclude)
                    if (target.IsMatch(method, type))
                        return false;
            }

            foreach (PointcutTarget target in this.Targets)
            {
                if (!target.Exclude)
                    if (target.IsMatch(method, type))
                        return true;
            }
            return false;
        }

        public IList Targets 
        {
            get => targets;
            set => targets = value;
        }

        private string name = "Pointcut";
        public virtual string Name
        {
            get => name;
            set => name = value;
        }
    }
}