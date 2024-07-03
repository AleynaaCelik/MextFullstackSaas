using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Features.UserAuth.Queries
{
    public class GetUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public decimal Balance { get; set; }
        public string PhoneNumber { get; set; }

        public GetUserProfileDto(string firstName, string lastName, string email, string userName, string imageUrl, decimal balance, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            ImageUrl = imageUrl;
            Balance = balance;
            PhoneNumber = phoneNumber;
        }

        // Default constructor required for serialization
        public GetUserProfileDto()
        {
        }
    }
}
