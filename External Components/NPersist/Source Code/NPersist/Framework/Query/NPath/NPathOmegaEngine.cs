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
using Puzzle.NPersist.Framework.BaseClasses;
using Puzzle.NPersist.Framework.Mapping;
using Puzzle.NPath.Framework;
using Puzzle.NPath.Framework.CodeDom;
using Puzzle.NPersist.Framework.NPath.Sql;
using Puzzle.NPersist.Framework.Querying;

namespace Puzzle.NPersist.Framework.NPath
{
	public class NPathOmegaEngine : ContextChild, INPathEngine
	{

		public virtual string ToSql(string npath, Type type, ref Hashtable propertyColumnMap)
		{
			IList parameters = new ArrayList() ;
			return ToSql(npath, type, ref propertyColumnMap, ref parameters, new ArrayList());
		}

		public virtual string ToScalarSql(string npath, Type type)
		{
			IList parameters = new ArrayList() ;
			return ToScalarSql(npath, type, ref parameters, new ArrayList());
		}

		public virtual string ToSql(string npath, Type type, ref Hashtable propertyColumnMap, ref IList outParameters)
		{
			return ToSql(npath, type, ref propertyColumnMap, ref outParameters, new ArrayList() );
		}

		public virtual string ToScalarSql(string npath, Type type, ref IList outParameters)
		{
			return ToScalarSql(npath, type, ref outParameters, new ArrayList() );
		}

		public virtual string ToSql(string npath, Type type, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters)
		{
			NPathQueryType queryType = GetNPathQueryType(npath);
			return ToSql (npath,queryType,type,ref propertyColumnMap,ref outParameters,inParameters);
		}

		public virtual string ToSql(string npath,NPathQueryType queryType, Type type, ref Hashtable propertyColumnMap, ref IList outParameters, IList inParameters)
		{
			NPathParser parser = new NPathParser() ;
			NPathSelectQuery query = parser.ParseSelectQuery(npath, inParameters) ;

			IClassMap rootClassMap = this.Context.DomainMap.MustGetClassMap(type);

            this.ResultParameters = new ArrayList();

			SqlEmitter sqlEmitter = new SqlEmitter(this, query,queryType, rootClassMap, propertyColumnMap);

			string sql = sqlEmitter.EmitSql();

			outParameters = sqlEmitter.ResultParameters;

			return sql;
		}

		public virtual string ToScalarSql(string npath, Type type, ref IList outParameters, IList inParameters)
		{
			NPathParser parser = new NPathParser() ;
			NPathSelectQuery query = parser.ParseSelectQuery(npath, inParameters) ;

			IClassMap rootClassMap = this.Context.DomainMap.MustGetClassMap(type);

            this.ResultParameters = new ArrayList();

			SqlEmitter sqlEmitter = new SqlEmitter(this, query,NPathQueryType.SelectScalar, rootClassMap);

			string sql = sqlEmitter.EmitSql();

			outParameters = sqlEmitter.ResultParameters;

			return sql;
		}	

		public virtual IClassMap GetRootClassMap(string npath, IDomainMap domainMap)
		{
			NPathParser parser = new NPathParser() ;
			NPathSelectQuery query = parser.ParseSelectQuery(npath) ;

			string className = 	((NPathClassName)query.From.Classes[0]).Name;

			IClassMap rootClassMap = domainMap.MustGetClassMap(className);
			return rootClassMap;
		}

		public virtual NPathQueryType GetNPathQueryType(string npath)
		{
			NPathQueryType npathQueryType = NPathQueryType.SelectObjects;

			try
			{
				NPathParser parser = new NPathParser() ;
				NPathSelectQuery query = parser.ParseSelectQuery(npath) ;

				npathQueryType = GetNPathQueryType(query);				
			} 
			catch
			{
				npathQueryType = NPathQueryType.SelectObjects;
			}

			return npathQueryType;
		}

		private NPathQueryType GetNPathQueryType(NPathSelectQuery query)
		{
			return SqlEmitter.DeduceQueryType(query);
		}

        private IList resultParameters = new ArrayList();

        public IList ResultParameters
        {
            get { return this.resultParameters; }
            set { this.resultParameters = value; }
        }

	}
}