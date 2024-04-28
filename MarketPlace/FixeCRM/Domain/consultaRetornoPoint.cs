using System;
using System.Collections.Generic;
using System.Text;

namespace FixeCRM.Domain
{
    public class consultaRetornoPoint
    {
        public consultaRetornoPoint_log log { get; set; }
        public string status { get; set; }
        public string error { get; set; }
    }

    public class consultaRetornoPoint_log
    {
        public string _id { get; set; }
        public string action { get; set; }
        public string value { get; set; }
        public int level { get; set; }
        public int points { get; set; }
        public int pay_count { get; set; }
        public int points_level { get; set; }
        public int currentBalance { get; set; }
        public string date { get; set; }
        public string source { get; set; }
        public string location { get; set; }
        public int amount { get; set; }
        public string externalId { get; set; }
        public int nextValue { get; set; }
        //"campaigns": [],
        public bool delivery { get; set; }
}
}
