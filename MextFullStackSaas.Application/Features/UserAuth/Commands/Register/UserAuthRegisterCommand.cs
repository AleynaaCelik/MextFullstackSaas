using MediatR;
using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullstackSaaS.Application.Common.Models;
using MextFullStackSaas.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Register
{
    public class UserAuthRegisterCommand:IRequest<ResponseDto<JwtDto>>
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static User ToUser(UserAuthRegisterCommand command)
        {

            var id = Guid.NewGuid();
           return new User()
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                UserName = command.FirstName,
                LastName = command.LastName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = id.ToString(),
                EmailConfirmed = true,
                Balance = new UserBalance()
                {
                    Id = Guid.NewGuid(),
                    Credits = 10,
                    UserId = id,
                    CreatedOn = DateTimeOffset.Now,
                    CreatedByUserId = id.ToString(),
                }
            };
        }
    }
}
