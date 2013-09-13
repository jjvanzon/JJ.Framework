// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// Factory that creates default AopEngine instances.
    /// </summary>
    public class EngineFactory
    {
        /// <summary>
        /// Create an AopEngine from app or web.config.
        /// </summary>
        /// <returns></returns>
        public static IEngine FromAppConfig()
        {
            return ApplicationContext.Configure();
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="subSectionName">Name of a subsection in the config.</param>
        /// <returns></returns>
        public static IEngine FromAppConfig(string subSectionName)
        {
            return ApplicationContext.Configure();
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEngine FromFile(string fileName)
        {
            return ApplicationContext.Configure(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="useTypePlaceHolders"></param>
        /// <returns></returns>
        public static IEngine FromFile(string fileName, bool useTypePlaceHolders)
        {
            return ApplicationContext.Configure(fileName, useTypePlaceHolders);
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="subSectionName"></param>
        /// <returns></returns>
        public static IEngine FromFile(string fileName, string subSectionName)
        {
            return null;
        }
    }
}