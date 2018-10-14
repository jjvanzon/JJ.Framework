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
using System.Collections;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework.Remoting.Marshaling
{
	/// <summary>
	/// Summary description for IMarshalingTransformer.
	/// </summary>
	public interface IMarshalingTransformer : IContextChild
	{
		string GetIdentity(MarshalObject marshalObject);
		string GetIdentity(MarshalReference marshalReference, MarshalReferenceValue marshalReferenceValue);
		void ToObject(MarshalObject marshalObject, ref object targetObject);
		MarshalObject FromObject(object sourceObject);
		MarshalObject FromObject(object sourceObject, bool upForCreation);
		object ToPropertyValue(object targetObject, string value, MarshalProperty mp, IPropertyMap propertyMap);
		string FromPropertyValue(object sourceObject, object value, IPropertyMap propertyMap);
		MarshalQuery FromQuery(IQuery query);
		IQuery ToQuery(MarshalQuery marshalQuery);
		MarshalObjectList FromObjectList(IList sourceObjects);
		IList ToObjectList(MarshalObjectList marshalObjectList, RefreshBehaviorType refreshBehaviorType, IList listToFill);
		MarshalReference FromObjectAsReference(object sourceObject);
		MarshalProperty FromProperty(object sourceObject, IPropertyMap propertyMap);
		void ToProperty(object targetObject, MarshalProperty mp, IPropertyMap propertyMap, RefreshBehaviorType refreshBehavior);
	}
}
