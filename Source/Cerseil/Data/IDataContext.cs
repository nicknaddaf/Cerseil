using System.Linq;

using Cerseil.Logging;

namespace Cerseil.Data
{
    public interface IDataContext
    {
        ILogger Logger { get; }

        CerseilException LastException { get; }

        TDataEntity Add<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        TDataEntity Update<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        TDataEntity Remove<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new();

        IQueryable<TDataEntity> GetTable<TDataEntity>() where TDataEntity : DataEntity, new();

        int SaveChanges();
    }
}
