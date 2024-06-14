using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Orders.Commands.AddRange
{
    public class OrderAddRangeCommand:IRequest<ResponseDto<int>>
    {
        public int OrderCount { get; set; } = 50000;
        //Kaç sayı gelirse o kadar db ye fake kayıt ekle
    }
}
