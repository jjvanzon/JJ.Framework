// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using Puzzle.NPersist.Framework.Interfaces;

namespace Puzzle.NPersist.Framework.BaseClasses
{
	/// <summary>
	/// Base class that allows subclasses to hold a reference to an interceptor.
	/// </summary>
	public class Interceptable : IInterceptable
	{
		private IInterceptor m_Interceptor;

		/// <summary>
		/// Gets the interceptor.
		/// </summary>
		/// <returns><c>IInterceptable</c></returns>
		public virtual IInterceptor GetInterceptor() => m_Interceptor;

	    /// <summary>
		/// Sets the interceptor.
		/// </summary>
		/// <param name="value">The new interceptor</param>
		public virtual void SetInterceptor(IInterceptor value) => m_Interceptor = value;
	}
}