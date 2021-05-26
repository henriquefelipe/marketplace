using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class order
    {
        public order()
        {
            packages = new List<packages>();
        }

        public string id { get; set; }
        public seller seller { get; set; }
        public sale sale { get; set; }
        public IList<packages> packages { get; set; }
    }
}
