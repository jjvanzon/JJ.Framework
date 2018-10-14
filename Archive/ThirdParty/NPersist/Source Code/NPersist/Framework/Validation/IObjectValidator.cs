using System;
using System.Collections;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NPersist.Framework.Validation
{
	/// <summary>
	/// Summary description for IObjectValidator.
	/// </summary>
	public interface IObjectValidator : IContextChild
	{
		bool IsValid(object obj);

		bool IsValid(object obj, string propertyName);

		void ValidateObject(object obj);

		void ValidateObject(object obj, IList exceptions);
		
		void ValidateProperty(object obj, string propertyName);

		void ValidateProperty(object obj, string propertyName, IList exceptions);

        ValidationMode GetValidationMode(object obj);

        ValidationMode GetValidationMode(IClassMap classMap);

        ValidationMode GetValidationMode(object obj, string propertyName);

        ValidationMode GetValidationMode(IClassMap classMap, IPropertyMap propertyMap);
	}
}
