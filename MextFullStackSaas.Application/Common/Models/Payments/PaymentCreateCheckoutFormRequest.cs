using MextFullstackSaas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Models.Payments
{
    public class PaymentCreateCheckoutFormRequest
    {
        public UserPaymentDetail PaymentDetail { get; set; }
        public int Credits { get; set; }

        public PaymentCreateCheckoutFormRequest()
        {
        }

        public PaymentCreateCheckoutFormRequest(UserPaymentDetail paymentDetail, int credits)
        {
            PaymentDetail = paymentDetail;
            Credits = credits;
        }

       
    }
}
