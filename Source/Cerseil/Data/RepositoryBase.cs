using System;
using System.Linq;
using System.Linq.Expressions;

using Cerseil.Logging;

namespace Cerseil.Data
{
    public abstract class RepositoryBase<TDataEntity> : IRepository<TDataEntity> where TDataEntity : DataEntity, new()
    {
        protected RepositoryBase()
        {
            DataContext = DependencyManager.Current.Resolver.GetService<IDataContext>();

            Logger = LoggerFactory.GetLoggerInstance();
        }

        public IDataContext DataContext { get; private set; }

        public ILogger Logger { get; private set; }

        public CerseilException LastException { get; private set; }

        public IQueryable<TDataEntity> Table 
        {
            get
            {
                if (DataContext != null)
                {
                    return DataContext.GetTable<TDataEntity>();
                }

                return null;
            }
        }

        public bool Create(TDataEntity dataEntity)
        {
            var result = false;

            if (dataEntity == null)
            {
                throw new DataEntityIsNullException<TDataEntity>();
            }

            if (DataContext.Add(dataEntity) != null)
            {
                result = true;
            }

            LastException = DataContext.LastException;

            return result;
        }

        public bool Update(TDataEntity dataEntity)
        {
            var result = false;

            if (dataEntity == null)
            {
                throw new DataEntityIsNullException<TDataEntity>();
            }

            if (DataContext.Update(dataEntity) != null)
            {
                result = true;
            }

            LastException = DataContext.LastException;

            return result;
        }

        public bool Delete(TDataEntity dataEntity)
        {
            var result = false;

            if (dataEntity == null)
            {
                throw new DataEntityIsNullException<TDataEntity>();
            }

            DataContext.Remove(dataEntity);

            result = (DataContext.SaveChanges() > 0);

            LastException = DataContext.LastException;

            return result;
        }

        public bool Delete(Expression<Func<TDataEntity, bool>> where)
        {
            var result = false;

            var objects = Table.Where<TDataEntity>(where).AsEnumerable();

            foreach (var dataEntity in objects)
            {
                DataContext.Remove(dataEntity);
            }

            result = (DataContext.SaveChanges() > 0);

            LastException = DataContext.LastException;

            return result;
        }

        public TDataEntity GetById(Guid id)
        {
            return Table.FirstOrDefault(x => x.Id == id);
        }

        public TDataEntity Get(Expression<Func<TDataEntity, bool>> where)
        {
            return Table.Where(where).FirstOrDefault<TDataEntity>();
        }
    }
}
