using System;
using System.Linq;

using Cerseil.Logging;

namespace Cerseil.Data
{
    public abstract class DataContextBase : IDataContext
    {
        protected DataContextBase()
        {
            if (Logger == null)
            {
                Logger = LoggerFactory.GetLoggerInstance();
            }
        }

        public ILogger Logger { get; private set; }

        public CerseilException LastException { get; protected set; }

        public virtual TDataEntity Add<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual TDataEntity Update<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual TDataEntity Remove<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TDataEntity> GetTable<TDataEntity>() where TDataEntity : DataEntity, new()
        {
            throw new NotImplementedException();
        }

        public virtual int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
