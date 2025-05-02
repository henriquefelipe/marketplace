using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class values
    {
        public values()
        {
            currency = "BRL";
        }

        public values(decimal value)
        {
            currency = "BRL";
            this.value = value;
        }

        public decimal value { get; set; }
        public string currency { get; set; }
    }
}
