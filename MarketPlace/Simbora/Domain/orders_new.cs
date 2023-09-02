using System;
using System.Collections.Generic;
using System.Text;

namespace Simbora.Domain
{
    public class orders_new
    {
        public orders_new()
        {
            orders = new List<order>();
        }

        public List<order> orders {  get; set; }
    }
}
