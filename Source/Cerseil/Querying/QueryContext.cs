using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Cerseil.Data;

namespace Cerseil.Querying
{
    public class QueryContext<TDataEntity> : IQueryContext, IQueryContext<TDataEntity> where TDataEntity : DataEntity, new()
    {
        public QueryContext()
        {
            Repository = GetRepository();

            DataEntityType = typeof(TDataEntity);
        }

        public IRepository<TDataEntity> Repository { get; private set; }

        public Type DataEntityType { get; private set; }

        public TDataEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public TDataEntity Get(Expression<Func<TDataEntity, bool>> where)
        {
            return Repository.Get(where);
        }

        public IEnumerable<TDataEntity> GetAll()
        {
            return Repository.Table.AsEnumerable<TDataEntity>();
        }

        public IEnumerable<TDataEntity> GetAll(Expression<Func<TDataEntity, bool>> where)
        {
            return Repository.Table.Where(where).AsEnumerable<TDataEntity>();
        }

        public IEnumerable<TDataEntity> GetAll(int pageIndex, int pageSize)
        {
            return Repository.Table.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IEnumerable<TDataEntity> GetAll(Expression<Func<TDataEntity, bool>> where, int pageIndex, int pageSize)
        {
            return Repository.Table.Where(where).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public int GetCount()
        {
            return Repository.Table.Count();
        }

        public int GetCount(Expression<Func<TDataEntity, bool>> where)
        {
            return Repository.Table.Where(where).Count();
        }

        public IRepository<TDataEntity> GetRepository()
        {
            return DependencyManager.Current.Resolver.GetService<IRepository<TDataEntity>>();
        }
    }
}
