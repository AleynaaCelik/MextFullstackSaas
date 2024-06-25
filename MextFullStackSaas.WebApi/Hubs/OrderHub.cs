using MediatR;
using MextFullStackSaas.Application.Features.Orders.Queries.GetAllCommunity;
using Microsoft.AspNetCore.SignalR;

namespace MextFullStackSaas.WebApi.Hubs
{
    public class OrderHub:Hub
    {
        //Frontendin backendde tetikleme yapacağı methodlar
        private readonly ISender _mediatr; 

        public OrderHub(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task NewOrderAddedAsync()
        {

        }
        public  Task GetAllCommunityAsync()
        {
            return _mediatr.Send(new OrderGetAllCommunityQuery());
        }


    }
}
