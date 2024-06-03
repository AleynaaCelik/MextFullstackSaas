﻿using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models.Auth;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Login;
using MextFullStackSaas.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Services
{
    public class IdentityManager : IIdentityService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public IdentityManager(IJwtService jwtService, UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }

        public async Task<UserAuthRegisterResponseDto> RegisterAsync(UserAuthRegisterCommand command, CancellationToken cancellationToken)
        {
            var user = UserAuthRegisterCommand.ToUser(command);
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var token =await _userManager.GenerateEmailConfirmationTokenAsync(user);//Token oluşturmak için yeni 

            return new UserAuthRegisterResponseDto(user.Id, user.Email,user.FirstName,token);
        }

        

        public async Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user is not null)
                return true;
            return false;
        }

        public async Task<JwtDto> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            var user=await _userManager.FindByEmailAsync(command.Email);
            var jwtDto = await _jwtService.GenerateTokenAsync(user.Id, user.Email, cancellationToken);
            return jwtDto;
        }

        public async Task<bool> CheckPasswordSignInAsync(string email, string password, CancellationToken cancellationToken)
        {
            var  user=await _userManager.FindByEmailAsync(email);
            if (user is null) return false;
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
