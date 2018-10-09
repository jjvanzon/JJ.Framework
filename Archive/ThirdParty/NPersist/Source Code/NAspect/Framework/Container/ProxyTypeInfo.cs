using System;
using System.Text;

namespace Puzzle.NAspect.Framework
{
    /// <summary>
    /// This class tells the engine if a type have been proxied or extended.
    /// </summary>
	public class ProxyTypeInfo
	{
        /// <summary>
        /// The proxied type
        /// </summary>
        public Type Type;

        /// <summary>
        /// Is the type proxied?
        /// </summary>
        public bool IsProxied;

        /// <summary>
        /// IS the type extended?
        /// </summary>
        public bool IsExtended;
	}
}
