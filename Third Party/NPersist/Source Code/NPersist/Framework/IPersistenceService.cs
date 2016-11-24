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
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework 
{
	/// <summary>
	/// The main runtime interface for NPersist users.
	/// </summary>
	public interface IPersistenceService : IDisposable
	{

		/// <summary>
		/// Tries to retrieve an object by its identity. Returns null if the object was not found.
		/// </summary>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and identity or null if no such object exists.</returns>
		object TryGetObjectById(object identity, Type type);

		/// <summary>
		/// Retrieves an object by its identity. Throws an exception if the object was not found.
		/// </summary>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and identity.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified identity and type could be found</exception>
		object GetObjectById(object identity, Type type);

		/// <summary>
		/// Retrieves an object by a secondary, unique key. Returns null if the object was not found.
		/// </summary>
		/// <param name="keyPropertyName">The name of the key property.</param>
		/// <param name="keyValue">The unique key value</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and unique key value or null if no such object exists.</returns>
		object TryGetObjectByKey(string keyPropertyName, object keyValue, Type type);

		/// <summary>
		/// Retrieves an object by a secondary, unique key. Throws an exception if the object was not found.
		/// </summary>
		/// <param name="keyPropertyName">The name of the key property.</param>
		/// <param name="keyValue">The unique key value</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and unique key value.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified unique key value and type could be found</exception>
		object GetObjectByKey(string keyPropertyName, object keyValue, Type type);

		/// <summary>
		/// Tries to retrieve an object by an <c>NPathQuery</c> query. Rreturns null if the object was not found or if more than one object matched the query.
		/// </summary>
		/// <param name="npathQuery">An <c>NPathQuery</c> object specifying which object you want to retrieve.</param>
		/// <returns>An object matching the NPath query or null if no such object or multiple such objects were found.</returns>
		object TryGetObjectByNPath(NPathQuery npathQuery);

		/// <summary>
		/// Tries to retrieve an object by an NPath query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object matching the NPath query or null if no such object or multiple such objects were found.</returns>
		object TryGetObjectByNPath(string npathQuery, Type type);

		/// <summary>
		/// Tries to retrieve an object by an <c>NPathQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <param name="parameters">A list of <c>QueryParameter</c> objects for the NPath query</param>
		/// <returns></returns>
		object TryGetObjectByNPath(string npathQuery, Type type, IList parameters);

		/// <summary>
		/// Retrieves an object by an <c>NPathQuery</c> query.
		/// </summary>
		/// <param name="npathQuery">An <c>NPathQuery</c> object specifying which object you want to retrieve.</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the NPath query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the NPath query</exception>
		object GetObjectByNPath(NPathQuery npathQuery);

		/// <summary>
		/// Retrieves an object by an <c>NPathQuery</c> query.
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the NPath query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the NPath query</exception>
		object GetObjectByNPath(string npathQuery, Type type);

		/// <summary>
		/// Retrieves an object by an <c>NPathQuery</c> query.
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <param name="parameters">A list of <c>QueryParameter</c> objects for the NPath query</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the NPath query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the NPath query</exception>
		object GetObjectByNPath(string npathQuery, Type type, IList parameters);


		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
		/// <param name="npathQuery">An <c>NPathQuery</c> object specifying which objects you want to retrieve.</param>
		/// <returns>A list of objects matching the query</returns>
		IList GetObjectsByNPath(NPathQuery npathQuery);

		
		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
		/// <param name="npathQuery">An <c>NPathQuery</c> object specifying which objects you want to retrieve.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results of the query.</param>
		/// <returns>A list of objects matching the query</returns>
		IList GetObjectsByNPath(NPathQuery npathQuery, IList listToFill);

		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the objects you want to retrieve.</param>
		/// <returns>A list of objects matching the query</returns>
		IList GetObjectsByNPath(string npathQuery, Type type);

		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the objects you want to retrieve.</param>
		/// <param name="parameters">A list of <c>QueryParameter</c> objects for the NPath query</param>
		/// <returns>A list of objects matching the query</returns>
		IList GetObjectsByNPath(string npathQuery, Type type, IList parameters);

		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="type">The type of the objects you want to retrieve.</param>
		/// <param name="parameters">A list of <c>QueryParameter</c> objects for the NPath query</param>
		/// <param name="refreshBehavior">Specifies how cached objects become refreshed with fresh values from the data source.</param>
		/// <returns>A list of objects matching the query</returns>
		IList GetObjectsByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);


		/// <summary>
		/// Creates a new object with the specified identity and type, registering it as up for creation. It will be inserted into the data source on the next call to <c>Commit</c>().
		/// </summary>
		/// <param name="identity">The identity for the new object</param>
		/// <param name="type">The type of the new object</param>
		/// <param name="ctorParams">Contructor parameters for the new object</param>
		/// <returns>A new object with the specified identity and type</returns>
		object CreateObject(object identity, Type type, params object[] ctorParams);

		/// <summary>
		/// Creates a new object with the specified type, registering it as up for creation. It will be inserted into the data source in the next call to <c>Commit</c>(). 
		/// </summary>
        /// <remarks>
        /// Note that you must set the values of all the identity properties that are not assigned by the data source on the object before calling the Commit() method.
        /// </remarks>
		/// <param name="type">The type of the new object</param>
		/// <param name="ctorParams">Contructor parameters for the new object</param>
		/// <returns>A new object with the specified type.</returns>
		object CreateObject(Type type, params object[] ctorParams);


		/// <summary>
		/// Registers an object as up for deletion. The object will be removed from the data source on the next call to <c>Commit</c>().
		/// </summary>
		/// <param name="obj">The object to be deleted.</param>
		void DeleteObject(object obj);


		/// <summary>
		/// Commits all changes to the data source, inserting all new objects, removing all deleted object and saving all modified objects.
		/// </summary>
		void Commit();


		/// <summary>
		/// Gets the null value status for the specified property of an object
		/// </summary>
		/// <param name="obj">The object with the property to get the null value status for</param>
		/// <param name="propertyName">The name of the property to get the null value status for</param>
		/// <returns>True if the property value is null, otherwise False</returns>
		bool GetNullValueStatus(object obj, string propertyName);

		/// <summary>
		/// Sets the null value status for the specified property of an object
		/// </summary>
		/// <param name="obj">The object with the property to set the null value status for</param>
		/// <param name="propertyName">The name of the property to set the null value status for</param>
		/// <param name="value">The new null value status</param>
		void SetNullValueStatus(object obj, string propertyName, bool value);


		/// <summary>
		/// Begins a transaction.
		/// </summary>
		/// <returns>An <c>ITransaction</c> object representing the local transaction</returns>
		ITransaction BeginTransaction();

	}
}
