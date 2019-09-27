using System.ComponentModel.DataAnnotations;
using Paragonr.Tools;

namespace Paragonr.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public long Id { get; set; }
    }
}