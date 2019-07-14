using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Queries.List;
using Paragonr.Entities;

namespace Paragonr.Application.Currencies.Queries
{
    public sealed class CurrencyDetailHandler : IRequestHandler<CurrencyQuery, CurrencyResult>
    {
        private readonly IBudgetDbContext _context;
        private readonly IMapper _mapper;

        public CurrencyDetailHandler(IBudgetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CurrencyResult> Handle(CurrencyQuery request, CancellationToken cancellationToken)
        {
            Currency entity = await _context.Currencies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception($"Currency {request.Id} was not found.");
            }

            var dto = _mapper.Map<CurrencyDto>(entity);
            return new CurrencyResult(dto);
        }
    }
}