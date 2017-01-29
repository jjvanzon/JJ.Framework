using NHibernate.Hql.Util;
using NHibernate.Persister.Collection;
using NHibernate.Persister.Entity;
using NHibernate.Type;

namespace NHibernate.Loader.Criteria
{
	public class ScalarCollectionCriteriaInfoProvider : ICriteriaInfoProvider
	{
		private readonly string role;
		private readonly IQueryableCollection persister;
		private readonly SessionFactoryHelper helper;
		public ScalarCollectionCriteriaInfoProvider(SessionFactoryHelper helper, string role)
		{
			this.role = role;
			this.helper = helper;
			this.persister = helper.RequireQueryableCollection(role);
		}

		public string Name
		{
			get
			{
				return role;
			}
		}

		public string[] Spaces
		{
			get
			{
				return persister.CollectionSpaces;
			}
		}

		public IPropertyMapping PropertyMapping
		{
			get
			{
				return helper.GetCollectionPropertyMapping(role);
			}
		}

		public IType GetType(string relativePath)
		{
			//not sure what things are going to be passed here, how about 'id', maybe 'index' or 'key' or 'elements' ???
			return PropertyMapping.ToType(relativePath);
		}

	}
}