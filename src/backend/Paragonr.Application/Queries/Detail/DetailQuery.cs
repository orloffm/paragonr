using MediatR;

namespace Paragonr.Application.Queries.List
{
    public sealed class DetailQuery<TItem> : IRequest<DetailResult<TItem>>
    {
        public DetailQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}