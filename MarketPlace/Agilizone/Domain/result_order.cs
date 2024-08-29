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

    public class result_order_result : order
    {
       
    }

    public class result_order_result_response
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string error { get; set; }
    }
}
