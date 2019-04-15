using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class Currency : EntityBase
    {
        [MaxLength(3)]
        [Required]
        public string IsoCode { get; set; }

        [DefaultValue(null)]
        public bool? IsMain { get; set; }
    }
}