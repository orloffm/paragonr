using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Spendings.Commands.UpdateSpending
{
    public sealed class UpdateSpendingCommandHandler : IRequestHandler<UpdateSpendingCommand>
    {
        public Task<Unit> Handle(UpdateSpendingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
