using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class table
    {
        public string idempotencyKey { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string tablesectionsIdempotencyKey { get; set; }
    }
}
