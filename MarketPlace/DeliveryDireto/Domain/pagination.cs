using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class pagination
    {
        public decimal currentOffset { get; set; }
        public decimal limit { get; set; }
        public decimal totalItems { get; set; }
    }
}
