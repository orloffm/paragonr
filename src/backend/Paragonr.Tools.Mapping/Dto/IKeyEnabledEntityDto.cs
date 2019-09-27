using System;

namespace Paragonr.Application.Infrastructure
{
    public interface IKeyEnabledEntityDto
    {
        Guid Key { get; set; }
    }
}