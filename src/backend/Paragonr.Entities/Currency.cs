using System.ComponentModel.DataAnnotations;

namespace Paragonr.Entities
{
    public class Currency : EntityBase
    {
        [MaxLength(3)]
        [Required]
        public string IsoCode { get; set; }

        public bool IsMain { get; set; }
    }
}