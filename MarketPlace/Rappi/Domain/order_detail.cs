using System.Collections.Generic;

namespace Rappi.Domain
{
    public class order_detail
    {
        public string order_id { get; set; }
        public int cooking_time { get; set; }
        public int min_cooking_time { get; set; }
        public int max_cooking_time { get; set; }
        public string created_at { get; set; }
        public string delivery_method { get; set; }
        public string payment_method { get; set; }
        public string billing_information { get; set; }
        public delivery_information delivery_Information { get; set; }
        public totals totals { get; set; }
        public List<item> items { get; set; }
        public delivery_discount delivery_discount { get; set; }
    }
}
