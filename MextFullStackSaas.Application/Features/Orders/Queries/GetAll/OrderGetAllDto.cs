﻿using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Enums;
using MextFullstackSaas.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
        public DateTimeOffset CreatedOn { get; set; }

        public static OrderGetAllDto FromOrder(Order order)
        {
            return new OrderGetAllDto
            {
                Id = order.Id,
                UserId = order.UserId,
                IconDescription = order.IconDescription,
                ColourCode = order.ColourCode,
                Model = order.Model,
                DesignType = order.DesignType,
                Size = order.Size,
                Shape = order.Shape,
                Quantity = order.Quantity,
                Urls = order.Urls,
                CreatedOn = order.CreatedOn
            };
        }

    }
}
