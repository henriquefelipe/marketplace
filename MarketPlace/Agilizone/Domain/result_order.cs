using System;
using System.Collections.Generic;
using System.Text;

namespace Agilizone.Domain
{
    public class result_order
    {
        public result_order_result order {  get; set; }
    }

    public class result_order_result : order
    {
        public string _id { get; set; }
        public string storeId { get; set; }
    }
}
