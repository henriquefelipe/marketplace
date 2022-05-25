using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class merchants_data
    {
        public merchants_data()
        {
            merchants = new List<merchant_data>();
        }

        public List<merchant_data> merchants { get; set; }        
    }


    public class merchant_data
    {
        public int merchant_id { get; set; }
        public string name { get; set; }
    }
}
