using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Translations;
using Microsoft.Extensions.Localization;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IStringLocalizer<CommonTranslations> _localizer;

        public ResetPasswordCommandHandler(IIdentityService identityService, IStringLocalizer<CommonTranslations> localizer)
        {
            _identityService = identityService;
            _localizer = localizer;
        }

        public async Task<ResponseDto<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
            if (result)
            {
                return new ResponseDto<string>(request.Email, message: _localizer[CommonTranslationKeys.ResetPasswordSuccessMessage, request.Email]);
            }
            return new ResponseDto<string>(request.Email, message: _localizer[CommonTranslationKeys.ResetPasswordFailureMessage, request.Email]);
        }
    }
}
