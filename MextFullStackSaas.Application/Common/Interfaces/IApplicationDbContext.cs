using MextFullstackSaas.Domain.Entities;
using MextFullstackSaas.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullStackSaas.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<UserBalance> UserBalances { get; set; }
        DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //Task asenkron methodlar için 

        int SaveChanges();
        //senkron methodlar için
    }
}
