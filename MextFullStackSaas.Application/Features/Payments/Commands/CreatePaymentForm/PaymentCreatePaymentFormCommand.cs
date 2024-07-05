using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentCreatePaymentFormCommand:IRequest<ResponseDto<PaymentCreatePaymentFormDto>>
    {
        public int Credits { get; set; }
    }
}
