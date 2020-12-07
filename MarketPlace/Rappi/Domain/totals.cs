using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Domain
{
    public class totals
    {
        public decimal total_products_with_discount { get; set; }
        public decimal total_products_without_discount { get; set; }
        public decimal total_other_discounts { get; set; }
        public decimal total_order { get; set; }
        public decimal total_to_pay { get; set; }
        public totals_charges charges { get; set; }
        public totals_other_totals other_totals { get; set; }
    }
}
