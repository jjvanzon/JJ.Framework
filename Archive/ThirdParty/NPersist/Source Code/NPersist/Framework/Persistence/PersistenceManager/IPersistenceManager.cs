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

namespace Puzzle.NPersist.Framework.Persistence
{
	public interface IPersistenceManager : IContextChild
	{
		object GetObject(object identity, Type type, bool lazy);

        object GetObject(object identity, Type type, bool lazy, bool ignoreObjectNotFound);

		object GetObjectByKey(string keyPropertyName, object keyValue, Type type);

		object GetObjectByKey(string keyPropertyName, object keyValue, Type type, bool ignoreObjectNotFound);

		void LoadProperty(object obj, string propertyName);

		void CreateObject(object obj);

		void CommitObject(object obj, int exceptionLimit);

		void DeleteObject(object obj);

		void Commit(int exceptionLimit);

		RefreshBehaviorType RefreshBehavior { get; set; }

		MergeBehaviorType MergeBehavior { get; set; }

		MergeBehaviorType GetMergeBehavior(MergeBehaviorType mergeBehavior, IClassMap classMap, IPropertyMap propertyMap);
		
		RefreshBehaviorType GetRefreshBehavior(RefreshBehaviorType refreshBehavior, IClassMap classMap, IPropertyMap propertyMap);

		OptimisticConcurrencyBehaviorType UpdateOptimisticConcurrencyBehavior { get; set; }

		OptimisticConcurrencyBehaviorType DeleteOptimisticConcurrencyBehavior { get; set; }

		/// <summary>
		/// Specifies the load behavior for the Count property of list properties. 
		/// Eager means subselects will be added to sql queries for eagerly fetching the count of load properties. 
		/// Lazy means no subselects will be included and the Count property can only be read as a consequence of the list property becoming fully loaded.
		/// Default is Eager.
		/// </summary>
		/// <remarks>
		/// With Eager list count load behavior, the inverse manager is able to resolve list properties intelligently, 
		/// so that it knows (by comparing to the eagerly loaded count value) when a list has been completely filled 
		/// with inverse references and can be regarded as fully loaded (transitioning from NotLoaded to Clean)
		/// </remarks>
		LoadBehavior ListCountLoadBehavior { get; set; }
		
		object ManageLoadedValue(object obj, IPropertyMap propertyMap, object value);

		object ManageLoadedValue(object obj, IPropertyMap propertyMap, object value, object discriminator);

		object ManageNullValue(object obj, IPropertyMap propertyMap, object value);

		object ManageReferenceValue(object obj, string propertyName, object value);

		object ManageReferenceValue(object obj, IPropertyMap propertyMap, object value);

		object ManageReferenceValue(object obj, string propertyName, object value, object discriminator);

		object ManageReferenceValue(object obj, IPropertyMap propertyMap, object value, object discriminator);

		void SetupNullValueStatuses(object obj);

		void MergeObjects(object obj, object existing, MergeBehaviorType mergeBehavior);

		void AttachObject(object obj, Hashtable visited, Hashtable merge);

		void InitializeObject(object obj);

		void SetupObject(object obj);

		OptimisticConcurrencyBehaviorType GetUpdateOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IClassMap classMap);

		OptimisticConcurrencyBehaviorType GetUpdateOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IPropertyMap propertyMap);

		OptimisticConcurrencyBehaviorType GetDeleteOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IClassMap classMap);

		OptimisticConcurrencyBehaviorType GetDeleteOptimisticConcurrencyBehavior(OptimisticConcurrencyBehaviorType optimisticConcurrencyBehavior, IPropertyMap propertyMap);

		LoadBehavior GetListCountLoadBehavior(LoadBehavior loadBehavior, IPropertyMap propertyMap);
	}
}