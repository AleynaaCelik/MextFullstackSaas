using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentCreatePaymentFormCommandHandler : IRequestHandler<PaymentCreatePaymentFormCommand, ResponseDto<PaymentCreatePaymentFormDto>>
    {
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public PaymentCreatePaymentFormCommandHandler(IPaymentService paymentService, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _paymentService = paymentService;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<ResponseDto<PaymentCreatePaymentFormDto>> Handle(PaymentCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _identityService.GetProfileAsync(cancellationToken);
            var paymentDetail = userProfile.MapToPaymentDetail();

            var userRequest = new PaymentCreateCheckoutFormRequest(paymentDetail, request.Credits);
            var response = await _paymentService.CreateCheckOutFromAsync(userRequest, cancellationToken);

            return new ResponseDto<PaymentCreatePaymentFormDto>();
        }
    }
}
