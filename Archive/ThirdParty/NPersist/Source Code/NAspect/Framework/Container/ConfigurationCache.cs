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

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// For internal use only
    /// </summary>
    public class ConfigurationCache
    {
        private static volatile Hashtable proxyCache = new Hashtable();
        private static volatile Hashtable wrapperCache = new Hashtable();
        private static volatile object syncRoot = new object();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurationName"></param>
        /// <returns></returns>
        public static IDictionary GetProxyLookup(string configurationName)
        {
            lock (syncRoot)
            {
                if (proxyCache[configurationName] == null)
                    proxyCache[configurationName] = new Hashtable();

                return proxyCache[configurationName] as IDictionary;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurationName"></param>
        /// <returns></returns>
        public static IDictionary GetWrapperLookup(string configurationName)
        {
            lock (syncRoot)
            {
                if (wrapperCache[configurationName] == null)
                    wrapperCache[configurationName] = new Hashtable();

                return wrapperCache[configurationName] as IDictionary;
            }
        }
    }
}