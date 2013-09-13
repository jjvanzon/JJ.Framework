// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Configuration;
using System.Xml;

namespace Puzzle.NAspect.Framework.Configuration
{
    //TODO: fix documentation

    /// <summary>
    /// 
    /// </summary>
    public class NAspectConfigurationHandler : IConfigurationSectionHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public NAspectConfigurationHandler()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            return section.SelectSingleNode("configuration");
        }
    }
}