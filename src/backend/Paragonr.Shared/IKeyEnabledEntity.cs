using System;

namespace Paragonr.Shared
{
    public interface IKeyEnabledEntity
    {
        Guid Key { get; }
    }
}