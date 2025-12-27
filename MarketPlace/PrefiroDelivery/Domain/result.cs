using System;
using System.Collections.Generic;
using System.Text;

namespace PrefiroDelivery.Domain
{
    public class result<T>
    {
        public string codigo { get; set; }
        public string mensagem { get; set; }

        public T data { get; set; }
    }
}
