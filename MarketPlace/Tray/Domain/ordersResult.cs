using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class ordersResult
    {
        public paging paging {  get; set; }
        public List<orderResult> Orders { get; set; }
    }
    
}
