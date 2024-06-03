using MediatR;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Interfaces;
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

        public UserAuthVerifyEmailCommandHandler( IIdentityService identityService)
        {
           
            _identityService = identityService;
        }
        public async Task<ResponseDto<string>> Handle(UserAuthVerifyEmailCommand request, CancellationToken cancellationToken)
        {
            await _identityService.VerifyEmialAsync(request, cancellationToken);
            return new ResponseDto<string> (request.Email,message:"Email verifeid successfully");
            }
        }
    }
