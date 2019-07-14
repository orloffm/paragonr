using MediatR;

namespace Paragonr.Application.Queries.List
{
    public sealed class ListQuery<TItem> : IRequest<ListResult<TItem>>
    {
    }
}