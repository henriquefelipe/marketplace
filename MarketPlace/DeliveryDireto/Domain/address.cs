using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class address
    {
        public string city { get; set; }
        public string complement { get; set; }
        public string reference_point { get; set; }
        public decimal? id { get; set; }
        public string neighborhood { get; set; }
        public string number { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
        public decimal? lat { get; set; }
        public decimal? lng { get; set; }
    }
}
