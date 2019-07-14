using MediatR;

namespace Paragonr.Application.Queries.List
{
    public sealed class CurrencyQuery : IRequest<CurrencyResult>
    {
        public CurrencyQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}