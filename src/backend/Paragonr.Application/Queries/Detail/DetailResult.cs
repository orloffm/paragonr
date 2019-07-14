namespace Paragonr.Application.Queries.List
{
    public sealed class DetailResult<TItem>
    {
        public DetailResult(TItem item)
        {
            Item = item;
        }

        public TItem Item { get; }
    }
}