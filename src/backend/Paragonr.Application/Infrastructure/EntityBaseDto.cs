namespace Paragonr.Application.Infrastructure
{
    public abstract class EntityBaseDto : IEntityDto
    {
        public long Id { get; set; }
    }
}