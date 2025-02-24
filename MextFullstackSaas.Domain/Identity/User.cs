﻿using MextFullstackSaas.Domain.Common;
using MextFullstackSaas.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Identity
{
    //aplicationUser
    public class User : IdentityUser<Guid>, IEntity<Guid>, ICreatedByEntity, IModifiedByEntity
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }

        public UserBalance Balance { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<UserPayment> Payments { get; set; }

        //User.Balance.Credits=>0
    }
}
