using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paragonr.Tools.Domain;

namespace Paragonr.Tools.EntityFramework.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<long> GetIdBy<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity
        {
            return await dbSet.Where(predicate)
                .Select(i => i.Id)
                .SingleAsync();
        }

        public static async Task<TEntity> GetByRefKeyOrDefault<TEntity>(this DbSet<TEntity> dbSet, Guid refKey)
            where TEntity : class, IRefKeyEnabledEntity
        {
            return await dbSet.Where(e => e.RefKey == refKey).SingleOrDefaultAsync();
        }

        public static async Task<TProp?> GetPropertyByIdOrNull<TEntity, TProp>(
            this DbSet<TEntity> dbSet,
            long id,
            Expression<Func<TEntity, TProp>> selector
        ) where TEntity : class, IEntity where TProp : struct
        {
            return await dbSet.Where(e=> e.Id == id)
                .Select(selector)
                .Select(v => (TProp?) v)
                .SingleOrDefaultAsync();
        }

        public static async Task<TProp?> GetPropertyByRefKeyOrNull<TEntity, TProp>(
            this DbSet<TEntity> dbSet,
            Guid refKey,
            Expression<Func<TEntity, TProp>> selector
        ) where TEntity : class, IRefKeyEnabledEntity where TProp : struct
        {
            return await dbSet.Where(e=> e.RefKey == refKey)
                .Select(selector)
                .Select(v => (TProp?) v)
                .SingleOrDefaultAsync();
        }
    }
}
