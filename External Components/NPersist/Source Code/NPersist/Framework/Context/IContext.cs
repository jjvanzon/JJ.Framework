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
using System.Data;
using Puzzle.NPersist.Framework.Delegates;
using Puzzle.NPersist.Framework.Enumerations;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NCore.Framework.Logging;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPath.Framework;
using Puzzle.NPersist.Framework.NPath;
using Puzzle.NPersist.Framework.Persistence;
using Puzzle.NPersist.Framework.Querying;

using Puzzle.NPersist.Framework.Validation;
#if NET2
using System.Collections.Generic;
#endif

namespace Puzzle.NPersist.Framework
{
	/// <summary>
	/// Summary description for IContext.
	/// </summary>	
	public interface IContext : IPersistenceService 
	{
		event BeginningTransactionEventHandler BeginningTransaction;
		event BegunTransactionEventHandler BegunTransaction;
		event CommittingTransactionEventHandler CommittingTransaction;
		event CommittedTransactionEventHandler CommittedTransaction;
		event RollingbackTransactionEventHandler RollingbackTransaction;
		event RolledbackTransactionEventHandler RolledbackTransaction;
		event ExecutingSqlEventHandler ExecutingSql;
		event ExecutedSqlEventHandler ExecutedSql;
		event CallingWebServiceEventHandler CallingWebService;
		event CalledWebServiceEventHandler CalledWebService;
		event CommittedEventHandler Committed;
		event CommittingEventHandler Committing;
		event CreatingObjectEventHandler CreatingObject;
		event CreatedObjectEventHandler CreatedObject;
		event InsertingObjectEventHandler InsertingObject;
		event InsertedObjectEventHandler InsertedObject;
		event DeletingObjectEventHandler DeletingObject;
		event DeletedObjectEventHandler DeletedObject;
		event RemovingObjectEventHandler RemovingObject;
		event RemovedObjectEventHandler RemovedObject;
		event CommittingObjectEventHandler CommittingObject;
		event CommittedObjectEventHandler CommittedObject;
		event UpdatingObjectEventHandler UpdatingObject;
		event UpdatedObjectEventHandler UpdatedObject;
		event GettingObjectEventHandler GettingObject;
		event GotObjectEventHandler GotObject;
		event LoadingObjectEventHandler LoadingObject;
		event LoadedObjectEventHandler LoadedObject;
		event ReadingPropertyEventHandler ReadingProperty;
		event ReadPropertyEventHandler ReadProperty;
		event WritingPropertyEventHandler WritingProperty;
		event WrotePropertyEventHandler WroteProperty;
		event LoadingPropertyEventHandler LoadingProperty;
		event LoadedPropertyEventHandler LoadedProperty;

        /// <summary>
        /// Gets or sets the interceptor.
        /// </summary>
        /// <value>The interceptor.</value>
		IInterceptor Interceptor { get; set; }

        /// <summary>
        /// Gets or sets the persistence manager.
        /// </summary>
        /// <value>The persistence manager.</value>
		IPersistenceManager PersistenceManager { get; set; }

        /// <summary>
        /// Gets or sets the object manager.
        /// </summary>
        /// <value>The object manager.</value>
		IObjectManager ObjectManager { get; set; }

        /// <summary>
        /// Gets or sets the list manager.
        /// </summary>
        /// <value>The list manager.</value>
		IListManager ListManager { get; set; }

        /// <summary>
        /// Gets or sets the domain map.
        /// </summary>
        /// <value>The domain map.</value>
		IDomainMap DomainMap { get; set; }

        /// <summary>
        /// Gets or sets the identity map.
        /// </summary>
        /// <value>The identity map.</value>
		IIdentityMap IdentityMap { get; set; }

        /// <summary>
        /// Gets or sets the object cache manager.
        /// </summary>
        /// <value>The object cache manager.</value>
		IObjectCacheManager ObjectCacheManager { get; set; }

        /// <summary>
        /// Gets or sets the read only object cache manager.
        /// </summary>
        /// <value>The read only object cache manager.</value>
		IReadOnlyObjectCacheManager ReadOnlyObjectCacheManager { get; set; }

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
		IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Gets or sets the inverse manager.
        /// </summary>
        /// <value>The inverse manager.</value>
		IInverseManager InverseManager { get; set; }

        /// <summary>
        /// Gets or sets the event manager.
        /// </summary>
        /// <value>The event manager.</value>
		IEventManager EventManager { get; set; }

        /// <summary>
        /// Gets or sets the data source manager.
        /// </summary>
        /// <value>The data source manager.</value>
		IDataSourceManager DataSourceManager { get; set; }

        /// <summary>
        /// Gets or sets the SQL executor.
        /// </summary>
        /// <value>The SQL executor.</value>
		ISqlExecutor SqlExecutor { get; set; }

        /// <summary>
        /// Gets or sets the log manager.
        /// </summary>
        /// <value>The log manager.</value>
		ILogManager LogManager {get;set;}

        /// <summary>
        /// Gets or sets the persistence engine.
        /// </summary>
        /// <value>The persistence engine.</value>
		IPersistenceEngine PersistenceEngine { get; set; }

        /// <summary>
        /// Gets or sets the persistence engine manager.
        /// </summary>
        /// <value>The persistence engine manager.</value>
		IPersistenceEngineManager PersistenceEngineManager { get; set; }

        /// <summary>
        /// Gets or sets the proxy factory.
        /// </summary>
        /// <value>The proxy factory.</value>
		IProxyFactory ProxyFactory {get;set;}

		//ISqlEngineManager SqlEngineManager { get; set; }

        /// <summary>
        /// Gets or sets the N path engine.
        /// </summary>
        /// <value>The N path engine.</value>
		INPathEngine NPathEngine { get; set; }

        /// <summary>
        /// Gets or sets the object query engine.
        /// </summary>
        /// <value>The object query engine.</value>
		IObjectQueryEngine ObjectQueryEngine { get; set; }

        /// <summary>
        /// Gets or sets the assembly manager.
        /// </summary>
        /// <value>The assembly manager.</value>
		IAssemblyManager AssemblyManager { get; set; }

        /// <summary>
        /// Gets or sets the object factory.
        /// </summary>
        /// <value>The object factory.</value>
		IObjectFactory ObjectFactory { get; set; }

        /// <summary>
        /// Gets or sets the object cloner.
        /// </summary>
        /// <value>The object cloner.</value>
		IObjectCloner ObjectCloner { get; set; }

        /// <summary>
        /// Gets or sets the object validator.
        /// </summary>
        /// <value>The object validator.</value>
		IObjectValidator ObjectValidator { get; set; }

        /// <summary>
        /// Gets or sets the notification mode.
        /// </summary>
        /// <value>The notification mode.</value>
		Notification Notification { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether auto transactions are used.
        /// </summary>
        /// <value><c>true</c> if auto transactions should be used; otherwise, <c>false</c>.</value>
		bool AutoTransactions { get; set; }

        /// <summary>
        /// Gets or sets the deadlock strategy to be used when committing a unit of work.
        /// </summary>
        DeadlockStrategy DeadlockStrategy { get; set; } 

        /// <summary>
        /// Finds the deadlock strategy that should be used given the domain map.
        /// </summary>
        DeadlockStrategy GetDeadlockStrategy();

        /// <summary>
        /// Lets you touch (and thereby lock, assuming this is done within a serializable transaction) the tables in the list in indexed order. 
        /// Use this method when you want to touch/lock the tables you will be reading from in a transaction to avoid deadlocks. If you select the TouchLockTable transaction,
        /// the tables you pass to the first parameter will be ignored (you may pass null to the first parameter in this case).
        /// </summary>
        /// <param name="tables">A list of table names or ITableMap instances.</param>
        /// <param name="deadlockStrategy">The deadlock strategy you want to use. Default will mean you use the strategy from the domain/context.</param>
        void TouchTables(IList tables, DeadlockStrategy deadlockStrategy);

        /// <summary>
        /// Gets or sets the domain key.
        /// </summary>
        /// <value>The domain key.</value>
		string DomainKey { get; set; }

        /// <summary>
        /// Gets or sets the parameter counter.
        /// </summary>
        /// <value>The parameter counter.</value>
        long ParamCounter { get; set; }

        /// <summary>
        /// Gets the next parameter number.
        /// </summary>
        /// <returns></returns>
        long GetNextParamNr();



        /// <summary>
        /// Gets the object status.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
		ObjectStatus GetObjectStatus(object obj);

        /// <summary>
        /// Gets the property status for an object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns></returns>
		PropertyStatus GetPropertyStatus(object obj, string propertyName);

        /// <summary>
        /// Loads a property of an object with a value from the database.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">The name of the property.</param>
		void LoadProperty(object obj, string propertyName);

        /// <summary>
        /// Executes a scalar query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalar(IQuery query);

        /// <summary>
        /// Executes a scalar query on a specified data source.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="dataSource">The data source.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalar(IQuery query, IDataSource dataSource);

        /// <summary>
        /// Executes a scalar npath query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type that the npath query is primarily formulated against.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalar(string npath, Type type);

        /// <summary>
        /// Executes a scalar npath query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type that the npath query is primarily formulated against.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalarByNPath(string npath, Type type);

        /// <summary>
        /// Executes a scalar npath query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type that the npath query is primarily formulated against.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalarByNPath(string npath, Type type, IList parameters);

        /// <summary>
        /// Executes a scalar npath query on a specified data source.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type that the npath query is primarily formulated against.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="dataSource">The data source.</param>
        /// <returns>A scalar result</returns>
        object ExecuteScalarByNPath(string npath, Type type, IList parameters, IDataSource dataSource);

        /// <summary>
        /// Executes a scalar sql query.
        /// </summary>
        /// <param name="sql">The sql query string.</param>
        /// <returns>A scalar result</returns>
		object ExecuteScalarBySql(string sql);

        /// <summary>
        /// Executes a scalar sql query.
        /// </summary>
        /// <param name="sql">The sql query string.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <returns></returns>
		object ExecuteScalarBySql(string sql, IList parameters);

        /// <summary>
        /// Executes a scalar sql query.
        /// </summary>
        /// <param name="sql">The sql query string.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="dataSource">The data source.</param>
        /// <returns></returns>
		object ExecuteScalarBySql(string sql, IList parameters, IDataSource dataSource);


        /// <summary>
        /// This method commits the context and any root contexts that this context is a leaf context to, recursively. Only used in Object/Object Mapping scenarios.
        /// </summary>
        void CommitRecursive();

        /// <summary>
        /// This method commits the context and any root contexts that this context is a leaf context to, recursively. Only used in Object/Object Mapping scenarios.
        /// </summary>
        /// <param name="exceptionLimit">The maximum number of exception that may occur during the commit before the operation aborts. The default value of 1 means that the commit operation will break on the first exception. A value of 0 indicates no limit on the amount of exceptions that can occur during the commit before the operation aborts.</param>
        void CommitRecursive(int exceptionLimit);

        /// <summary>
        /// Commits a single object to the data source.
        /// </summary>
        /// <remarks>
        /// This method is exposed in order to provide a route for manual workarounds if the order in which the Commit() method 
        /// tries to commit the objects in the unit of work should fail due to some error in the topological sort. 
        /// <br></br><br></br>
        /// Normally the developer should not call this method which may produce strange results unless you are very sure what you are doing.
        /// Please use the Commit() method instead.
        /// </remarks>
        /// <param name="obj">The object to be committed.</param>
		void CommitObject(object obj);

        /// <summary>
        /// Commits a single object to the data source.
        /// </summary>
        /// <remarks>
        /// This method is exposed in order to provide a route for manual workarounds if the order in which the Commit() method 
        /// tries to commit the objects in the unit of work should fail due to some error in the topological sort. 
        /// <br></br><br></br>
        /// Normally the developer should not call this method which may produce strange results unless you are very sure what you are doing.
        /// Please use the Commit() method instead.
        /// </remarks>
        /// <param name="obj">The object to be committed.</param>
        /// <param name="exceptionLimit">The maximum number of exception that may occur during the commit before the operation aborts. The default value of 1 means that the commit operation will break on the first exception. A value of 0 indicates no limit on the amount of exceptions that can occur during the commit before the operation aborts.</param>
		void CommitObject(object obj, int exceptionLimit);

        /// <summary>
		/// Registers an object as up for deletion. The object will be removed from the data source on the next call to <c>Commit</c>().
        /// </summary>
        /// <param name="identity">The identity of the object that you want to remove.</param>
        /// <param name="type">The type of the object that you want to remove.f</param>
		void DeleteObject(object identity, Type type);

        /// <summary>
        /// Deletes the objects in the supplied list.
        /// </summary>
        /// <remarks>
        /// The objects will only be marked as UpForCreation and will not be removed from the data source until you call the Commit() method.
        /// </remarks>
        /// <param name="objects">The objects to be deleted.</param>
		void DeleteObjects(IList objects);


        /// <summary>
        /// Commits all changes to the database. This method has been renamed to Commit().
        /// </summary>
        [Obsolete("This method has been renamed to Commit()", false)]
		void PersistAll();

		/// <summary>
		/// Commits all changes to the data source, inserting all new objects, removing all deleted object and saving all modified objects.
		/// </summary>
        /// <param name="exceptionLimit">The maximum number of exception that may occur during the commit before the operation aborts. The default value of 1 means that the commit operation will break on the first exception. A value of 0 indicates no limit on the amount of exceptions that can occur during the commit before the operation aborts.</param>
		void Commit(int exceptionLimit);

        /// <summary>
        /// Refreshes an object, reloading it with the current values form the data source.
        /// </summary>
        /// <param name="obj">The object to be refreshed.</param>
		void RefreshObject(object obj);

        /// <summary>
        /// Refreshes an object, reloading it with the current values form the data source.
        /// </summary>
        /// <param name="obj">The object to be refreshed.</param>
        /// <param name="refreshBehavior">The refresh behavior to be used.</param>
		void RefreshObject(object obj, RefreshBehaviorType refreshBehavior);

        /// <summary>
        /// Refreshes a list of objects, reloading them with the current values form the data source.
        /// </summary>
        /// <param name="objects">The objects to be refreshed.</param>
		void RefreshObjects(IList objects);

        /// <summary>
        /// Refreshes a list of objects, reloading them with the current values form the data source.
        /// </summary>
        /// <param name="objects">The objects to be refreshed.</param>
        /// <param name="refreshBehavior">The refresh behavior to be used.</param>
		void RefreshObjects(IList objects, RefreshBehaviorType refreshBehavior);

        /// <summary>
        /// Refreshes a property of an object, reloading it with the current value form the data source.
        /// </summary>
        /// <param name="obj">The object with the property to be refreshed.</param>
        /// <param name="propertyName">The name of the property to be refreshed.</param>
		void RefreshProperty(object obj, string propertyName);

        /// <summary>
        /// Refreshes a property of an object, reloading it with the current value form the data source.
        /// </summary>
        /// <param name="obj">The object with the property to be refreshed.</param>
        /// <param name="propertyName">The name of the property to be refreshed.</param>
        /// <param name="refreshBehavior">The refresh behavior to be used.</param>
		void RefreshProperty(object obj, string propertyName, RefreshBehaviorType refreshBehavior);

        /// <summary>
        /// Invalidates all objects in the cache, marking their Clean properties as NotLoaded and discarding the original property values.
        /// </summary>
        void Invalidate();

        /// <summary>
        /// Invalidates all objects in the cache, marking their properties as NotLoaded and discarding the original property values.
        /// </summary>
        /// <param name="invalidateDirty">Set to true if you want to invalidate Dirty properties in addition to Clean ones.</param>
        void Invalidate(bool invalidateDirty);

        /// <summary>
        /// Invalidates a list of objects, marking their Clean properties as NotLoaded and discarding the original property values.
        /// </summary>
        /// <param name="objects">The list of objects to invalidate</param>
		void Invalidate(IList objects);

        /// <summary>
        /// Invalidates a list of objects, marking their properties as NotLoaded and discarding the original property values.
        /// </summary>
        /// <param name="objects">The list of objects to invalidate</param>
        /// <param name="invalidateDirty">Set to true if you want to invalidate Dirty properties in addition to Clean ones.</param>
        void Invalidate(IList objects, bool invalidateDirty);

        /// <summary>
        /// Invalidates an object, marking its Clean properties as NotLoaded and discarding the original property values.
        /// </summary>
        /// <param name="obj">The object to invalidate</param>
		void Invalidate(object obj);

        /// <summary>
        /// Invalidates an object, marking its properties as NotLoaded and discarding the original property values.
        /// </summary>
        /// <param name="obj">The object to invalidate</param>
        /// <param name="invalidateDirty">Set to true if you want to invalidate Dirty properties in addition to Clean ones.</param>
        void Invalidate(object obj, bool invalidateDirty);

        /// <summary>
        /// Invalidates a property of an object, marking it as NotLoaded and discarding the original property value.
        /// </summary>
        /// <remarks>
        /// Identity properties can not be invalidated.
        /// </remarks>
        /// <param name="obj">The object with the property to invalidate</param>
        /// <param name="propertyName">The name of the property to invalidate</param>
		void Invalidate(object obj, string propertyName);

        /// <summary>
        /// Invalidates a property of an object, marking it as NotLoaded and discarding the original property value.
        /// </summary>
        /// <remarks>
        /// Identity properties can not be invalidated.
        /// </remarks>
        /// <param name="obj">The object with the property to invalidate</param>
        /// <param name="propertyName">The name of the property to invalidate</param>
        /// <param name="invalidateDirty">Set to true if you want to invalidate Dirty properties in addition to Clean ones.</param>
        void Invalidate(object obj, string propertyName, bool invalidateDirty);

        /// <summary>
        /// Clears all objects from the cache. 
        /// </summary>
        /// <remarks>
        /// This method clears the object cache and empties the unit of work. It also clears 
        /// cached actions from the inverse manager and any batched sql statements from the sql executor.<br></br><br></br>
        /// Please note that after calling Clear() on a context, all objects from that context must be regarded
        /// as dettached and will not be able to lazy load, dirty track and so on until you attach them to another 
        /// context. Normally you only use clear if you have released all references to the objects that were brought up by the
        /// context and you want to start fresh without having to create a new context.
        /// </remarks> 
        void Clear();

        /// <summary>
        /// Adds a general observer that will observe both context events and object events on all objects of all types in the context.
        /// </summary>
        /// <param name="observer">The observer</param>
		void AddObserver(IObserver observer);

        /// <summary>
        /// Adds an observer that will observe either context events or object events on all objects of all types in the context.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="observerTarget">The observer target.</param>
		void AddObserver(IObserver observer, ObserverTarget observerTarget);

        /// <summary>
        /// Adds an observer that will observe object events on all objects of the specified type in the context.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="type">The type to be observed.</param>
		void AddObserver(IObserver observer, Type type);

        /// <summary>
        /// Adds an observer that will observe object events on the specified object.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="obj">The object to be observed.</param>
		void AddObserver(IObserver observer, object obj);

        /// <summary>
        /// Adds an observer that will observe object events on the specified targets (types and/or objects).
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="targets">The targets to be observed.</param>
		void AddObserver(IObserver observer, params object[] targets);

        /// <summary>
        /// Gets all observers registered with the context.
        /// </summary>
        /// <returns></returns>
		IList GetAllObservers();

        /// <summary>
        /// Gets the general observers.
        /// </summary>
        /// <returns></returns>
		IList GetObservers();

        /// <summary>
        /// Gets the observers that are observing either context or object events on all objects of all types.
        /// </summary>
        /// <returns></returns>
		IList GetObservers(ObserverTarget observerTarget);

        /// <summary>
        /// Gets the observers observing object events on all objects of the specified type.
        /// </summary>
		IList GetObservers(Type type);

        /// <summary>
        /// Gets the observers observing object events on the specified object.
        /// </summary>
		IList GetObservers(object obj);

        /// <summary>
        /// Gets the connection to the default data source.
        /// </summary>
        /// <returns></returns>
		IDbConnection GetConnection();

        /// <summary>
        /// Gets the connection to the specified data source.
        /// </summary>
        /// <param name="sourceName">The name of the data source</param>
        /// <returns></returns>
		IDbConnection GetConnection(string sourceName);

        /// <summary>
        /// Gets the connection to the specified data source.
        /// </summary>
        /// <param name="sourceMap">The source map representing the data source.</param>
        /// <returns></returns>
		IDbConnection GetConnection(ISourceMap sourceMap);

        /// <summary>
        /// Sets the connection to the default data source.
        /// </summary>
        /// <param name="value">The connection.</param>
		void SetConnection(IDbConnection value);

        /// <summary>
        /// Sets the connection to the specified data source.
        /// </summary>
        /// <param name="value">The connection.</param>
        /// <param name="sourceName">The name of the data source</param>
		void SetConnection(IDbConnection value, string sourceName);

        /// <summary>
        /// Sets the connection to the specified data source.
        /// </summary>
        /// <param name="value">The connection.</param>
        /// <param name="sourceMap">The source map representing the data source.</param>
		void SetConnection(IDbConnection value, ISourceMap sourceMap);

        /// <summary>
        /// Gets the connection string to the default data source.
        /// </summary>
		string GetConnectionString();

        /// <summary>
        /// Gets the connection string to the specified data source.
        /// </summary>
        /// <param name="sourceName">The name of the data source</param>
        /// <returns></returns>
		string GetConnectionString(string sourceName);

        /// <summary>
        /// Gets the connection string to the specified data source.
        /// </summary>
        /// <param name="sourceMap">The source map representing the data source.</param>
        /// <returns></returns>
		string GetConnectionString(ISourceMap sourceMap);


        /// <summary>
        /// Sets the connection string to the default data source.
        /// </summary>
        /// <param name="value">The connection string.</param>
		void SetConnectionString(string value);

        /// <summary>
        /// Sets the connection string to the specified data source.
        /// </summary>
        /// <param name="value">The connection string.</param>
        /// <param name="sourceName">The name of the data source</param>
		void SetConnectionString(string value, string sourceName);

        /// <summary>
        /// Sets the connection string to the specified data source.
        /// </summary>
        /// <param name="value">The connection string.</param>
        /// <param name="sourceMap">The source map representing the data source.</param>
		void SetConnectionString(string value, ISourceMap sourceMap);

        /// <summary>
        /// Gets the default data source.
        /// </summary>
        /// <returns></returns>
		IDataSource GetDataSource();

        /// <summary>
        /// Gets the data source with the specified name.
        /// </summary>
        /// <param name="sourceName">The name of the data source.</param>
        /// <returns></returns>
		IDataSource GetDataSource(string sourceName);

        /// <summary>
        /// Gets the data source represented by the source map.
        /// </summary>
        /// <param name="sourceMap">The source map representing the data source.</param>
        /// <returns></returns>
		IDataSource GetDataSource(ISourceMap sourceMap);

        /// <summary>
        /// Gets the source map representing the default data source.
        /// </summary>
		ISourceMap GetSourceMap();

        /// <summary>
        /// Gets the source map representing the data source with the specified name.
        /// </summary>
        /// <param name="sourceName">The name of the data source.</param>
		ISourceMap GetSourceMap(string sourceName);

        /// <summary>
        /// Begins a transaction using the specified iolation level. 
        /// </summary>
        /// <param name="iso">The transaction isolation level.</param>
        /// <returns></returns>
		ITransaction BeginTransaction(IsolationLevel iso);

        /// <summary>
        /// Begins a transaction.
        /// </summary>
        /// <param name="commitTransactionOnCommittingContext">if set to <c>true</c> (default) the transaction will be automatically committed if the Commit() method on the context is called.</param>
        /// <returns></returns>
		ITransaction BeginTransaction(bool commitTransactionOnCommittingContext);

        /// <summary>
        /// Begins a transaction using the specified iolation level. 
        /// </summary>
        /// <param name="iso">The transaction isolation level.</param>
        /// <param name="commitTransactionOnCommittingContext">if set to <c>true</c> (default) the transaction will be automatically committed if the Commit() method on the context is called.</param>
		ITransaction BeginTransaction(IsolationLevel iso, bool commitTransactionOnCommittingContext);

        /// <summary>
        /// Begins a transaction on the specified data source.
        /// </summary>
        /// <param name="dataSource">The data source to start a transaction on.</param>
        /// <returns></returns>
		ITransaction BeginTransaction(IDataSource dataSource);

        /// <summary>
        /// Begins a transaction on the specified data source using the specified iolation level. 
        /// </summary>
        /// <param name="dataSource">The data source to start a transaction on.</param>
        /// <param name="iso">The transaction isolation level.</param>
        /// <returns></returns>
		ITransaction BeginTransaction(IDataSource dataSource, IsolationLevel iso);

        /// <summary>
        /// Begins a transaction on the specified data source. 
        /// </summary>
        /// <param name="dataSource">The data source to start a transaction on.</param>
        /// <param name="commitTransactionOnCommittingContext">if set to <c>true</c> (default) the transaction will be automatically committed if the Commit() method on the context is called.</param>
        /// <returns></returns>
		ITransaction BeginTransaction(IDataSource dataSource, bool commitTransactionOnCommittingContext);

        /// <summary>
        /// Begins a transaction on the specified data source using the specified iolation level. 
        /// </summary>
        /// <param name="dataSource">The data source to start a transaction on.</param>
        /// <param name="iso">The transaction isolation level.</param>
        /// <param name="commitTransactionOnCommittingContext">if set to <c>true</c> (default) the transaction will be automatically committed if the Commit() method on the context is called.</param>
		ITransaction BeginTransaction(IDataSource dataSource, IsolationLevel iso, bool commitTransactionOnCommittingContext);

        /// <summary>
        /// Determines whether the specified data source has a transaction pending.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <returns>
        /// 	<c>true</c> if the specified data source has a pending transaction; otherwise, <c>false</c>.
        /// </returns>
		bool HasTransactionPending(IDataSource dataSource);

        /// <summary>
        /// Determines whether the context has a transaction pending.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if the context has pending transaction; otherwise, <c>false</c>.
        /// </returns>
		bool HasTransactionPending();

        /// <summary>
        /// This method is always called by the transaction when it has completed. The developer should normally not make any calls to this method.
        /// </summary>
        /// <param name="transaction">The transaction that has completed.</param>
		void OnTransactionComplete(ITransaction transaction);

        /// <summary>
        /// Gets the transaction for the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <returns></returns>
		ITransaction GetTransaction(IDbConnection connection);

        /// <summary>
        /// Sets the transaction for the specified connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="transaction">The transaction.</param>
		void SetTransaction(IDbConnection connection, ITransaction transaction);

        /// <summary>
        /// Attaches an object to this context.
        /// </summary>
        /// <param name="obj">The object to be attached.</param>
        /// <returns>The attached object. If the object already existed in the context that existing reference will be returned.</returns>
		object AttachObject(object obj);

        /// <summary>
        /// Attaches an object to this context.
        /// </summary>
        /// <param name="obj">The object to be attached.</param>
        /// <param name="mergeBehavior">The merge behavior to be used if the object already exists in the cache and has different values.</param>
        /// <returns>The attached object. If the object already existed in the context that existing reference will be returned.</returns>
		object AttachObject(object obj, MergeBehaviorType mergeBehavior);

        /// <summary>
        /// Attaches a list of objects to this context.
        /// </summary>
        /// <param name="objects">The objects to be attached.</param>
        /// <returns>The attached objects. If an object already existed in the context that existing reference will be returned in the list.</returns>
		IList AttachObjects(IList objects);

        /// <summary>
        /// Attaches a list of objects to this context.
        /// </summary>
        /// <param name="objects">The objects to be attached.</param>
        /// <param name="mergeBehavior">The merge behavior to be used if an object already exists in the cache and has different values.</param>
        /// <returns>The attached objects. If an object already existed in the context that existing reference will be returned in the list.</returns>
		IList AttachObjects(IList objects, MergeBehaviorType mergeBehavior);

        /// <summary>
        /// Gets the identity generator with the specified name.
        /// </summary>
        /// <param name="name">The name of the identity generator.</param>
        /// <returns></returns>
		IIdentityGenerator GetIdentityGenerator(string name);

        /// <summary>
        /// Gets or sets the default optimistic concurrency mode.
        /// </summary>
        /// <value>The optimistic concurrency mode.</value>
		OptimisticConcurrencyMode OptimisticConcurrencyMode { get; set; }

        /// <summary>
        /// Gets the identity generators.
        /// </summary>
        /// <value>The identity generators.</value>
		Hashtable IdentityGenerators { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
		bool IsDisposed { get; }

        /// <summary>
        /// Gets a value indicating whether this context is dirty (contains unsaved changes).
        /// </summary>
        /// <value><c>true</c> if this context is dirty; otherwise, <c>false</c>.</value>
		bool IsDirty { get; }

        /// <summary>
        /// Gets a value indicating whether this context is in editing mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this context is in editing mode; otherwise, <c>false</c>.
        /// </value>
		bool IsEditing { get; }

        /// <summary>
        /// Begins the editing mode. Changes made during editing mode can be cancled or accepted wholesale when the editing session is done.
        /// </summary>
		void BeginEdit();

        /// <summary>
        /// Cancels the editing mode, discarding all changes that were made during the editing session.
        /// </summary>
		void CancelEdit();

        /// <summary>
        /// Ends the editing mode, accepting all changes that were made during the editing session.
        /// </summary>
		void EndEdit();

        /// <summary>
        /// Gets or sets the default validation mode.
        /// </summary>
        /// <value>The validation mode.</value>
		ValidationMode ValidationMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether validation should occur before a commit operation is carried out.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if validation should be carried out before commit; otherwise, <c>false</c>.
        /// </value>
		bool ValidateBeforeCommit { get; set; }

        /// <summary>
        /// Determines whether the cache is currently valid (all the objects in the cache pass validation).
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if the cache is valid; otherwise, <c>false</c>.
        /// </returns>
		bool IsValidCache();

        /// <summary>
        /// Validates all the objects in the cache, breaking (and rethrowing) on the first exception.
        /// </summary>
		void ValidateCache();

        /// <summary>
        /// Validates all the objects in the cache, collecting all validation exceptions in the passed in list.
        /// </summary>
        /// <param name="exceptions">A list that will become filled with any validation exceptions that occur during validation.</param>
		void ValidateCache(IList exceptions);

        /// <summary>
        /// Determines whether the unit of work is currently valid (all the objects in the unit of work pass validation).
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if the unit of work is valid; otherwise, <c>false</c>.
        /// </returns>
		bool IsValidUnitOfWork();

        /// <summary>
        /// Validates all the objects in the unit of work, breaking (and rethrowing) on the first exception.
        /// </summary>
		void ValidateUnitOfWork();

        /// <summary>
        /// Validates all the objects in the unit of work, collecting all validation exceptions in the passed in list.
        /// </summary>
        /// <param name="exceptions">A list that will become filled with any validation exceptions that occur during validation.</param>
		void ValidateUnitOfWork(IList exceptions);

        /// <summary>
        /// Determines whether the object is currently valid (the object passes validation).
        /// </summary>
        /// <param name="obj">The object to be validated</param>
        /// <returns>
        /// 	<c>true</c> if the object is valid; otherwise, <c>false</c>.
        /// </returns>
		bool IsValid(object obj);

        /// <summary>
        /// Determines whether the property of an object is currently valid (the property passes validation).
        /// </summary>
        /// <param name="obj">The object with the property to be validated.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>
        /// 	<c>true</c> if the object is valid; otherwise, <c>false</c>.
        /// </returns>
		bool IsValid(object obj, string propertyName);

		/// <summary>
		/// Validates a list of objects, breaking (and rethrowing) on the first exception.
		/// </summary>
		/// <param name="objects">The list of objects to be validated.</param>
		void ValidateObjects(IList objects);

		/// <summary>
		/// Validates a list of objects, collecting all validation exceptions in the passed in list.
		/// </summary>
		/// <param name="objects">The list of objects to be validated.</param>
		/// <param name="exceptions">A list that will become filled with any validation exceptions that occur during validation.</param>
		void ValidateObjects(IList objects, IList exceptions);

        /// <summary>
        /// Validates an object, breaking (and rethrowing) on the first exception.
        /// </summary>
        /// <param name="obj">The object to be validated</param>
		void ValidateObject(object obj);

        /// <summary>
        /// Validates an object, collecting all validation exceptions in the passed in list.
        /// </summary>
        /// <param name="obj">The object to be validated</param>
        /// <param name="exceptions">A list that will become filled with any validation exceptions that occur during validation.</param>
		void ValidateObject(object obj, IList exceptions);
		
        /// <summary>
        /// Validates the property of an object, breaking (and rethrowing) on the first exception.
        /// </summary>
        /// <param name="obj">The object to be validated</param>
        /// <param name="propertyName">The name of the property.</param>
		void ValidateProperty(object obj, string propertyName);

        /// <summary>
        /// Validates the property of an object, collecting all validation exceptions in the passed in list.
        /// </summary>
        /// <param name="obj">The object to be validated</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="exceptions">A list that will become filled with any validation exceptions that occur during validation.</param>
		void ValidateProperty(object obj, string propertyName, IList exceptions);

        /// <summary>
        /// Constructs an NPathQuery object representing an npath query for loading the passed in object with values from the database.
        /// </summary>
        /// <remarks>
        /// This is really just a utility method used by some of the NPersist methods, but it has been exposed since it might be useful sometimes when creating new framework functionality on top of NPersist.
        /// </remarks>
        /// <param name="obj">The object that should be loaded with values from the database.</param>
        /// <param name="refreshBehavior">The refresh behavior determining what happens if a fresh value from the database conflicts with a value in the cache.</param>
        /// <returns></returns>
		NPathQuery GetLoadObjectNPathQuery(object obj, RefreshBehaviorType refreshBehavior);

        /// <summary>
        /// Constructs an NPathQuery object representing an npath query for loading the passed in object with values from the database.
        /// </summary>
        /// <remarks>
        /// This is really just a utility method used by some of the NPersist methods, but it has been exposed since it might be useful sometimes when creating new framework functionality on top of NPersist.
        /// </remarks>
        /// <param name="obj">The object that should be loaded with values from the database.</param>
        /// <param name="span">The load span indicating related objects that should be loaded together with the main object.</param>
        /// <returns></returns>
		NPathQuery GetLoadObjectNPathQuery(object obj, string span);

        /// <summary>
        /// Constructs an NPathQuery object representing an npath query for loading the passed in object with values from the database.
        /// </summary>
        /// <remarks>
        /// This is really just a utility method used by some of the NPersist methods, but it has been exposed since it might be useful sometimes when creating new framework functionality on top of NPersist.
        /// </remarks>
        /// <param name="obj">The object that should be loaded with values from the database.</param>
        /// <param name="span">The load span indicating related objects that should be loaded together with the main object.</param>
        /// <param name="refreshBehavior">The refresh behavior determining what happens if a fresh value from the database conflicts with a value in the cache.</param>
		NPathQuery GetLoadObjectNPathQuery(object obj, string span, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// The timeout value in milliseconds that specifies how long this context will wait for a lock on the data source
		/// </summary>
		int Timeout { get; set; }


        /// <summary>
        /// Gets the object cache.
        /// </summary>
        /// <returns></returns>
		IObjectCache GetObjectCache();

        /// <summary>
        /// Gets or sets the time to live for objects in the cache. Note: Not implemented yet!
        /// </summary>
        /// <value>The time to live.</value>
		long TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets the time to live behavior for objects in the cache. Note: Not implemented yet!
        /// </summary>
        /// <value>The time to live behavior.</value>
		TimeToLiveBehavior TimeToLiveBehavior { get; set; }

        /// <summary>
        /// Gets or sets the default load behavior.
        /// </summary>
        /// <remarks>The load behavior specifies if objects that are requested by identity (the GetObjectById() method) 
        /// will be loaded lazily or eagerly. With lazy loading (the default) the object (unless it is already in the cache) will
        /// be instantiated and its identity properties will be filled but no call to the database to load the rest of the
        /// values or verify that the identity exists will be made. Only as any of the (non-identity) properties of the object
        /// is accessed will the call be made to the database and the rest of the object will become loaded.</remarks>
        /// <value>The load behavior.</value>
		LoadBehavior LoadBehavior { get; set; }


		/// <summary>
		/// Tries to retrieve an object by its primary identity. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="identity">The identity of the object.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns></returns>
        object TryGetObject(object identity, Type type);

		/// <summary>
		/// Tries to retrieve an object by a query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <remarks>
        /// This overload assumes that the query object is already fully set up with a query string, 
        /// a Type indicating the type of the object to be returned and any parameters needed by the query.
        /// </remarks>
        /// <param name="query">The query specifying the object to be returned.</param>
        /// <returns></returns>
        object TryGetObject(IQuery query);

		/// <summary>
		/// Tries to retrieve an object by a query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="query">The query specifying the object to be returned.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns></returns>
        object TryGetObject(IQuery query, Type type);

		/// <summary>
		/// Tries to retrieve an object by a query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="query">The query specifying the object to be returned.</param>
        /// <param name="type">The type of the object.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <returns></returns>
        object TryGetObject(IQuery query, Type type, IList parameters);

		/// <summary>
		/// Tries to retrieve an object by an <c>NPathQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="npathQuery">The NPath query string.</param>
        /// <param name="type">The type of the object.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
        /// <returns></returns>
        object TryGetObjectByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Tries to retrieve an object by an <c>SqlQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="sqlQuery">The <c>SqlQuery</c> specifying the object to be retrieved.</param>
        /// <returns></returns>
        object TryGetObjectBySql(SqlQuery sqlQuery);

		/// <summary>
		/// Tries to retrieve an object by an <c>SqlQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="sqlQuery">The <c>SqlQuery</c> specifying the object to be retrieved.</param>
        /// <param name="type">The type of the object.</param>
        /// <returns></returns>
        object TryGetObjectBySql(string sqlQuery, Type type);

		/// <summary>
		/// Tries to retrieve an object by an <c>SqlQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="sqlQuery">The <c>SqlQuery</c> specifying the object to be retrieved.</param>
        /// <param name="type">The type of the object.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <returns></returns>
        object TryGetObjectBySql(string sqlQuery, Type type, IList parameters);

		/// <summary>
		/// Tries to retrieve an object by an <c>SqlQuery</c> query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <param name="sqlQuery">The <c>SqlQuery</c> specifying the object to be retrieved.</param>
        /// <param name="type">The type of the object.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
        /// <returns></returns>
        object TryGetObjectBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Tries to retrieve an object by a query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <remarks>
        /// This overload assumes that the query object is already fully set up with a query string, 
        /// a Type indicating the type of the object to be returned and any parameters needed by the query.
        /// </remarks>
        /// <param name="query">The query specifying the object to be returned.</param>
        /// <returns></returns>
        object TryGetObjectByQuery(IQuery query);

		/// <summary>
		/// Retrieves an object by its identity. Throws an exception if the object was not found.
		/// </summary>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and identity.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified identity and type could be found</exception>
        object GetObject(object identity, Type type);

		/// <summary>
		/// Retrieves an object by query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="query">The query specifying the object you want to retrieve.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObject(IQuery query);

		/// <summary>
		/// Retrieves an object by query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="query">The query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObject(IQuery query, Type type);

		/// <summary>
		/// Retrieves an object by query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="query">The query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObject(IQuery query, Type type, IList parameters);


		/// <summary>
		/// Retrieves an object by its identity. Throws an exception if the object was not found.
		/// </summary>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="lazy">Indicates if the object should be lazily or eagerly loaded.</param>
		/// <returns>An object with the specified type and identity.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified identity and type could be found</exception>
        object GetObjectById(object identity, Type type, bool lazy);

		/// <summary>
		/// Retrieves an object by its identity. Throws an exception if the object was not found.
		/// </summary>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>An object with the specified type and identity.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified identity and type could be found</exception>
        object GetObjectById(object identity, Type type, RefreshBehaviorType refreshBehavior); //Note, special handling - needs to be converted into a query!

		/// <summary>
		/// Retrieves an object by query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="query">The query specifying the object you want to retrieve.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObjectByQuery(IQuery query);

		/// <summary>
		/// Retrieves an object by an NPath query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="npathQuery">The query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObjectByNPath(string npathQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);


		/// <summary>
		/// Retrieves an object by sql query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="sqlQuery">The sql query specifying the object you want to retrieve.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query.</exception>
        object GetObjectBySql(SqlQuery sqlQuery);

		/// <summary>
		/// Retrieves an object by sql query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="sqlQuery">The sql query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObjectBySql(string sqlQuery, Type type);

		/// <summary>
		/// Retrieves an object by sql query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="sqlQuery">The sql query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObjectBySql(string sqlQuery, Type type, IList parameters);

		/// <summary>
		/// Retrieves an object by sql query. Throws an exception if the object was not found or more than one object matches the query.
		/// </summary>
        /// <param name="sqlQuery">The sql query specifying the object you want to retrieve.</param>
		/// <param name="type">The type of the object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>An object matching the query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        object GetObjectBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Retrieves a list of objects matching an <c>SqlQuery</c> query
		/// </summary>
		/// <param name="sqlQuery">An <c>SqlQuery</c> object specifying which objects you want to retrieve.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(SqlQuery sqlQuery);

		/// <summary>
		/// Retrieves a list of objects matching an <c>SqlQuery</c> query
		/// </summary>
		/// <param name="sqlQuery">An <c>SqlQuery</c> object specifying which objects you want to retrieve.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results of the query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(SqlQuery sqlQuery, IList listToFill);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList parameters);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="idColumns">The names of the primary key columns.</param>
        /// <param name="typeColumns">The names of the type dicriminator columns (if any).</param>
        /// <param name="propertyColumnMap">Table with property names as keys and column names as values.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="idColumns">The names of the primary key columns.</param>
        /// <param name="typeColumns">The names of the type dicriminator columns (if any).</param>
        /// <param name="propertyColumnMap">Table with property names as keys and column names as values.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters);


		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="idColumns">The names of the primary key columns.</param>
        /// <param name="typeColumns">The names of the type dicriminator columns (if any).</param>
        /// <param name="propertyColumnMap">Table with property names as keys and column names as values.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Retrieves a list of objects matching an sql query
		/// </summary>
        /// <param name="sqlQuery">The sql query string.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="idColumns">The names of the primary key columns.</param>
        /// <param name="typeColumns">The names of the type dicriminator columns (if any).</param>
        /// <param name="propertyColumnMap">Table with property names as keys and column names as values.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results of the query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsBySql(string sqlQuery, Type type, IList idColumns, IList typeColumns, Hashtable propertyColumnMap, IList parameters, RefreshBehaviorType refreshBehavior, IList listToFill);

        /// <summary>
        /// Retrieves all objects of the specified type.
        /// </summary>
        /// <param name="type">The type for which you want to retrieve all objects.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(Type type);

        /// <summary>
        /// Retrieves all objects of the specified type.
        /// </summary>
        /// <param name="type">The type for which you want to retrieve all objects.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(Type type, IList listToFill);

        /// <summary>
        /// Retrieves all objects of the specified type.
        /// </summary>
        /// <param name="type">The type for which you want to retrieve all objects.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(Type type, RefreshBehaviorType refreshBehavior);

        /// <summary>
        /// Retrieves all objects of the specified type.
        /// </summary>
        /// <param name="type">The type for which you want to retrieve all objects.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(Type type, RefreshBehaviorType refreshBehavior, IList listToFill);

		/// <summary>
		/// Retrieves a list of objects matching a query.
		/// </summary>
        /// <param name="query">The query.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(IQuery query, Type type);

		/// <summary>
		/// Retrieves a list of objects matching a query.
		/// </summary>
        /// <param name="query">The query.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(IQuery query, Type type, IList parameters);

		/// <summary>
		/// Retrieves a list of objects matching a query.
		/// </summary>
        /// <param name="query">The query.</param>
        /// <param name="type">The type of the objects to be retrieved.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="refreshBehavior">The refresh behavior.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjects(IQuery query, Type type, IList parameters, RefreshBehaviorType refreshBehavior);

		/// <summary>
		/// Retrieves a list of objects matching a query.
		/// </summary>
        /// <param name="query">The query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsByQuery(IQuery query);

		/// <summary>
		/// Retrieves a list of objects matching a query.
		/// </summary>
        /// <param name="query">The query.</param>
		/// <param name="listToFill">An <c>IList</c> that you want to fill with the results of the query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList GetObjectsByQuery(IQuery query, IList listToFill);

        /// <summary>
        /// Filters a list of objects, returning only those matching the supplied query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="query">The query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(IList objects, NPathQuery query);

        /// <summary>
        /// Filters a list of objects, returning only those matching the supplied query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(IList objects, string npath, Type type);

        /// <summary>
        /// Filters a list of objects, returning only those matching the supplied query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(IList objects, string npath, Type type, IList parameters);

        /// <summary>
        /// Filters the objects in the cache, returning only those matching the supplied query.
        /// </summary>
        /// <param name="query">The npath query.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(NPathQuery query);

        /// <summary>
        /// Filters the objects in the cache, returning those matching the supplied query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(string npath, Type type);

        /// <summary>
        /// Filters the objects in the cache, returning those matching the supplied query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList FilterObjects(string npath, Type type, IList parameters);

        /// <summary>
        /// Filters a list of objects, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="query">The <c>NPathQuery</c> query.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(IList objects, NPathQuery query);

        /// <summary>
        /// Filters a list of objects, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(IList objects, string npath, Type type);


        /// <summary>
        /// Filters a list of objects, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="objects">The list of objects that you want to filter.</param>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(IList objects, string npath, Type type, IList parameters);

        /// <summary>
        /// Filters the objects in the cahce, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="query">The <c>NPathQuery</c> query.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(NPathQuery query);


        /// <summary>
        /// Filters the objects in the cahce, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(string npath, Type type);

        /// <summary>
        /// Filters the objects in the cahce, returning a <c>DataTable</c> with values from the objects matching the NPath query.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable FilterIntoDataTable(string npath, Type type, IList parameters);

        /// <summary>
        /// Retrieves the result of an NPath query in the form of a DataTable.
        /// </summary>
        /// <param name="query">The <c>NPathQuery</c> query.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable GetDataTable(NPathQuery query);

        /// <summary>
        /// Retrieves the result of an NPath query in the form of a DataTable.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable GetDataTable(string npath, Type type);

        /// <summary>
        /// Retrieves the result of an NPath query in the form of a DataTable.
        /// </summary>
        /// <param name="npath">The npath query string.</param>
        /// <param name="type">The type of the objects you want to filter.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>A DataTable holding the values specified in the select clause of the NPath query.</returns>
        DataTable GetDataTable(string npath, Type type, IList parameters);

        /// <summary>
        /// Returns a clone of the list with any unresolved conflict that have resulted from a merge between cached values and fresh values from the data source.
        /// </summary>
        IList Conflicts { get; }

		/// <summary>
		/// Returns a list with any unresolved conflict that have resulted from a merge between cached values and fresh values from the data source. This list can't be iterated over resolving the conflicts since resolving a conflict tries to remove it from the list. For this please use the Conflicts property instead.
		/// </summary>
		IList UnclonedConflicts { get; }

		/// <summary>
		/// Contains all objects (as both keys and values) that were loaded during the latest query fetch operation (for both npath and sql queries)
		/// </summary>
		Hashtable LoadedInLatestQuery { get; set; }

		/// <summary>
		/// Contains all the exceptions that were thrown during the latest commit operation
		/// </summary>
		IList Exceptions { get; }

		/// <summary>
		/// Specifies the read consistency mode. Default means Optimistic.
		/// </summary>
		/// <remarks>
		/// Pessimistic read consistency means a ReadConsistencyException will be thrown if: <br />
		/// 1) An object is created or loaded outside of a transaction. <br />
		/// 2) A property is loaded outside of the transaction that the object that the property belongs to was loaded in. <br />
		/// 3) A property is loaded with a reference to an object that was loaded in another transaction than the transaction that 
		/// the object that the property belongs to was loaded in. <br />
		/// </remarks>
        ConsistencyMode ReadConsistency { get; set; }

		/// <summary>
		/// Specifies the write consistency mode. Default means Optimistic.
		/// </summary>
		/// <remarks>
		/// With Optimistic write consistency, optimistic concurrency is used to enforce write consistency.
		/// With Pessimistic write concurrency, dirty objects may only be saved back to their data source within the same transaction that they were loaded. 
		/// Pessimistic write consistency means a WriteConsistencyException will be thrown if: <br />
		/// 1) An object is created or loaded outside of a transaction. <br />
		/// 2) A property is written to outside of the transaction that the object that the property belongs to was loaded or created in. <br />
		/// 3) A property is written to with a reference to an object that was loaded or created in another transaction than the transaction that 
		/// the object that the property belongs to was loaded or created in. <br />
		/// 4) An object is inserted, updated or removed from the data source in another transaction than
		/// the object that the property belongs to was loaded or created in. <br />
		/// </remarks>
        ConsistencyMode WriteConsistency { get; set; }

        #region .NET 2.0 Specific Code
#if NET2

		/// <summary>
		/// Tries to retrieve an object by its identity. Returns null if the object was not found.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and identity or null if no such object exists.</returns>
        T TryGetObjectById<T> (object identity);

		/// <summary>
		/// Retrieves an object by its identity. Throws an exception if the object was not found.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="identity">The identity of the object you want to retrieve.</param>
		/// <returns>An object with the specified type and identity.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object with the specified identity and type could be found</exception>
        T GetObjectById<T>(object identity);

		/// <summary>
		/// Tries to retrieve an object by an NPath query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <returns>An object matching the NPath query or null if no such object or multiple such objects were found.</returns>
        T TryGetObjectByNPath<T>(string npathQuery);

		/// <summary>
		/// Retrieves an object by an NPath query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        T GetObjectByNPath<T>(string npathQuery);

		/// <summary>
		/// Tries to retrieve an object by an NPath query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the NPath query or null if no such object or multiple such objects were found.</returns>
        T TryGetObjectByNPath<T>(string npathQuery,params QueryParameter[] parameters);

		/// <summary>
		/// Retrieves an object by an NPath query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        T GetObjectByNPath<T>(string npathQuery, params QueryParameter[] parameters);

		/// <summary>
		/// Tries to retrieve an object by an NPath query. Returns null if the object was not found or if more than one object matched the query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the NPath query or null if no such object or multiple such objects were found.</returns>
        T TryGetObjectByNPath<T>(string npathQuery, IList parameters);

		/// <summary>
		/// Retrieves an object by an NPath query.
		/// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
        /// <param name="parameters">The query parameters.</param>
		/// <returns>An object matching the NPath query.</returns>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.ObjectNotFoundException">Thrown when no object matching the query could be found</exception>
		/// <exception cref="Puzzle.NPersist.Framework.Exceptions.MultipleObjectsFoundException">Thrown when more than one object matched the query</exception>
        T GetObjectByNPath<T>(string npathQuery, IList parameters);
        
		/// <summary>
		/// Creates a new object with the specified type, registering it as up for creation. It will be inserted into the data source in the next call to <c>Commit</c>(). 
		/// </summary>
        /// <remarks>
        /// Note that you must set the values of all the identity properties on the object before calling the Commit() method.
        /// </remarks>
        /// <typeparam name="T">The type of the new object.</typeparam>
		/// <param name="ctorArgs">Contructor arguments for the new object</param>
		/// <returns>A new object with the specified type.</returns>
        T CreateObject<T>(params object[] ctorArgs);

        /// <summary>
        /// Retrieves all the objects of the specified type.
        /// </summary>
        /// <typeparam name="T">The type for which you want to retrieve all objects.</typeparam>
        /// <returns>All objects of the specified type.</returns>
        IList<T> GetObjects<T>();

        /// <summary>
		/// Registers an object as up for deletion. The object will be removed from the data source on the next call to <c>Commit</c>().
        /// </summary>
        /// <typeparam name="T">The type of the object you want to delete</typeparam>
        /// <param name="identity">The identity of the object you want to delete</param>
        void DeleteObject<T>(object identity);

		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
        /// <typeparam name="T">The type of the objects you want to retrieve.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList<T> GetObjectsByNPath<T>(string npathQuery, params QueryParameter[] parameters);

		/// <summary>
		/// Retrieves a list of objects matching an <c>NPathQuery</c> query
		/// </summary>
        /// <typeparam name="T">The type of the objects you want to retrieve.</typeparam>
		/// <param name="npathQuery">The NPath query string specifying which object you want to retrieve.</param>
		/// <param name="parameters">The query parameters.</param>
		/// <returns>A list of objects matching the query</returns>
        IList<T> GetObjectsByNPath<T>(string npathQuery, IList parameters);

        T[] GetArrayByNPath<T>(string npathQuery);
        T[] GetArrayByNPath<T>(string npathQuery, params QueryParameter[] parameters);
        T[] GetArrayByNPath<T>(string npathQuery, IList parameters);

        IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery);
        IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery, params QueryParameter[] parameters);
        IList<snapT> GetSnapshotObjectsByNPath<snapT, sourceT>(string npathQuery, IList parameters);
 
#endif
        #endregion
    }
}
