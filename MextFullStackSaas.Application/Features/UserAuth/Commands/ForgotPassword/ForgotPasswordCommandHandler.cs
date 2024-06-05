﻿using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models.Emails;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;

        public ForgotPasswordCommandHandler(IIdentityService identityService, IEmailService emailService)
        {
            _identityService = identityService;
            _emailService = emailService;
        }

        public async Task<ResponseDto<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcı için şifre sıfırlama tokenı oluştur
            var response = await _identityService.GeneratePasswordResetTokenAsync(request.Email, cancellationToken);
            var token = response.EmailToken;

            // E-posta gönder
            var emailDto = new EmailSendPasswordResetDto
            {
                Email = request.Email,
                Token = token
            };

            await _emailService.SendPasswordResetEmailAsync(emailDto, cancellationToken);

            return new ResponseDto<string>(token, message: "Password reset email sent successfully");
        }
    }
}
