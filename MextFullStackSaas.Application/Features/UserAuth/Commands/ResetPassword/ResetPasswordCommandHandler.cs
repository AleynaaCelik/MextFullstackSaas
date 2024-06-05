using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResponseDto<string>>
    {
        private readonly IIdentityService _identityService;

        public ResetPasswordCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        { 
            var result = await _identityService.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
            if (result)
            {
                return new ResponseDto<string>(request.Email, message: "Password reset successfully");
            }
            return new ResponseDto<string>(request.Email, message: "Password reset failed");
        }
    }
}
