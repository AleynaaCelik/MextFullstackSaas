using MediatR;
using MextFullStackSaas.Application.Common.Helpers;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllQueryHandler : IRequestHandler<OrderGetAllQuery, List<OrderGetAllDto>>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;
         
        public OrderGetAllQueryHandler(ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
        {
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<OrderGetAllDto>> Handle(OrderGetAllQuery request, CancellationToken cancellationToken)
        {
            List<OrderGetAllDto> orders;
            if (_memoryCache.TryGetValue(MemoryCacheHelper.OrdersGetAllKey,out orders)) return orders;
               
            
            orders=await _applicationDbContext
                 .Orders
                 .Where(x => x.UserId == _currentUserService.UserId)
                 .Select(o => OrderGetAllDto.FromOrder(o))
                 .ToListAsync(cancellationToken);
            return orders;
        }
    }
}
