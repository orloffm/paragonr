using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Paragonr.Tools.Mapping.Extensions
{
    public static class ProjectionsExtensions
    {
        public static async Task<TDto[]> ProjectAsync<TEntity, TDto>(
            this IQueryable<TEntity> source,
            IConfigurationProvider provider,
            CancellationToken? token = null
        )
        {
            return await source.ProjectTo<TDto>(provider)
                .ToArrayAsync(token ?? CancellationToken.None);
        }
    }
}
