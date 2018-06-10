// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;
using Puzzle.NAspect.Framework.Aop;

namespace Puzzle.NAspect.Framework.ConfigurationElements
{
    /// <summary>
    /// Configutration class that holds a set of aspects
    /// </summary>
    public class EngineConfiguration
    {
        #region Public Property TypeExtenders

        private IList typeExtenders;


        /// <summary>
        /// Untyped list of <c>ITypeExtender</c>s
        /// </summary>
        public IList TypeExtenders
        {
            get => typeExtenders;
            set => typeExtenders = value;
        }

        #endregion

        #region Public Property Aspects

        private IList aspects;


        /// <summary>
        /// Untyped list of <c>IAspect</c>s
        /// </summary>
        public IList Aspects
        {
            get => aspects;
            set => aspects = value;
        }

        #endregion

        #region Public Property Name

        private string name;

        /// <summary>
        /// Name of this configuration.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        #endregion

        /// <summary>
        /// EngineConfiguration ctor.
        /// </summary>
        public EngineConfiguration()
        {
            aspects = new ArrayList();
            typeExtenders = new ArrayList();
         //   TypeExtender defaultExtender = new TypeExtender();
         //   typeExtenders.Add(defaultExtender);
        }
    }
}