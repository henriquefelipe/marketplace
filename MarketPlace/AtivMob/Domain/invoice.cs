using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivMob.Domain
{
    public class invoice
    {
        public string key { get; set; }
        public int number { get; set; }
        public string serie { get; set; }
        public string issueDate { get; set; }
        public amount amount { get; set; }
        public cte cte { get; set; }
        public carrier carrier { get; set; }
        public issuer issuer { get; set; }
        public int cfop { get; set; }
        public double icms { get; set; }
        public double icmsSubstitution { get; set; }
        public double baseIcms { get; set; }
        public double baseIcmsSubstitution { get; set; }
    }
}
