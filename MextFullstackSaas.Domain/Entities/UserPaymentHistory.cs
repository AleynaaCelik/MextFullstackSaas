using MextFullstackSaas.Domain.Common;
using MextFullstackSaas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Entities
{
    public class UserPaymentHistory:EntityBase<Guid>
    {
        public string? ConversationId { get; set; }
        public PaymentStatus Status { get; set; }
        public string? Note { get; set; }
        public Guid UserPaymentId { get; set; }
        public UserPayment UserPayment { get; set; }
        
    }
}
