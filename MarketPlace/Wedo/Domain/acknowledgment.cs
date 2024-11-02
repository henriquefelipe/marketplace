using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class acknowledgmentEvent
    {
        public string event_id {  get; set; }
        public bool integrated { get; set; }
    }

    public class acknowledgmentOrder
    {        
        public string correlationId { get; set; }
        public string status { get; set; }
    }
}
