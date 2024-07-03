using MediatR;
using MextFullstackSaas.Domain.Identity;
using MextFullstackSaaS.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Commands.Update
{
    public class UpdateUserProfileCommand : IRequest<ResponseDto<string>>
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
    
    public UpdateUserProfileCommand(string userId, string firstName, string lastName, string email, string imageUrl)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ImageUrl = imageUrl;
    }
}
}
