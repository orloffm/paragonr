using System;

namespace Paragonr.Tools.Domain
{
    public interface IRefKeyEnabledEntity
    {
        Guid RefKey { get; }
    }
}
