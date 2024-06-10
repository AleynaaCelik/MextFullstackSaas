using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Emails;
using MextFullStackSaas.Application.Common.Translations;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using Microsoft.Extensions.Localization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommandHandler : IRequestHandler<UserAuthRegisterCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;
        public UserAuthRegisterCommandHandler(IIdentityService identityService, IJwtService jwtService,IEmailService emailService, IStringLocalizer<CommonTranslations> localizer)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _emailService=emailService;
            _localizer = localizer;

        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.RegisterAsync(request, cancellationToken);
            var jwtDtoTask =  _jwtService.GenerateTokenAsync(response.Id, response.Email, cancellationToken);

            //Send Email Verification
            var sendEmailTask= SendEmailVerificationAsync(response.Email,response.FirstName,response.EmailToken, cancellationToken);
            await Console.Out.WriteLineAsync($"Email={response.Email}, EmailToken={response.EmailToken}");
            await Task.WhenAll(jwtDtoTask,sendEmailTask);

            return new ResponseDto<JwtDto>(await jwtDtoTask,_localizer[CommonTranslationKeys.UserAuthRegisterSuccededMessage] );
        }
        private  Task SendEmailVerificationAsync(string email,string firstName,string emailToken,CancellationToken cancellationToken)
        {
            var emailDto = new EmailSendEmailVerificationDto(email,firstName,emailToken);

            return  _emailService.SendEmailVerificationAsync(emailDto, cancellationToken);
        }
    }
}
