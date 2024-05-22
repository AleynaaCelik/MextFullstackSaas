using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Common
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public string Messages { get; set; }
        public ErrorDto(string propertyName, string messages)
        {
            PropertyName = propertyName;
            Messages = messages;
        }
    }
}
