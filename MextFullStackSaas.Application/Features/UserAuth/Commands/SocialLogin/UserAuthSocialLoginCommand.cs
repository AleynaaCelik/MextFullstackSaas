﻿using MediatR;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.SocialLogin
{
    public class UserAuthSocialLoginCommand : IRequest<ResponseDto<JwtDto>>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImage { get; set; }

        public UserAuthSocialLoginCommand(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
           
        }
        public UserAuthSocialLoginCommand(string email, string firstName, string lastName,string? profileImage)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
        }
        public UserAuthSocialLoginCommand()
        {

        }

        public static User ToUser(UserAuthSocialLoginCommand command)
        {
            var id = Guid.NewGuid();

            return new User()
            {
                Id = id,
                Email = command.Email,
                UserName = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                ProfileImage=command.ProfileImage,
                Balance = new UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 0,
                    UserId = id,
                    CreatedOn = DateTimeOffset.UtcNow,
                    CreatedByUserId = id.ToString()
                }
            };
        }
    }
}
