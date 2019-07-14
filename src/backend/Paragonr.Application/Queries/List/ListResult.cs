using System.Collections.Generic;

namespace Paragonr.Application.Queries.List
{
    public sealed class ListResult<TItem>
    {
        public IList<TItem> Items { get; set; }
    }
}