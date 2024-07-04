using MediatR;
using MextFullStackSaas.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentCreatePaymentFormCommandHandler : IRequestHandler<PaymentCreatePaymentFormCommand, object>
    {
        private readonly IPaymentService _paymentService;

        public PaymentCreatePaymentFormCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Task<object> Handle(PaymentCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            return _paymentService.CreateCheckOutFromAsync(cancellationToken);
        }
    }
}
