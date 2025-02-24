﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Models.Payments
{
    public class PaymentCreateCheckoutFormResponse
    {
        public decimal Price { get; set; }
        public decimal PaidPrice { get; set; }
        public string ConversationId { get; set; }
        public string BasketId { get; set; }
        public string Token { get; set; }
        public long? TokenExpireTime { get; set; }
        public string CheckoutFormContent { get; set; }
        public string PaymentPageUrl { get; set; }
    }
}
