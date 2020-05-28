using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Spendings.Queries.GetSpendingDetail
{
    public sealed class GetSpendingDetailQueryHandler : IRequestHandler<GetSpendingDetailQuery, SpendingDetailVm>
    {
        public Task<SpendingDetailVm> Handle(GetSpendingDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
