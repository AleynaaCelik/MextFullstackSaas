﻿using MediatR;
using MextFullstackSaas.Domain.Common;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Enums;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommand:IRequest<ResponseDto<Guid>>
    {
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }


        public static Order MapToOrder(OrderAddCommand orderAddCommand)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                IconDescription = orderAddCommand.IconDescription,
                ColourCode = orderAddCommand.ColourCode,
                Model = orderAddCommand.Model,
                DesignType = orderAddCommand.DesignType,
                Size = orderAddCommand.Size,
                Shape = orderAddCommand.Shape,
                Quantity = orderAddCommand.Quantity,
                CreatedOn = DateTimeOffset.UtcNow,
            };

        }
    }
}
