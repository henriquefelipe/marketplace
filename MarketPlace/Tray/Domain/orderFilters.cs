using System;
using System.Collections.Generic;
using System.Text;

namespace Tray.Domain
{
    public class orderFilters
    {
        public orderFilters()
        {
            limit = 50;
        }

        public string sort {  get; set; }
        public int limit { get; set; }
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
    }
}
