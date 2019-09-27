using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Paragonr.Tools.EntityFramework
{
    public static class DbSetExtensions
    {
        public static long GetIdBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity
        {
            return dbSet.Where(predicate)
                .Select(i => i.Id)
                .Single();
        }
    }
}
