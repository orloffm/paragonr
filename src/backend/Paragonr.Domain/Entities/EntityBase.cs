using System.ComponentModel.DataAnnotations;
using Paragonr.Tools;
using Paragonr.Tools.Domain;

namespace Paragonr.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        [Key]
        public long Id { get; set; }
    }
}