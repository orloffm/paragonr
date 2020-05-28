using System;
using MediatR;

namespace Paragonr.Application.Spendings.Queries.GetSpendingDetail
{
    public class GetSpendingDetailQuery : IRequest<SpendingDetailVm>
    {
        public Guid RefKey { get; set; }
    }
}
