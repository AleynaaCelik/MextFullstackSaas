using MediatR;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Enums;
using MextFullstackSaas.Domain.ValueObjects;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.Payments;
using MextFullStackSaas.Application.Features.Payments.Commands.CreatePaymentForm;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Application.Features.Payments.Commands.CreatePaymentForm
{
    public class PaymentCreatePaymentFormCommandHandler : IRequestHandler<PaymentCreatePaymentFormCommand, ResponseDto<PaymentCreatePaymentFormDto>>
    {
        private readonly IPaymentService _paymentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;
        private readonly IApplicationDbContext _applicationDbContext;

        public PaymentCreatePaymentFormCommandHandler(IPaymentService paymentService, ICurrentUserService currentUserService, IIdentityService identityService, IApplicationDbContext applicationDbContext)
        {
            _paymentService = paymentService;
            _currentUserService = currentUserService;
            _identityService = identityService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseDto<PaymentCreatePaymentFormDto>> Handle(PaymentCreatePaymentFormCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _identityService.GetProfileAsync(cancellationToken);
            var paymentDetail = userProfile.MapToPaymentDetail();

            var userRequest = new PaymentCreateCheckoutFormRequest(paymentDetail, request.Credits);
            var checkoutFormResponse = _paymentService.CreateCheckoutForm(userRequest);

            var userPayment = MapUserPayment(paymentDetail, checkoutFormResponse);

            _applicationDbContext.UserPayments.Add(userPayment);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new ResponseDto<PaymentCreatePaymentFormDto>
            {
                Data = new PaymentCreatePaymentFormDto
                {
                    // response'dan gerekli alanları doldurun
                },
            };
        }

        private UserPayment MapUserPayment(UserPaymentDetail paymentDetail, PaymentCreateCheckoutFormResponse checkoutFormResponse)
        {
            var userPaymentId = Guid.NewGuid();

            return new UserPayment()
            {
                Id = userPaymentId,
                UserId = _currentUserService.UserId,
                BasketId = checkoutFormResponse.BasketId,
                Price = checkoutFormResponse.Price,
                PaidPrice = checkoutFormResponse.PaidPrice,
                CurrencyCode = CurrencyCode.TRY,
                CreatedOn = DateTimeOffset.UtcNow,
                Token = checkoutFormResponse.Token,
                UserPaymentDetail = paymentDetail,
                Status = PaymentStatus.Initiated,
                CreatedByUserId = _currentUserService.UserId.ToString(),
                Histories = new List<UserPaymentHistory>()
                {
                    new UserPaymentHistory()
                    {
                        Id = Guid.NewGuid(),
                        Status = PaymentStatus.Initiated,
                        UserPaymentId = userPaymentId,
                        ConversationId = checkoutFormResponse.ConversationId,
                        CreatedOn = DateTimeOffset.UtcNow,
                        CreatedByUserId = _currentUserService.UserId.ToString(),
                    }
                }
            };
        }
    }
}
