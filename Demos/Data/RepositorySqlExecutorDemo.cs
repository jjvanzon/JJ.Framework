using System;
using System.Collections.Generic;
using System.Linq;
using JJ.Demos.Data.Sql;
using JJ.Framework.Data;
using JJ.Framework.Data.NHibernate;
using JJ.Framework.Data.SqlClient;
using NHibernate;

// ReSharper disable ClassWithVirtualMembersNeverInherited.Global
// ReSharper disable ArrangeConstructorOrDestructorBody
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable ArrangeTypeModifiers

namespace JJ.Demos.Data
{
    class MyEntity
    {
        public virtual int ID { get; set; }
    }

    interface IMyRepository : IRepository<MyEntity, int>
    {
        IList<MyEntity> GetManyByCriteria(
            int? categoryID = null,
            int? kind = null,
            DateTime? minStartDate = null);
    }

    class MyRepository : RepositoryBase<MyEntity, int>, IMyRepository
    {
        private MySqlExecutor _mySqlExecutor;

        public IList<MyEntity> GetManyByCriteria(
            int? categoryID = null,
            int? kind = null,
            DateTime? minStartDate = null)
        {
            var ids = _mySqlExecutor.MyEntity_GetIDsByCriteria(
                categoryID, kind, minStartDate);

            var entities = ids.Select(Get);

            return entities.ToArray();
        }

        public MyRepository(IContext context) : base(context)
        {
            var context2 = (NHibernateContext)context;
            _mySqlExecutor = new MySqlExecutor(context2.Session);
        }
    }

    class MySqlExecutor
    {
        private ISqlExecutor _sqlExecutor;

        public IEnumerable<int> MyEntity_GetIDsByCriteria(
            int? categoryID = null,
            int? kind = null,
            DateTime? minStartDate = null)
            => _sqlExecutor.ExecuteReader<int>(
                SqlEnum.MyEntity_GetIDsByCriteria,
                new { categoryID, kind, minStartDate });

        public MySqlExecutor(ISession session)
            => _sqlExecutor = new NHibernateSqlExecutor(session);
    }
}
