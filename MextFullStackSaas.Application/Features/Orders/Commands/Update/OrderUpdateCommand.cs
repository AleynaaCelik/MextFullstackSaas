using MediatR;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Enums;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommand : IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }

        //public static void MapToOrder(Order order, OrderUpdateCommand orderUpdateCommand)
        //{
        //    order.IconDescription = orderUpdateCommand.IconDescription;
        //    order.ColourCode = orderUpdateCommand.ColourCode;
        //    order.Model = orderUpdateCommand.Model;
        //    order.DesignType = orderUpdateCommand.DesignType;
        //    order.Size = orderUpdateCommand.Size;
        //    order.Shape = orderUpdateCommand.Shape;
        //    order.Quantity = orderUpdateCommand.Quantity;
        //    order.ModifiedOn = DateTimeOffset.UtcNow;
        //}


    }
}
