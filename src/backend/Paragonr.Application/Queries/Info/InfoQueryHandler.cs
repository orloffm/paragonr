using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Dtos;
using Paragonr.Application.Interfaces;
using Paragonr.Entities;

namespace Paragonr.Application.Queries.Info
{
    // ReSharper disable once UnusedMember.Global
    public sealed class InfoQueryHandler : IRequestHandler<InfoQuery, InfoResult>
    {
        private readonly IBudgetDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRateProvider _rates;

        const string DefaultCurrencyIsoCode = "PLN";

        public InfoQueryHandler(IBudgetDbContext context, IMapper mapper, IRateProvider rates)
        {
            _context = context;
            _mapper = mapper;
            _rates = rates;
        }

        public async Task<InfoResult> Handle(InfoQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _context.Currencies.ProjectTo<CurrencyDto>().ToArrayAsync(cancellationToken);
            foreach (var currency in currencies)
            {
                decimal? rate = _rates.GetRateOrDefault(currency.IsoCode, DefaultCurrencyIsoCode);
                currency.RateToMain = rate;
            }

            return new InfoResult(items);
        }
    }
}