﻿namespace Paragonr.Domain.Entities
{
    public class Currency : EntityBase
    {
        public string IsoCode { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }
    }
}