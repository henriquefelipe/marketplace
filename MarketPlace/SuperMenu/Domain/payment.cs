using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMenu.Domain
{
    public class payment
    {
        public string kind { get; set; }
        public string label { get; set; }
        public string legend { get; set; }        
        public string cvv { get; set; }       
    }
}
