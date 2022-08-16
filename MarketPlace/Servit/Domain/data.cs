using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servit.Domain
{
    public class data
    {        
                
        public string status { get; set; }
        public string payment_method { get; set; }
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public int user_id { get; set; }
        public int bill_status_id { get; set; }
        public int table_id { get; set; }
        public int waiter_id { get; set; }
        public decimal price { get; set; }
        public decimal change { get; set; }
        public bool tip { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        //"payment_method_id":null,
        //       "discount":null,
        //       "tip_value":null,
        //       "created_by_waiter":null,
        //       "created_by_pdv":null,
        //       "transaction_id":null,
        //       "gateway_order_id":null,
        //       "pix_code":null,
        //       "pix_image_url":null,
        //       "pdv_readed":null
    }
}
