using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Interfaces;

namespace Paragonr.Application.Currencies.Queries.GetCurrenciesList
{
    public sealed class GetCurrenciesListQueryHandler : IRequestHandler<GetCurrenciesListQuery, CurrenciesListViewModel>
    {
        private readonly IBudgetDbContext _context;
        private readonly IMapper _mapper;

        public GetCurrenciesListQueryHandler(IBudgetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CurrenciesListViewModel> Handle(
            GetCurrenciesListQuery request,
            CancellationToken cancellationToken
        )
        {
            return new CurrenciesListViewModel
            {
                Currencies = await _context.Currencies.ProjectTo<CurrencyDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}