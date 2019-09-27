using System;

namespace Paragonr.Tools
{
    public interface IKeyEnabledEntity
    {
        Guid Key { get; }
    }
}