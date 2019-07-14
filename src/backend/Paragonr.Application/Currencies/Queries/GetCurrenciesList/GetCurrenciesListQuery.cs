using MediatR;

namespace Paragonr.Application.Currencies.Queries.GetCurrenciesList
{
    public sealed class GetCurrenciesListQuery : IRequest<CurrenciesListViewModel>
    {
    }
}