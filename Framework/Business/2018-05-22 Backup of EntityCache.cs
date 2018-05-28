//using System;
//using System.Collections.Generic;
//using JJ.Framework.Data;

//namespace JJ.Framework.Business
//{
//	public class EntityCache<TEntity, TID, TAlternativeKey>
//	{
//		private readonly Dictionary<TAlternativeKey, TEntity> _dictionary = new Dictionary<TAlternativeKey, TEntity>();
//		private readonly IRepository<TEntity, TID> _repository;

//		public EntityCache(IRepository<TEntity, TID> repository)
//		{
//			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
//		}

//	}
//}
