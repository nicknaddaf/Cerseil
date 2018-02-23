using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Cerseil.Data;

namespace Cerseil.Querying
{
    public interface IQueryContext
    {

    }

    public interface IQueryContext<TDataEntity> : IQueryContext where TDataEntity : DataEntity, new()
    {
        IRepository<TDataEntity> Repository { get; }

        Type DataEntityType { get; }

        TDataEntity GetById(Guid id);

        TDataEntity Get(Expression<Func<TDataEntity, bool>> where);

        IEnumerable<TDataEntity> GetAll();

        IEnumerable<TDataEntity> GetAll(int pageIndex, int pageSize);

        IEnumerable<TDataEntity> GetAll(Expression<Func<TDataEntity, bool>> where);

        IEnumerable<TDataEntity> GetAll(Expression<Func<TDataEntity, bool>> where, int pageIndex, int pageSize);

        int GetCount();

        int GetCount(Expression<Func<TDataEntity, bool>> where);

        IRepository<TDataEntity> GetRepository();
    }
}
