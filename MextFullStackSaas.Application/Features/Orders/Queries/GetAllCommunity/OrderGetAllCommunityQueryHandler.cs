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

        public async Task<List<string>> Handle(OrderGetAllCommunityQuery request, CancellationToken cancellationToken)
        {
            var urlsLists = await _applicationDbContext
                .Orders
                .AsNoTracking()
                .Select(x=>x.Urls)
                .ToListAsync(cancellationToken);

            var urls=urlsLists
                .SelectMany(x=>x)
                .ToList();


           // Orderların listelerini tek bir stringe atmak için
            return urls;
        }
    }
}
