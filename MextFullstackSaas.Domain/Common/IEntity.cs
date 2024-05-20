using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Common
{
    public interface IEntity<TKey>
    {
        //Dbye gidecek 

        public TKey Id { get; set; }
    }
}
