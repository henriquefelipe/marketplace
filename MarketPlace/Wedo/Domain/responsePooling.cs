using System;
using System.Collections.Generic;
using System.Text;

namespace Wedo.Domain
{
    public class responsePooling
    { 
        public responsePooling()
        {
            data = new List<responsePoolingData> ();
        }

        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<responsePoolingData> data { get; set; }
    }

    public class responsePoolingData
    {
        public string _id { get; set; }
        public string correlationId { get; set; }
        public string branchId { get; set; }
        public string companyId { get; set; }
        public string code { get; set; } // PENDING_APPROVAL   APPROVED
        public bool integrated { get; set; }
        public string createdAt { get; set; }
    }
}
