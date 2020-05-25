using System;

namespace Paragonr.Tools.Domain
{
    public interface IRefKeyEnabledEntity
    {
        /// <summary>
        /// The key that uniquely identifies this item.
        /// May and should be used publicly.
        /// Used instead of numbers to hide global counters.
        /// </summary>
        Guid RefKey { get; }
    }
}
