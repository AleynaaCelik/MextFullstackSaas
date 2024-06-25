using MediatR;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Queries.GetAllCommunity
{
    public class OrderGetAllCommunityQueryHandler:IRequestHandler<OrderGetAllCommunityQuery,List<string>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public Task<List<string>> Handle(OrderGetAllCommunityQuery request, CancellationToken cancellationToken)
        {
            return _applicationDbContext.Orders.AsNoTracking().SelectMany(x=>x.Urls).ToListAsync(cancellationToken);
        }
    }
}
