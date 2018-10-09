// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Collections;

namespace Puzzle.NAspect.Framework.Aop
{
    /// <summary>
    /// Base class for aspects.
    /// Contains lists of mixins and pointcuts for the aspect.
    /// You generally do not need to use this class by your self.
    /// Use the AttributeAspect , SignatureAspect or Typed aspects.
    /// </summary>
    /// <example>
    /// <para>When inheriting this class you must override the <c>IsMatch</c> method.</para>
    /// <code lang="CS">
    /// //aspect that matches all types whose name start with MyClass
    /// public override bool IsMatch(Type type)
    /// {
    ///     if (type.Name.StartsWith("MyClass"))
    ///         return true;
    ///     else
    ///         return false;
    /// }
    /// </code>
    /// </example>
    public abstract class GenericAspectBase : IGenericAspect
    {
        private string name;
        private IList mixins = new ArrayList();
        private Hashtable mixinsForTypes = new Hashtable();
        private IList pointcuts = new ArrayList();
        private IList targets = new ArrayList();
        private IList typeExtenders = new ArrayList();

        /// <summary>
        /// Just a name of the aspect, has no real purpose today.
        /// Features to fetch named aspects might be added later.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }


        /// <summary>
        /// 
        /// </summary>
        public IList Mixins
        {
            get => mixins;
            set => mixins = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList TypeExtenders
        {
            get => typeExtenders;
            set => typeExtenders = value;
        }

        /// <summary>
        /// List of pointcuts.
        /// Since this is .NET 1.x compatible and we are lazy farts, you get this in an untyped manner.
        /// The element type of this list should be <c>IPointcut</c>.
        /// </summary>
        public IList Pointcuts
        {
            get => pointcuts;
            set => pointcuts = value;
        }

        /// <summary>
        /// List of targets
        /// </summary>
        public IList Targets 
        {
            get => targets;
            set => targets = value;
        }

        /// <summary>
        /// Implementation of AspectBase.IsMatch
        /// <seealso cref="IGenericAspect.IsMatch"/>
        /// </summary>
        /// <param name="type">Type to match</param>
        /// <returns>true if the aspect should be applied to the type, otherwise false.</returns>
        public virtual bool IsMatch(Type type)
        {
            foreach (IAspectTarget target in this.Targets)
            {
                if (target.Exclude)
                    if (target.IsMatch(type))
                        return false;
            }

            foreach (IAspectTarget target in this.Targets)
            {
                if (!target.Exclude)
                    if (target.IsMatch(type))
                        return true;
            }
            return false;
        }
    }
}