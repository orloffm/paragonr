using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paragonr.Entities
{
    public class Currency : EntityBase
    {
        public string IsoCode { get; set; }
    }
}