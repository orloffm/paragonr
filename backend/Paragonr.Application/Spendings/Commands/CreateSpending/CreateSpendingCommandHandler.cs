using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Spendings.Commands.CreateSpending
{
    public sealed class CreateSpendingCommandHandler : IRequestHandler<CreateSpendingCommand>
    {
        public Task<Unit> Handle(CreateSpendingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
