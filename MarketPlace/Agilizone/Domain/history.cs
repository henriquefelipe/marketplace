using System;
using System.Collections.Generic;
using System.Text;

namespace Agilizone.Domain
{
    public class history
    {
        public string timestamp {  get; set; }
        public string status { get; set; }
        public history_user user { get; set; }
        public history_deliveryman deliveryman { get; set; }
    }

    public class history_user
    {
        public string id { get; set; }
        public string name { get; set; }        
    }

    public class history_deliveryman
    {
        public string id { get; set; }
        public string name { get; set; }        
        public string deliverymanPdvId { get; set; }
    }
}
