using System;
using System.ComponentModel.DataAnnotations;

namespace Paragonr.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}