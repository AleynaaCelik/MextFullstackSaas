using MextFullstackSaas.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Identity
{
    public class UserBalance : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Credits { get; set; }

        public ICollection<UserBalanceHistory> Histories { get; set; }
        //bir userbalanceın brden fazla historiesi olabilir 
    }
}
