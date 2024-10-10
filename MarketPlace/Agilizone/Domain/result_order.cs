using Newtonsoft.Json;
using System.Collections.Generic;

namespace Agilizone.Domain
{
    public class result_order
    {
        public string _id { get; set; }
        public string storeId { get; set; }
        public int? status { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public result_order_result_response response { get; set; }
        public result_order_result order {  get; set; }
    }

    public class result_order_result
    {
        public result_order_result()
        {
            history = new List<history>();
        }
        
        public string _id { get; set; }
        
        public string status { get; set; }
        
        public string singleOrderAppliedBonus { get; set; }
        
        public string createdAt { get; set; }
        public string number { get; set; }
        public string detail { get; set; }        
        public string orderType { get; set; }
        
        public string isMock { get; set; }
        
        public string cardMachineId { get; set; }
        
        public List<history> history { get; set; }
    }

    public class result_order_result_response
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }
}
