using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Extensions
{
    public static class IntegerExtensions
    {
        //Extensions methodlarını oluşturmak için static olmalı 

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
