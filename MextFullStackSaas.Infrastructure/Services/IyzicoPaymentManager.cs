﻿using Iyzipay.Model;
using Iyzipay.Request;
using MextFullstackSaas.Domain.Settings;

using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.Payments;
using Microsoft.Extensions.Options;
using Options = Iyzipay.Options;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class IyzicoPaymentManager : IPaymentService
    {
        private readonly Options _options;

        public IyzicoPaymentManager(IOptions<IyzicoSettings> settings)
        {
            _options = new Options
            {
                ApiKey = settings.Value.ApiKey,
                SecretKey = settings.Value.SecretKey,
                BaseUrl = settings.Value.BaseUrl
            };
        }
        private const int OneCreditPrice = 10;
        private const string CallBackUrl = "http://localhost:7030/Payment/payment-result";

        public async Task<object> CreateCheckOutFromAsync(PaymentCreateCheckoutFormRequest userrequest, CancellationToken cancellationToken)
        {
            var price = userrequest.Credits * OneCreditPrice;
            var paidPrice = price;
            var basketId = Guid.NewGuid();

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "100",
                PaidPrice = "100",
                Currency = Currency.TRY.ToString(),
                BasketId = "B123456",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = CallBackUrl
            };

            List<int> enabledInstallments = new List<int>();

            enabledInstallments.Add(3);

            enabledInstallments.Add(6);

            enabledInstallments.Add(9);

            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "Alper",
                Surname = "Tunga",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };
            request.Buyer = buyer;

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            BasketItem firstBasketItem = new BasketItem
            {
                Id = "BI101",
                Name = "IconBuilderAI 10 credits",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "100",
                Category1="Credits"
            };
            basketItems.Add(firstBasketItem);

            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, _options);

            return checkoutFormInitialize;
        }
    }
}
