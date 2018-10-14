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
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;

namespace Puzzle.NPersist.Framework.Interfaces
{
	/// <summary>
	/// Summary description for IListInterceptor.
	/// </summary>
	public interface IListInterceptor
	{
		void BeforeCall();
		void AfterCall();

		Notification Notification { get; }

		string PropertyName 
		{
			get;
			set;
		}

		IInterceptable Interceptable 
		{
			get;
			set;
		}

		bool MuteNotify
		{
			get;
			set;
		}

		IList List
		{
			get;
			set;
		}

        bool BeforeCount(ref int count);

        void AfterCount(ref int count);

		void BeforeRead();
	}

}
