using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using MextFullstackSaaS.Domain.Identity;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }
        public DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
