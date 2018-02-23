using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

using Cerseil.Logging;

namespace Cerseil.Data
{
    public abstract class EntityFrameworkDataContext : DbContext, IDataContext
    {
        protected EntityFrameworkDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            if (Logger == null)
            {
                Logger = LoggerFactory.GetLoggerInstance();
            }
        }

        public ILogger Logger { get; private set; }

        public CerseilException LastException { get; private set; }

        public TDataEntity Add<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            if (dataEntity == null)
            {
                throw new ArgumentNullException("dataEntity");
            }

            IDbSet<TDataEntity> dbSet = this.Set<TDataEntity>();

            dbSet.Add(dataEntity);

            return SaveChanges() > 0 ? dataEntity : null;
        }

        public TDataEntity Update<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            if (dataEntity == null)
            {
                throw new ArgumentNullException("dataEntity");
            }

            IDbSet<TDataEntity> dbSet = this.Set<TDataEntity>();
            
            var local = dbSet.Local.FirstOrDefault(x => x.Id == dataEntity.Id);
            if (local != null && Entry(local).State == EntityState.Unchanged)
            {
                Entry(local).State = EntityState.Detached;
            }

            dbSet.Attach(dataEntity);
            Entry(dataEntity).State = EntityState.Modified;

            return SaveChanges() > 0 ? dataEntity : null;
        }

        public TDataEntity Remove<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity, new()
        {
            if (dataEntity == null)
            {
                throw new ArgumentNullException("dataEntity");
            }

            IDbSet<TDataEntity> dbSet = this.Set<TDataEntity>();

            var local = dbSet.Local.FirstOrDefault(x => x.Id == dataEntity.Id);
            if (local != null && Entry(local).State == EntityState.Unchanged)
            {
                Entry(local).State = EntityState.Detached;
            }

            dbSet.Attach(dataEntity);

            dbSet.Remove(dataEntity);

            return SaveChanges() > 0 ? dataEntity : null;
        }

        public IQueryable<TDataEntity> GetTable<TDataEntity>() where TDataEntity : DataEntity, new()
        {
            return Set<TDataEntity>();
        }

        public override int SaveChanges()
        {
            int result;
            var message = string.Empty;

            try
            {
                // Need to add some extar actions that should be done before call the SaveChanges in the base class
                result = base.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                message = "An error of DbUpdateException has occured  in the DbContextBase.SaveChanges method!";

                LastException = new CerseilException(message, exception);

                Logger.Error(exception);

                throw LastException;
            }
            catch (NotSupportedException exception)
            {
                message = "An error of NotSupportedException has occured  in the DbContextBase.SaveChanges method!";

                LastException = new CerseilException(message, exception);

                Logger.Error(exception);

                throw LastException;
            }
            catch (DbEntityValidationException exception)
            {
                foreach (var validationErrors in exception.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        message += string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                LastException = new CerseilException(message, exception);

                Logger.Error(exception);

                throw LastException;
            }

            return result;
        }
    }
}
