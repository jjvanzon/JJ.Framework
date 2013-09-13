using System;
using System.Text;
using System.Collections;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// The standard aspect representation
    /// </summary>
	public class GenericAspect : GenericAspectBase
	{       
        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="name">Name of the aspect.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public GenericAspect(string name, IList mixins, IList pointcuts)
        {
            Name = name;
            Mixins = mixins;
            Pointcuts = pointcuts;
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="name">Name of the aspect.</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public GenericAspect(string name, Type[] mixins, IPointcut[] pointcuts)
        {
            Name = name;
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="name">Name of the aspect.</param>
        /// <param name="targets">IList of aspect targets.</param>
        /// <param name="mixins">IList of mixin types.</param>
        /// <param name="pointcuts">IList of IPointcut instances.</param>
        public GenericAspect(string name, IList targets, IList mixins, IList pointcuts)
        {
            Name = name;
            Targets = targets;
            Mixins = mixins;
            Pointcuts = pointcuts;
        }

        /// <summary>
        /// Attribute aspect Ctor.
        /// </summary>
        /// <param name="name">Name of the aspect.</param>
        /// <param name="targets">Type[] array of aspect targets</param>
        /// <param name="mixins">Type[] array of mixin types</param>
        /// <param name="pointcuts">IPointcut[] array of pointcut instances</param>
        public GenericAspect(string name, AspectTarget[] targets, Type[] mixins, IPointcut[] pointcuts)
        {
            Name = name;
            Targets = new ArrayList(targets);
            Mixins = new ArrayList(mixins);
            Pointcuts = new ArrayList(pointcuts);
        }

    }
}
