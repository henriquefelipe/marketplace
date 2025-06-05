using System;
using System.Collections.Generic;
using System.Text;

namespace Repediu.Domain
{
    public class item
    {   
        public item() 
        {
            options = new List<option>();
        }

        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string externalCode { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }        
        public values unitPrice { get; set; }
        public values totalPrice { get; set; }
        public List<option> options { get; set; }
    }

    public class option : item
    {
        public int index { get; set; }
        public values originalPrice { get; set; }
        public string ean {  get; set; }
        public string specialInstructions { get; set; }
    }
}
