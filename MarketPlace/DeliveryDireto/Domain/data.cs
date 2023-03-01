using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryDireto.Domain
{
    public class data
    {
        public List<order> orders { get; set; }
        public pagination pagination { get; set; }
    }
}
