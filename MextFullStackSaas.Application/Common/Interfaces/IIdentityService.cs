using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto>RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
        Task<JwtDto>LoginAsync(UserAuthLoginCommand command,CancellationToken cancellationToken);
        Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email,string password, CancellationToken cancellationToken);
    }
}
