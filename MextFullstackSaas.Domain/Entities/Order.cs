using MextFullstackSaas.Domain.Common;
using MextFullstackSaas.Domain.Enums;
using MextFullstackSaas.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Entities
{
    public class Order:EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }

    }
}
