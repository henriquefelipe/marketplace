using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain
{
    public class status
    {
        public status()
        {
            validations = new List<status_validations>();
        }

        public string operation { get; set; }
        public string salesChannel { get; set; }
        public bool available { get; set; }
        public string state { get; set; }
        public status_reopenable reopenable { get; set; }
        public List<status_validations> validations { get; set; }
        public status_message message { get; set; }
    }

    public class status_reopenable
    {
        public string identifier { get; set; }
        public string type { get; set; }
        public bool reopenable { get; set; }
    }

    public class status_validations
    {
        public string id { get; set; }
        public string code { get; set; }
        public string state { get; set; }
        public status_message message { get; set; }
    }

    public class status_message
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public int? priority { get; set; }
    }
}
