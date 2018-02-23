using System;
using System.Linq;
using System.Linq.Expressions;

using Cerseil.Logging;

namespace Cerseil.Data
{
    public interface IRepository
    {
        IDataContext DataContext { get; }

        ILogger Logger { get; }

        CerseilException LastException { get; }
    }

    public interface IRepository<TDataEntity> : IRepository where TDataEntity : DataEntity
    {
        IQueryable<TDataEntity> Table { get; }

        bool Create(TDataEntity dataEntity);

        bool Update(TDataEntity dataEntity);

        bool Delete(TDataEntity dataEntity);

        bool Delete(Expression<Func<TDataEntity, bool>> where);

        TDataEntity GetById(Guid id);

        TDataEntity Get(Expression<Func<TDataEntity, bool>> where);
    }
}
