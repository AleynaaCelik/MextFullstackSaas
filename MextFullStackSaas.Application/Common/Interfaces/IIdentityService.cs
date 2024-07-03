using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using MextFullStackSaas.Application.Features.UserAuth.Commands.SocialLogin;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Update;
using MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail;
using MextFullStackSaas.Application.Features.Users.Queries.GetProfile;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<UserAuthRegisterResponseDto>RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken);
        Task<JwtDto>LoginAsync(UserAuthLoginCommand command,CancellationToken cancellationToken);
        Task<JwtDto> SocialLoginAsync(UserAuthSocialLoginCommand command, CancellationToken cancellationToken);
        Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken);
        Task<bool> CheckPasswordSignInAsync(string email,string password, CancellationToken cancellationToken);
        Task<bool> VerifyEmialAsync(UserAuthVerifyEmailCommand command,CancellationToken cancellationToken);

        Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken);

        Task<UserAuthResetPasswordResponseDto> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

        Task<UserGetProfileDto> GetProfileAsync( CancellationToken cancellationToken);

    }
}
