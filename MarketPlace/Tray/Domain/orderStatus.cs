using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class orderStatus
    {
        public string id { get; set; }
        //public string default" { get; set; }
        public string type { get; set; }
        public string show_backoffice { get; set; }
        public string allow_edit_order { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string show_status_central { get; set; }
        public string background { get; set; }
        public string display_name { get; set; }
        public string font_color { get; set; }
    }
}
