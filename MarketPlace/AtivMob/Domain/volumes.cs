using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class volumes
    {
        public decimal weight { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public label label { get; set; }
        public IList<products> products { get; set; }
    }
}
