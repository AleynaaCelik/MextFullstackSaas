using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.WebApi.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MextFullStackSaas.WebApi.Services
{
    public class OrderHubManager : IOrderHubService
    {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderHubManager(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task NewOrderAddedAsync(List<string> urls, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("NewOrderAdded",urls,cancellationToken);
        }
    }
}
