using System;
using System.Collections.Generic;
using System.Linq;

using Cerseil.Data;

namespace Cerseil.Querying
{
    public static class QueryContextFactory
    {
        static QueryContextFactory()
        {
            QueryContextList = new List<IQueryContext>();
        }

        public static IQueryContext<TDataEntity> GetQueryContext<TDataEntity>() where TDataEntity : DataEntity, new()
        {
            var queryContextGeneric = default(IQueryContext<TDataEntity>);

            var queryContext = QueryContextList.FirstOrDefault(x => x.GetType() == typeof(IQueryContext<TDataEntity>));

            if (queryContext == null)
            {
                queryContextGeneric = new QueryContext<TDataEntity>();

                QueryContextList.Add(queryContextGeneric);
            }
            else
            {
                queryContextGeneric = queryContext as IQueryContext<TDataEntity>;
            }

            return queryContextGeneric;
        }

        public static List<IQueryContext> QueryContextList { get; private set; }
    }
}
