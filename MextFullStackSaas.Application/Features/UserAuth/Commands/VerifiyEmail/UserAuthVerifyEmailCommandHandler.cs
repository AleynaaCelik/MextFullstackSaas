using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Translations;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail
{
    public class UserAuthVerifyEmailCommandHandler : IRequestHandler<UserAuthVerifyEmailCommand, ResponseDto<string>>
    {
    
        private readonly IIdentityService _identityService;
        private readonly IStringLocalizer _localizer;
        public UserAuthVerifyEmailCommandHandler( IIdentityService identityService, IStringLocalizer<CommonTranslations> localizer)
        {
           
            _identityService = identityService;
            _localizer = _localizer;
        }
        public async Task<ResponseDto<string>> Handle(UserAuthVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            await _identityService.VerifyEmialAsync(request, cancellationToken);
            return new ResponseDto<string>(request.Email, _localizer[CommonTranslationKeys.UserAuthVerifyEmailSuccededMessage,request.Email]);
            }
        }
    }
