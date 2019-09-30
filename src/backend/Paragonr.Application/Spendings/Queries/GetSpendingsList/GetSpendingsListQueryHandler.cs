using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Spendings.Queries.GetSpendingsList
{
    public sealed class GetSpendingsListQueryHandler : IRequestHandler<GetSpendingsListQuery, SpendingsListVM>
    {
        public Task<SpendingsListVM> Handle(GetSpendingsListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
