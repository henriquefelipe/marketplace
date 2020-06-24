using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logaroo.Domain
{
    public class orderstatusresult
    {        
        public orderstatusresultdata data { get; set; }
    }
   
    public class orderstatusresultdata
    {
        public int id { get; set; }       
    }
}
