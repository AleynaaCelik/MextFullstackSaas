﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Domain.Common
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public List<string> Messages { get; set; }
        public ErrorDto(string propertyName, List<string> messages)
        {
            PropertyName = propertyName;

            Messages = messages;
        }
    }
}
