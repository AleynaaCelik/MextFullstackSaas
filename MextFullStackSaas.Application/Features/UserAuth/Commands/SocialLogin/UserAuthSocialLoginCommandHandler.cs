using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.SocialLogin
{
    public class UserAuthSocialLoginCommandHandler : IRequestHandler<UserAuthSocialLoginCommand, ResponseDto<JwtDto>>
    {
        private readonly IIdentityService _identityService;

        public UserAuthSocialLoginCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<ResponseDto<JwtDto>> Handle(UserAuthSocialLoginCommand request, CancellationToken cancellationToken)
        {
            var jwtDto = await _identityService.SocialLoginAsync(request, cancellationToken);
            return new ResponseDto<JwtDto>(jwtDto, "Welcome Back!");
        }
    }
}
