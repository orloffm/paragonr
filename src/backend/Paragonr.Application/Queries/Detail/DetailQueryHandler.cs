using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Infrastructure;
using Paragonr.Application.Queries.List;
using Paragonr.Entities;

namespace Paragonr.Application.Queries.Detail
{
    public abstract class DetailQueryHandler<TEntity, TDto> : IRequestHandler<DetailQuery<TDto>, DetailResult<TDto>>
        where TEntity : EntityBase where TDto : EntityBaseDto
    {
        private readonly IMapper _mapper;

        protected DetailQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected abstract DbSet<TEntity> EntityDbSet { get; }

        public async Task<DetailResult<TDto>> Handle(DetailQuery<TDto> request, CancellationToken cancellationToken)
        {
            TEntity entity = await EntityDbSet.FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception($"Entity {request.Id} of type {typeof(TDto).Name} was not found.");
            }

            var dto = _mapper.Map<TDto>(entity);
            return new DetailResult<TDto>(dto);
        }
    }
}