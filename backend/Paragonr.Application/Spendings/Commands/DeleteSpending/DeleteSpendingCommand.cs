using System;
using MediatR;

namespace Paragonr.Application.Spendings.Commands.DeleteSpending
{
    public sealed class DeleteSpendingCommand : IRequest
    {
        public Guid RefKey { get; set; }
    }
}
