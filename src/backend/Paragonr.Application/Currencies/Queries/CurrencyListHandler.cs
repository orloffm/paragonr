using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Queries.List;

namespace Paragonr.Application.Currencies.Queries
{
    public sealed class CurrencyListQueryHandler : IRequestHandler<CurrencyListQuery, CurrencyListResult>
    {
        private readonly IBudgetDbContext _context;
        private readonly IMapper _mapper;

        public CurrencyListQueryHandler(IBudgetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CurrencyListResult> Handle(CurrencyListQuery request, CancellationToken cancellationToken)
        {
            List<CurrencyDto> items = await _context.Currencies.ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CurrencyListResult(items);
        }
    }
}