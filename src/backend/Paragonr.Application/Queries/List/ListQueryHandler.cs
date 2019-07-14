using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Infrastructure;
using Paragonr.Entities;

namespace Paragonr.Application.Queries.List
{
    public abstract class ListQueryHandler<TEntity, TDto> : IRequestHandler<ListQuery<TDto>, ListResult<TDto>>
        where TEntity : EntityBase where TDto : EntityBaseDto
    {
        private readonly IMapper _mapper;

        protected ListQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected abstract DbSet<TEntity> EntityDbSet { get; }

        public async Task<ListResult<TDto>> Handle(ListQuery<TDto> request, CancellationToken cancellationToken)
        {
            return new ListResult<TDto>
            {
                Items = await EntityDbSet.ProjectTo<TDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}