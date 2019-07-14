using System.ComponentModel.DataAnnotations;
using Paragonr.Shared;

namespace Paragonr.Entities
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public long Id { get; set; }
    }
}