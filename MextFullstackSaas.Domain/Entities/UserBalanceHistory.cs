using MextFullstackSaas.Domain.Common;
using MextFullstackSaas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Entities
{
    public class UserBalanceHistory : EntityBase<Guid>
    {
        public Guid UserBalanceId { get; set; }
        public UserBalance UserBalance { get; set; }
        public UserBalanceHistoryType Type { get; set; }
        public int Amount { get; set; }

        public int PreviousCredits { get; set; }
        public int CurrentCredits { get; set; }
    }
}
