using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentCreatePaymentFormDto
    {
        public PaymentCreatePaymentFormDto()
        {
        }

        public PaymentCreatePaymentFormDto(string paymentPageUrl)
        {
            PaymentPageUrl = paymentPageUrl;
        }

        public  string PaymentPageUrl { get; set; }
    }
}
