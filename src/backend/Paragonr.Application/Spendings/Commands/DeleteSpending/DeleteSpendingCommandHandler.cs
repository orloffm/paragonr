using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Spendings.Commands.DeleteSpending
{
    public sealed class DeleteSpendingCommandHandler : IRequestHandler<DeleteSpendingCommand>
    {
        public Task<Unit> Handle(DeleteSpendingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
