using System.Net;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullstackSaaS.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using MextFullStackSaas.Application.Features.UserAuth.Commands.SocialLogin;
using MextFullStackSaas.Application.Features.UserAuth.Commands.VerifiyEmail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Update;
using MextFullStackSaas.Application.Features.Users.Queries.GetProfile;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        public IdentityManager(IJwtService jwtService, UserManager<User> userManager, ICurrentUserService currentUserService,IApplicationDbContext applicationDbContext)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
            
        }

        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return new UserAuthRegisterResponseDto(user.Id, user.Email, user.FirstName, token);
        }

        public async Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);
            return jwtDto;
        }

        public async Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<bool> VerifyEmialAsync(UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);
            var result = await _userManager.ConfirmEmailAsync(user, command.Token);
            if (!result.Succeeded)
            {
                throw new Exception("Users email verification failed");
            }
            return true;
        }

        public Task<bool> CheckIfEmailVerifiedAsync(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email && x.EmailConfirmed, cancellationToken);
        }

        public async Task<UserAuthResetPasswordResponseDto> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://yourapp.com/reset-password?email={email}&token={token}";

            // E-postayı gönder
            return new UserAuthResetPasswordResponseDto(user.Id, user.Email, user.FirstName, token);
        }

        public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }

        public async Task<JwtDto> SocialLoginAsync(UserAuthSocialLoginCommand command, CancellationToken cancellationToken)
        {
            User? user = await _userManager.FindByEmailAsync(command.Email);

            if (user == null)
            {
                user = UserAuthSocialLoginCommand.ToUser(command);
                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                {
                    throw new Exception("User social login registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);
            return jwtDto;
        }

        public async Task<UserGetProfileDto> GetProfileAsync(CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(_currentUserService.UserId.ToString());

            user.Balance = await _applicationDbContext.UserBalances.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken);

            return UserGetProfileDto.Map(user);

        }
    }
    }

